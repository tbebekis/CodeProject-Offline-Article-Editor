using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.IO;
using System.Net;

namespace CPArticleEditor
{

    public enum Navigation
    {
        None,
        Logout,
        LoginCheck,        
        Login,
        ArticleList,
        Article
    }

    public enum LogType
    {
        Info,
        Error,
    }

    public class CodeProjectNavigationEventArgs : EventArgs
    {
        public CodeProjectNavigationEventArgs(Navigation Navigation)
        {
            this.Navigation = Navigation; 
        }

        public Navigation Navigation { get; } 
    }

    public class CodeProjectLogEventArgs: EventArgs
    {
        public CodeProjectLogEventArgs(LogType LogType, string Text)
        {
            this.LogType = LogType;
            this.Text = Text;
        }

        public LogType LogType { get; }
        public string Text { get; }
    }

    public class Author
    {
        CodeProject CP;
        public Author(CodeProject CP)
        {
            this.CP = CP;
        }

        public bool Load()
        {
            this.Id = string.Empty;
            this.Name = string.Empty;
            this.FullName = string.Empty;

            CP.Info("Parsing Author information");

            bool Result = false;
            try
            {
                string href = CP.Document.GetElementById(CP.GetElementId("MyProfile")).GetAttribute("href");
                int start = href.LastIndexOf("=") + 1;

                this.Id = href.Substring(start, href.Length - start);
                this.FullName = CP.Document.GetElementById(CP.GetElementId("MyProfile")).InnerText;

                if (!string.IsNullOrWhiteSpace(this.Id) && !string.IsNullOrWhiteSpace(this.FullName))
                {
                    this.Name = this.FullName.Contains(" ") ? this.FullName.Substring(0, this.FullName.IndexOf(" ")): this.FullName;
                    Result = true;
                }

                CP.Info("Parsing Author information. DONE");
            }
            catch (Exception ex)
            {
                CP.Error(ex.Message);
            }
            return Result;
        }

        public string Id { get; private set; }
        public string Name { get; private set; }
        public string FullName { get; private set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }

    public class ArticleInfo
    {
        public ArticleInfo(string Id, string Name)
        {
            this.Id = Id;
            this.Name = Name;
        }

        public override string ToString()
        {
            return Name;
        }

        public string Id { get; }
        public string Name { get; }
    }


    public class CodeProject : WebBrowser
    {
 
        /* private */
        Navigation CurrentNavigation = Navigation.None;
        ArticleInfo CurrentArticleInfo;
        string ArticleFolder;
        Action<ArticleInfo> OnArticleDownloaded;
        bool IsDisposing;

