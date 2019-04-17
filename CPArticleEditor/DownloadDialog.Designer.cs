namespace CPArticleEditor
{
    partial class DownloadDialog
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnClearLog = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.btnDownloadArticles = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnDownloadArticleList = new System.Windows.Forms.Button();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.lboArticles = new System.Windows.Forms.CheckedListBox();
            this.edtLog = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnClearLog);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.panel4);
            this.panel1.Controls.Add(this.btnDownloadArticles);
            this.panel1.Controls.Add(this.btnExit);
            this.panel1.Controls.Add(this.btnDownloadArticleList);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(784, 32);
            this.panel1.TabIndex = 2;
            // 
            // btnClearLog
            // 
            this.btnClearLog.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnClearLog.Location = new System.Drawing.Point(566, 0);
            this.btnClearLog.Name = "btnClearLog";
            this.btnClearLog.Size = new System.Drawing.Size(100, 32);
            this.btnClearLog.TabIndex = 13;
            this.btnClearLog.Text = "Clear Log";
            this.btnClearLog.UseVisualStyleBackColor = true;
            // 
            // panel3
            // 
            this.panel3.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel3.Location = new System.Drawing.Point(666, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(18, 32);
            this.panel3.TabIndex = 11;
            // 
            // panel4
            // 
            this.panel4.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel4.Location = new System.Drawing.Point(200, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(18, 32);
            this.panel4.TabIndex = 6;
            // 
            // btnDownloadArticles
            // 
            this.btnDownloadArticles.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnDownloadArticles.Location = new System.Drawing.Point(100, 0);
            this.btnDownloadArticles.Name = "btnDownloadArticles";
            this.btnDownloadArticles.Size = new System.Drawing.Size(100, 32);
            this.btnDownloadArticles.TabIndex = 2;
            this.btnDownloadArticles.Text = "Download";
            this.btnDownloadArticles.UseVisualStyleBackColor = true;
            // 
            // btnExit
            // 
            this.btnExit.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnExit.Location = new System.Drawing.Point(684, 0);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(100, 32);
            this.btnExit.TabIndex = 1;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = true;
            // 
            // btnDownloadArticleList
            // 
            this.btnDownloadArticleList.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnDownloadArticleList.Location = new System.Drawing.Point(0, 0);
            this.btnDownloadArticleList.Name = "btnDownloadArticleList";
            this.btnDownloadArticleList.Size = new System.Drawing.Size(100, 32);
            this.btnDownloadArticleList.TabIndex = 0;
            this.btnDownloadArticleList.Text = "Article List";
            this.btnDownloadArticleList.UseVisualStyleBackColor = true;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 32);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.lboArticles);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.edtLog);
            this.splitContainer1.Size = new System.Drawing.Size(784, 529);
            this.splitContainer1.SplitterDistance = 249;
            this.splitContainer1.TabIndex = 3;
            // 
            // lboArticles
            // 
            this.lboArticles.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lboArticles.FormattingEnabled = true;
            this.lboArticles.Location = new System.Drawing.Point(0, 0);
            this.lboArticles.Name = "lboArticles";
            this.lboArticles.Size = new System.Drawing.Size(784, 249);
            this.lboArticles.TabIndex = 9;
            // 
            // edtLog
            // 
            this.edtLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.edtLog.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.edtLog.Location = new System.Drawing.Point(0, 0);
            this.edtLog.Multiline = true;
            this.edtLog.Name = "edtLog";
            this.edtLog.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.edtLog.Size = new System.Drawing.Size(784, 276);
            this.edtLog.TabIndex = 1;
            // 
            // DownloadDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.panel1);
            this.MinimizeBox = false;
            this.Name = "DownloadDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Download from CodeProject";
            this.panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Button btnDownloadArticles;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnDownloadArticleList;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.CheckedListBox lboArticles;
        private System.Windows.Forms.TextBox edtLog;
        private System.Windows.Forms.Button btnClearLog;
    }
}