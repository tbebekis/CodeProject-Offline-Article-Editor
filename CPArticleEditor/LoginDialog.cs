using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace CPArticleEditor
{
    public partial class LoginDialog : Form
    {
        Settings Settings = App.Settings;

        void AnyClick(object sender, EventArgs ea)
        {
            if (btnOK == sender)
            {
                if (!string.IsNullOrWhiteSpace(edtEmail.Text)
                    && !string.IsNullOrWhiteSpace(edtPassword.Text)
                    && !string.IsNullOrWhiteSpace(edtArticleFolder.Text))
                {
                    Settings.Email = edtEmail.Text.Trim();
                    Settings.Password = edtPassword.Text.Trim();
                    Settings.ArticleFolder = edtArticleFolder.Text.Trim();

                    Settings.Save();

                    if (!Directory.Exists(Settings.ArticleFolder))
                        Directory.CreateDirectory(Settings.ArticleFolder);

                    this.DialogResult = DialogResult.OK;
                }                
            }
            else if (btnSelectArticlesFolder == sender)
            {
                SelectArticleFolder();
            }
        }
 
        void SelectArticleFolder()
        {
            string Folder = edtArticleFolder.Text.Trim();
            using (FolderBrowserDialog Dlg = new FolderBrowserDialog())
            {
                if (Directory.Exists(Folder))
                    Dlg.SelectedPath = Folder;

                Dlg.Description = "Select a directory to save CodeProject articles";
                if (Dlg.ShowDialog() == DialogResult.OK)
                {
                    edtArticleFolder.Text = Dlg.SelectedPath;
                }
            }
        }
        void FormInitialize()
        {
            this.CancelButton = btnCancel;
            btnOK.Click += AnyClick;
            btnSelectArticlesFolder.Click += AnyClick;


            if (!string.IsNullOrWhiteSpace(Settings.Email))
            {
                edtEmail.Text = Settings.Email;
            }
            if (!string.IsNullOrWhiteSpace(Settings.Password))
            {
                edtPassword.Text = Settings.Password;
            }
            if (!string.IsNullOrWhiteSpace(Settings.ArticleFolder))
            {
                edtArticleFolder.Text = Settings.ArticleFolder;
            }

        }

        protected override void OnShown(EventArgs e)
        {
            if (!DesignMode)
                FormInitialize();
            base.OnShown(e);
        }

        public LoginDialog()
        {
            InitializeComponent();
        }

        static public bool ShowModal()
        {
            using (LoginDialog F = new LoginDialog())
            {
                return F.ShowDialog() == DialogResult.OK;
            }
        }

    }
}
