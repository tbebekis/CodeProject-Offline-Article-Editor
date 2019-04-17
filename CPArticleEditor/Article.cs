using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;

namespace CPArticleEditor
{
    class Article
    {
        /* private */
        WebBrowser Browser;
        string fFilePath;

        void Browser_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            if (Browser.Document.GetElementById("EditorArea") != null)
            {
                Browser.Document.GetElementsByTagName("base")[0].SetAttribute("href", this.FileProtocolBaseUrl);
                Browser.Document.GetElementById("EditorArea").InnerHtml = this.HtmlText;
                Browser.Document.InvokeScript("prepare");
            }
        }
        void Browser_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.F5)                   // Prevent refreshing...
                e.IsInputKey = true;

            else if (e.Control && e.KeyCode == Keys.S)  // CTRL+S
            {
                SaveChanges();
                e.IsInputKey = true;
            }
        }

        /* construction */
        public Article(WebBrowser Browser)
        {
            this.Browser = Browser;

            Browser.DocumentCompleted += Browser_DocumentCompleted;
            Browser.PreviewKeyDown += Browser_PreviewKeyDown;
        }
 
        /* public */        
        public void CreateNew()
        {

            using (SaveFileDialog Dlg = new SaveFileDialog())
            {
                Dlg.InitialDirectory = App.LastArticleFolder;
                Dlg.Filter = "CodeProject article files (*.cpa)|*.cpa";
                Dlg.RestoreDirectory = true;

                if (Dlg.ShowDialog() == DialogResult.OK)
                {
                    string S = Dlg.FileName;

                    App.Settings.ArticleFolder = Path.GetDirectoryName(S);
                    App.Settings.Save();

                    this.FilePath = S;
                    Browser.Navigate(App.EditorFilePath);
                     
                }
            }
        }
        public void Open()
        {
            using (OpenFileDialog Dlg = new OpenFileDialog())
            {
                Dlg.InitialDirectory = App.LastArticleFolder;
                Dlg.Filter = "CodeProject article files (*.cpa)|*.cpa";
                Dlg.Multiselect = false;

                if (Dlg.ShowDialog() == DialogResult.OK)
                {
                    string S = Dlg.FileName;

                    App.Settings.ArticleFolder = Path.GetDirectoryName(S);
                    App.Settings.Save();

                    this.FilePath = S;
                    Browser.Navigate(App.EditorFilePath); 
                }
            }
        }

        public void SaveChanges()
        {
            if (!string.IsNullOrWhiteSpace(this.FilePath))
            {
                HtmlText = ((string)Browser.Document.InvokeScript("getHTMLData")).Replace(this.FileProtocolBaseUrl, "");
                File.WriteAllText(this.FilePath, this.HtmlText, Encoding.UTF8);
            }
        }
        public void CopyHtmlText()
        {
            if (!string.IsNullOrWhiteSpace(this.FilePath))
            {
                try
                {
                    string S = ((string)Browser.Document.InvokeScript("getHTMLData")).Replace(this.FileProtocolBaseUrl, "");
                    Clipboard.SetText(S);
                }
                catch
                {
                }
            }
        }
        public void ClearBrowser()
        {
            Browser.Navigate("about:blank");

            this.fFilePath = "";
            this.FileName = "";
            this.FileProtocolBaseUrl = "";
            this.HtmlText = "";
        }

        /* properties */
        public string FilePath
        {
            get { return fFilePath; }
            set
            {
                fFilePath = value;
                FileName = Path.GetFileName(fFilePath);
                FileProtocolBaseUrl = Uri.EscapeUriString("file:///" + Path.GetDirectoryName(fFilePath).Replace("\\", "/") + "/");
                HtmlText = string.Empty;

                if (!File.Exists(fFilePath))
                {
                    HtmlText = File.ReadAllText(@"RequiredFiles\codeproject_template.htm", Encoding.UTF8);
                    File.WriteAllText(fFilePath, HtmlText, Encoding.UTF8);
                }
                else
                {
                    HtmlText = File.ReadAllText(fFilePath, Encoding.UTF8);
                }
            }
        }
        public string FileName { get; private set; }
        public string FileProtocolBaseUrl { get; private set; }
        public string HtmlText { get; private set; }
    }
}