        void NavigateTo(Navigation Navigation)
        {
            string Url = string.Empty;
            CurrentNavigation = Navigation;
            Info(string.Format("Navigating to: {0}", CurrentNavigation));
 
            switch (CurrentNavigation)
            {
                case Navigation.LoginCheck:                    
                    Url = "https://www.codeproject.com/script/Membership/LogOn.aspx";
                    break;
                case Navigation.Login:
                    try
                    {
                        this.Document.GetElementById(GetElementId("_MC_MemberLogOn_CurrentEmail")).SetAttribute("value", Author.Email);
                        this.Document.GetElementById(GetElementId("_MC_MemberLogOn_CurrentPassword")).SetAttribute("value", Author.Password);
                        this.Document.GetElementById(GetElementId("_MC_MemberLogOn_SignInButton")).InvokeMember("click");
                    }
                    catch (Exception ex)
                    {
                        Error(ex.Message);
                    }

                    break;
                case Navigation.Logout:
                    Url = "http://www.codeproject.com/script/Membership/LogOff.aspx";
                    break;
                case Navigation.ArticleList:
                    Url = "http://www.codeproject.com/script/Articles/MemberArticles.aspx?amid=" + Author.Id + "&yenilemesiicin=" + Guid.NewGuid().ToString();
                    break;
                case Navigation.Article:
                    Url = "http://www.codeproject.com/script/Articles/ViewHtml.aspx?aid=" + CurrentArticleInfo.Id + "&yenilemesiicin=" + Guid.NewGuid().ToString();
                    break;
            }

            

            if (!string.IsNullOrWhiteSpace(Url))
            {
                this.Navigate(Url);
            }

        }
        void DoNavigated()
        {
            try
            {
                switch (CurrentNavigation)
                {
                    case Navigation.Logout:
                        IsLoggedIn = false;
                        OnNavigatedTo(CurrentNavigation);
                        Info("Logout: DONE");
                        NavigateTo(Navigation.None);
                        break;

                    case Navigation.LoginCheck:
                        OnNavigatedTo(CurrentNavigation);
                        if (this.Author.Load())
                        {
                            Info("Was already logged in.");
                            CurrentNavigation = Navigation.Login;
                            DoNavigated();
                        }
                        else
                        {
                            NavigateTo(Navigation.Login);
                        }
                        break;

                    case Navigation.Login:
                        OnNavigatedTo(CurrentNavigation);
                        string ErrorElementId = GetElementId("LogonError");

                        if (!string.IsNullOrWhiteSpace(ErrorElementId))
                        {
                            IsLoggedIn = false;
                            NavigateTo(Navigation.None);
                            HtmlElement ErrorElement = this.Document.GetElementById(ErrorElementId);
                            Error("Login: FAILED" + Environment.NewLine + ErrorElement.InnerText);
                        }
                        else
                        {
                            if (this.Author.Load())
                            {
                                IsLoggedIn = true;
                                Info("Login: DONE");
                                NavigateTo(Navigation.ArticleList);
                            }
                            else
                            {
                                IsLoggedIn = false;
                                Error("Can not extract Author Id");
                            }
                        }
                        break;

                    case Navigation.ArticleList:

                        Info("Article List: Reading");
                        int ArticleCount = 0;

                        string prefixForArticles = GetElementId("_MC_AR_ctl");
                        HtmlElement link = this.Document.GetElementById(prefixForArticles + ArticleCount.ToString("00") + "_CAR_Title");

                        if (link == null)
                        {
                            ArticleCount = 1; // Try to start from 1
                            link = this.Document.GetElementById(prefixForArticles + ArticleCount.ToString("00") + "_CAR_Title");
                        }

                        while (link != null)
                        {
                            string articleName = link.InnerText;
                            string linkToTheArticle = link.GetAttribute("href");
                            string articleID = Regex.Match(linkToTheArticle, "/([0-9]{1,12})/").Groups[1].Value;

                            ArticleList.Add(new ArticleInfo(articleID, articleName));

                            ArticleCount++;
                            link = this.Document.GetElementById(prefixForArticles + ArticleCount.ToString("00") + "_CAR_Title");
                        }

                        Info("Article List: DONE");
                        OnNavigatedTo(CurrentNavigation);
                        NavigateTo(Navigation.None);
                        break;


                    case Navigation.Article:

                        OnNavigatedTo(CurrentNavigation);

                        Info(string.Format("Downloading Article: {0}", CurrentArticleInfo.Name));

                        string HtmlText = string.Empty;
                        string FileName;
                        string FilePath;
                        string Folder;

                        if (this.Document.GetElementById("ArticleContent") != null)
                        {
                            string src;
                            Uri uri;

                            // images
                            string[] images = new string[this.Document.Images.Count];
                            for (int i = 0; i < images.Length; i++)
                            {
                                images[i] = this.Document.Images[i].GetAttribute("src");
                            }

                            Folder = Path.Combine(ArticleFolder, CurrentArticleInfo.Id);
                            Directory.CreateDirectory(Folder);          

                            using (WebClient webClient = new WebClient())
                            {
                                webClient.Proxy = null;                                 // To prevent it from trying to determine proxy settings of IE
                                for (int i = 0; i < images.Length; i++)
                                {
                                    src = images[i];
                                    uri = new Uri(src);
                                    FileName = Path.GetFileName(uri.LocalPath);

                                    FilePath = Path.Combine(ArticleFolder, CurrentArticleInfo.Id, FileName); 

                                    webClient.DownloadFile(src, FilePath);
                                    images[i] = CurrentArticleInfo.Id + "/" + FileName; // To make src attribute relative
                                }
                            }

                            for (int i = 0; i < images.Length; i++)                     // Change src attributes
                            {
                                this.Document.Images[i].SetAttribute("src", images[i]);
                            }

                            // content
                            HtmlText = this.Document.GetElementById("ArticleContent").InnerHtml;
                        }

                        // save article to disk
                        FileName = CurrentArticleInfo.Name;
                        FileName = FileName.Replace('[', '_');
                        FileName = FileName.Replace(']', '_');
                        FileName = FileName.Replace(':', '_');

                        FilePath = Path.Combine(ArticleFolder, FileName);

                        FilePath = string.IsNullOrWhiteSpace(Path.GetExtension(FilePath)) ? FilePath + ".cpa" : Path.ChangeExtension(FilePath, ".cpa");
                        File.WriteAllText(FilePath, HtmlText, Encoding.UTF8);

                        Info(string.Format("Downloading Article: {0}. DONE", CurrentArticleInfo.Name));
                        NavigateTo(Navigation.None);

                        Action<ArticleInfo> Downloaded = OnArticleDownloaded;
                        OnArticleDownloaded = null;

                        Downloaded?.Invoke(CurrentArticleInfo);

                        break;
                }
            }
            catch (Exception ex)
            {
                OnArticleDownloaded = null;
                Error(ex.Message);
            }
        }

