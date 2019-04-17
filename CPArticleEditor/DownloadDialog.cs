using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CPArticleEditor
{
    public partial class DownloadDialog : Form
    {
        CodeProject CP;

        /* handlers */
        void AnyClick(object sender, EventArgs ea)
        {
            if (btnExit == sender)
            {
                Close();
                return;
            }


            if (btnClearLog == sender)
            {
                edtLog.Text = string.Empty;
            }
            else if (btnDownloadArticleList == sender)
            {
                DownloadArticleList();
            }
            else if (btnDownloadArticles == sender)
            {
                DownloadArticles();
            }
        }
        void CodeProject_NavigatedTo(object sender, CodeProjectNavigationEventArgs ea)
        {
            string S = string.Format("Navigated to: {0}", ea.Navigation);
            edtLog.AppendText(S + Environment.NewLine);

            if (ea.Navigation == Navigation.ArticleList)
            {
                lboArticles.Items.AddRange(CP.ArticleList.ToArray());

                for (int i = 0; i < lboArticles.Items.Count; i++)
                {
                    lboArticles.SetItemChecked(i, true);
                }
            }
        }
        void CodeProject_Log(object sender, CodeProjectLogEventArgs ea)
        {
            string S = string.Format("{0}: {1}", ea.LogType, ea.Text);
            edtLog.AppendText(S + Environment.NewLine);
        }

        /* private */
        void DownloadArticleList()
        {
            lboArticles.Items.Clear();

            if (CP == null)
            {
                CP = new CodeProject();
                CP.NavigatedTo += CodeProject_NavigatedTo;
                CP.Log += CodeProject_Log;
            }

            CP.Login(App.Settings.Email, App.Settings.Password);
        }
        void DownloadArticles()
        {
            if (CP != null)
            {
                List<ArticleInfo> List = new List<ArticleInfo>();
                foreach (ArticleInfo Info in lboArticles.CheckedItems)
                {
                    List.Add(Info);
                }
 
                if (List.Count > 0)
                {
                    CP.Download(List.ToArray(), App.Settings.ArticleFolder);
                }
            }
        }
        void DisposeCodeProject()
        {
            if (CP != null && !CP.IsDisposed)
            {
                CP.Dispose();
                CP = null;
            }
        }
        void FormInitialize()
        {
            btnExit.Click += AnyClick;
            
            btnClearLog.Click += AnyClick;
            btnDownloadArticleList.Click += AnyClick;
            btnDownloadArticles.Click += AnyClick;
        }

        /* overrides */
        protected override void OnShown(EventArgs e)
        {
            if (!DesignMode)
                FormInitialize();

            base.OnShown(e);
        }
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            DisposeCodeProject();
            base.OnFormClosing(e);
        }


        /* construction */
        public DownloadDialog()
        {
            InitializeComponent();
        }
    }
}
