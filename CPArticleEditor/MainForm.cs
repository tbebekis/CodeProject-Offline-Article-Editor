using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;

namespace CPArticleEditor
{
    public partial class MainForm : Form
    {
        const string STitle = "CodeProject Article Editor - [{0}]";
        Article Article;

        /* handlers */
        void AnyClick(object sender, EventArgs ea)
        {
            if (btnExit == sender)
            {
                Close();
                return;
            }

            if (btnLoginInfo == sender)
            {
                LoginDialog.ShowModal();
            }
            else if (btnNew == sender)
            {
                Article.CreateNew();
                UpdateTitle();
            }
            else if (btnOpen == sender)
            {
                Article.Open();
                UpdateTitle();
            }
            else if (btnDownloadArticles == sender)
            {
                using (var F = new DownloadDialog())
                    F.ShowDialog();
            }


            else if (mnuSave == sender || btnSave == sender)
            {
                Article.SaveChanges();
            }
            else if (mnuCloseEditor == sender || btnCloseEditor == sender)
            {
                if (MessageBox.Show(this, "Do you want to close the editor?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    Article.ClearBrowser();
                }
            }
            else if (mnuCopyHtmlText == sender)
            {
                Article.CopyHtmlText();
            }
        }

        /* private */
        void FormInitialize()
        {
            Browser.IsWebBrowserContextMenuEnabled = false;
            Browser.WebBrowserShortcutsEnabled = true;
            Browser.ScriptErrorsSuppressed = true;
            Browser.AllowWebBrowserDrop = false;

            btnExit.Click += AnyClick;
            btnLoginInfo.Click += AnyClick;
            btnNew.Click += AnyClick;
            btnOpen.Click += AnyClick;
            btnSave.Click += AnyClick;
            btnCloseEditor.Click += AnyClick;
            btnDownloadArticles.Click += AnyClick;

            mnuCloseEditor.Click += AnyClick;
            mnuSave.Click += AnyClick;
            mnuCopyHtmlText.Click += AnyClick;

            Article = new Article(this.Browser);

            UpdateTitle();
        }
        void UpdateTitle()
        {
            this.Text = string.Format(STitle, Article.FileName);
        }
 
        /* overrides */
        protected override void OnShown(EventArgs e)
        {
            if (!DesignMode)
                FormInitialize();
            base.OnShown(e);
        }


        /* construction */
        public MainForm()
        {
            InitializeComponent();
        }
    }
}
