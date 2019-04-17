namespace CPArticleEditor
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.StatusBar = new System.Windows.Forms.StatusStrip();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnDownloadArticles = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnCloseEditor = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.panel4 = new System.Windows.Forms.Panel();
            this.btnOpen = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnNew = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.Browser = new System.Windows.Forms.WebBrowser();
            this.BrowserContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mnuSave = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuCopyHtmlText = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuCloseEditor = new System.Windows.Forms.ToolStripMenuItem();
            this.btnLoginInfo = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.BrowserContextMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // StatusBar
            // 
            this.StatusBar.Location = new System.Drawing.Point(0, 707);
            this.StatusBar.Name = "StatusBar";
            this.StatusBar.Size = new System.Drawing.Size(1008, 22);
            this.StatusBar.TabIndex = 0;
            this.StatusBar.Text = "statusStrip1";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnLoginInfo);
            this.panel1.Controls.Add(this.btnDownloadArticles);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.btnCloseEditor);
            this.panel1.Controls.Add(this.btnSave);
            this.panel1.Controls.Add(this.panel4);
            this.panel1.Controls.Add(this.btnOpen);
            this.panel1.Controls.Add(this.btnExit);
            this.panel1.Controls.Add(this.btnNew);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1008, 32);
            this.panel1.TabIndex = 1;
            // 
            // btnDownloadArticles
            // 
            this.btnDownloadArticles.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnDownloadArticles.Location = new System.Drawing.Point(790, 0);
            this.btnDownloadArticles.Name = "btnDownloadArticles";
            this.btnDownloadArticles.Size = new System.Drawing.Size(100, 32);
            this.btnDownloadArticles.TabIndex = 12;
            this.btnDownloadArticles.Text = "Download Articles";
            this.btnDownloadArticles.UseVisualStyleBackColor = true;
            // 
            // panel3
            // 
            this.panel3.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel3.Location = new System.Drawing.Point(890, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(18, 32);
            this.panel3.TabIndex = 11;
            // 
            // btnCloseEditor
            // 
            this.btnCloseEditor.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnCloseEditor.Location = new System.Drawing.Point(318, 0);
            this.btnCloseEditor.Name = "btnCloseEditor";
            this.btnCloseEditor.Size = new System.Drawing.Size(100, 32);
            this.btnCloseEditor.TabIndex = 10;
            this.btnCloseEditor.Text = "Close editor";
            this.btnCloseEditor.UseVisualStyleBackColor = true;
            // 
            // btnSave
            // 
            this.btnSave.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnSave.Location = new System.Drawing.Point(218, 0);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(100, 32);
            this.btnSave.TabIndex = 8;
            this.btnSave.Text = "Save  (Ctrl+S)";
            this.btnSave.UseVisualStyleBackColor = true;
            // 
            // panel4
            // 
            this.panel4.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel4.Location = new System.Drawing.Point(200, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(18, 32);
            this.panel4.TabIndex = 6;
            // 
            // btnOpen
            // 
            this.btnOpen.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnOpen.Location = new System.Drawing.Point(100, 0);
            this.btnOpen.Name = "btnOpen";
            this.btnOpen.Size = new System.Drawing.Size(100, 32);
            this.btnOpen.TabIndex = 2;
            this.btnOpen.Text = "Open";
            this.btnOpen.UseVisualStyleBackColor = true;
            // 
            // btnExit
            // 
            this.btnExit.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnExit.Location = new System.Drawing.Point(908, 0);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(100, 32);
            this.btnExit.TabIndex = 1;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = true;
            // 
            // btnNew
            // 
            this.btnNew.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnNew.Location = new System.Drawing.Point(0, 0);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(100, 32);
            this.btnNew.TabIndex = 0;
            this.btnNew.Text = "New";
            this.btnNew.UseVisualStyleBackColor = true;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.Browser);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 32);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1008, 675);
            this.panel2.TabIndex = 2;
            // 
            // Browser
            // 
            this.Browser.ContextMenuStrip = this.BrowserContextMenu;
            this.Browser.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Browser.Location = new System.Drawing.Point(0, 0);
            this.Browser.MinimumSize = new System.Drawing.Size(20, 20);
            this.Browser.Name = "Browser";
            this.Browser.Size = new System.Drawing.Size(1008, 675);
            this.Browser.TabIndex = 0;
            // 
            // BrowserContextMenu
            // 
            this.BrowserContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuSave,
            this.mnuCopyHtmlText,
            this.mnuCloseEditor});
            this.BrowserContextMenu.Name = "contextMenuStrip1";
            this.BrowserContextMenu.ShowImageMargin = false;
            this.BrowserContextMenu.Size = new System.Drawing.Size(203, 70);
            // 
            // mnuSave
            // 
            this.mnuSave.Name = "mnuSave";
            this.mnuSave.Size = new System.Drawing.Size(202, 22);
            this.mnuSave.Text = "Save changes   Ctrl+S";
            // 
            // mnuCopyHtmlText
            // 
            this.mnuCopyHtmlText.Name = "mnuCopyHtmlText";
            this.mnuCopyHtmlText.Size = new System.Drawing.Size(202, 22);
            this.mnuCopyHtmlText.Text = "Copy source to the clipboard";
            // 
            // mnuCloseEditor
            // 
            this.mnuCloseEditor.Name = "mnuCloseEditor";
            this.mnuCloseEditor.Size = new System.Drawing.Size(202, 22);
            this.mnuCloseEditor.Text = "Close editor";
            // 
            // btnLoginInfo
            // 
            this.btnLoginInfo.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnLoginInfo.Location = new System.Drawing.Point(690, 0);
            this.btnLoginInfo.Name = "btnLoginInfo";
            this.btnLoginInfo.Size = new System.Drawing.Size(100, 32);
            this.btnLoginInfo.TabIndex = 13;
            this.btnLoginInfo.Text = "Login Info";
            this.btnLoginInfo.UseVisualStyleBackColor = true;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1008, 729);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.StatusBar);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CodeProject Article Editor";
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.BrowserContextMenu.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip StatusBar;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnOpen;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.WebBrowser Browser;
        private System.Windows.Forms.ContextMenuStrip BrowserContextMenu;
        private System.Windows.Forms.ToolStripMenuItem mnuSave;
        private System.Windows.Forms.ToolStripMenuItem mnuCopyHtmlText;
        private System.Windows.Forms.ToolStripMenuItem mnuCloseEditor;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Button btnCloseEditor;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button btnDownloadArticles;
        private System.Windows.Forms.Button btnLoginInfo;
    }
}