        /* overrides */
        protected override void OnDocumentCompleted(WebBrowserDocumentCompletedEventArgs ea)
        {
            DoNavigated();            
        }
        protected override void Dispose(bool disposing)
        {
            if (IsLoggedIn)
            {
                IsDisposing = true;
                Logout();
            }

            base.Dispose(disposing);
        }

        /* construction */
        public CodeProject()
        {
            Author = new Author(this);

            this.IsWebBrowserContextMenuEnabled = false;
            this.WebBrowserShortcutsEnabled = false;
            this.ScriptErrorsSuppressed = true;
            this.AllowWebBrowserDrop = false;
        }

        /* public */
        public void Error(string Text)
        {
            if (IsDisposing)
                return;

            Log?.Invoke(this, new CodeProjectLogEventArgs(LogType.Error, Text));
            CurrentNavigation = Navigation.None;
        }
        public void Info(string Text)
        {
            if (IsDisposing)
                return;

            Log?.Invoke(this, new CodeProjectLogEventArgs(LogType.Info, Text));
        } 
        public void OnNavigatedTo(Navigation Navigation)
        {
            if (IsDisposing)
                return;

            Info(string.Format("Navigated to: {0}", Navigation));
            NavigatedTo?.Invoke(this, new CodeProjectNavigationEventArgs(Navigation));
        }

        public string GetElementId(string suffix)
        {
            Match m = Regex.Match(this.Document.Body.InnerHtml, "(ctl[0-9]{1,3}[A-Za-z0-9_]{1,64}" + suffix + ")", RegexOptions.IgnoreCase);
            if (m.Success)
                return m.Groups[1].Value;
            else
                return "";
        }

        public void Login(string Email, string Password)
        {
            Info("Please Wait: Prepare Login");
            ArticleList.Clear();

            Author.Email = Email;
            Author.Password = Password;

            NavigateTo(Navigation.LoginCheck);
        }
        public void Logout()
        {
            Info("Please Wait: Prepare Logout");
            ArticleList.Clear();
            NavigateTo(Navigation.Logout);
        }

        public void Download(ArticleInfo ArticleInfo, string ArticleFolder)
        {             
            Info(string.Format("Please Wait: Prepare downloading Article: {0}", ArticleInfo.Name));
            this.CurrentArticleInfo = ArticleInfo;
            this.ArticleFolder = ArticleFolder;
            NavigateTo(Navigation.Article); 
        }
        public void Download(ArticleInfo[] List, string ArticleFolder)
        {
            Info("Please Wait: Prepare downloading Article List");

            int Index = 0;
 
            this.ArticleFolder = ArticleFolder;

            Action<ArticleInfo> Downloaded = null;
            Downloaded = (ArticleInfo) =>
            {
                Index++;

                if (Index > List.Length - 1)
                {
                    Info("Downloading Article List. DONE");
                }
                else
                {
                    this.OnArticleDownloaded = Downloaded;  // OnArticleDownloaded becomes null on each iteration, so we re-assign it here
                    Download(List[Index], ArticleFolder);
                }
            };

            this.OnArticleDownloaded = Downloaded;

            Download(List[Index], ArticleFolder);
        }

        /* properties */
        public Author Author { get; }
        public bool IsLoggedIn { get; private set; }
 
        public List<ArticleInfo> ArticleList { get; private set; } = new List<ArticleInfo>();

        /* events */
        public EventHandler<CodeProjectNavigationEventArgs> NavigatedTo { get; set; }
        public EventHandler<CodeProjectLogEventArgs> Log { get; set; }
    }
}
