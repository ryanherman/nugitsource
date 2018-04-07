namespace NuGitWin
{
    partial class Form1
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
            this.StartButton = new System.Windows.Forms.Button();
            this.GitSource = new System.Windows.Forms.TextBox();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.StoreSource = new System.Windows.Forms.TextBox();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.AddButton = new System.Windows.Forms.Button();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.SolutionDir = new System.Windows.Forms.TextBox();
            this.SourceDir = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // StartButton
            // 
            this.StartButton.Location = new System.Drawing.Point(156, 288);
            this.StartButton.Name = "StartButton";
            this.StartButton.Size = new System.Drawing.Size(276, 64);
            this.StartButton.TabIndex = 0;
            this.StartButton.Text = "Start";
            this.StartButton.UseVisualStyleBackColor = true;
            this.StartButton.Click += new System.EventHandler(this.button1_Click);
            // 
            // GitSource
            // 
            this.GitSource.Location = new System.Drawing.Point(56, 111);
            this.GitSource.Name = "GitSource";
            this.GitSource.Size = new System.Drawing.Size(496, 26);
            this.GitSource.TabIndex = 1;
            this.GitSource.Text = "https://github.com/jamesmontemagno/MediaPlugin.git";
            // 
            // StoreSource
            // 
            this.StoreSource.Location = new System.Drawing.Point(56, 66);
            this.StoreSource.Name = "StoreSource";
            this.StoreSource.Size = new System.Drawing.Size(496, 26);
            this.StoreSource.TabIndex = 2;
            this.StoreSource.Text = "C:\\temp\\collectioncrash\\NuGitSource\\Segme\\nuget";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // AddButton
            // 
            this.AddButton.Location = new System.Drawing.Point(156, 374);
            this.AddButton.Name = "AddButton";
            this.AddButton.Size = new System.Drawing.Size(276, 66);
            this.AddButton.TabIndex = 3;
            this.AddButton.Text = "Explore";
            this.AddButton.UseVisualStyleBackColor = true;
            this.AddButton.Click += new System.EventHandler(this.AddButton_Click);
            // 
            // listBox1
            // 
            this.listBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 29;
            this.listBox1.Location = new System.Drawing.Point(637, 66);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(1498, 236);
            this.listBox1.TabIndex = 4;
            // 
            // SolutionDir
            // 
            this.SolutionDir.Location = new System.Drawing.Point(56, 156);
            this.SolutionDir.Name = "SolutionDir";
            this.SolutionDir.Size = new System.Drawing.Size(496, 26);
            this.SolutionDir.TabIndex = 5;
            this.SolutionDir.Text = "C:\\temp\\collectioncrash\\collectioncrash.sln";
            // 
            // SourceDir
            // 
            this.SourceDir.Location = new System.Drawing.Point(56, 209);
            this.SourceDir.Name = "SourceDir";
            this.SourceDir.Size = new System.Drawing.Size(496, 26);
            this.SourceDir.TabIndex = 6;
            this.SourceDir.Text = "C:\\temp\\collectioncrash\\NuGitSource\\Segme\\SegmentedControl";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(2187, 523);
            this.Controls.Add(this.SourceDir);
            this.Controls.Add(this.SolutionDir);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.AddButton);
            this.Controls.Add(this.StoreSource);
            this.Controls.Add(this.GitSource);
            this.Controls.Add(this.StartButton);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button StartButton;
        private System.Windows.Forms.TextBox GitSource;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.TextBox StoreSource;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button AddButton;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.TextBox SolutionDir;
        private System.Windows.Forms.TextBox SourceDir;
    }
}

