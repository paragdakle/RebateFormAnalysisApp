namespace Asg3_pxd160530
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
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.ctlOpenFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.ctlFilePath = new System.Windows.Forms.TextBox();
            this.ctlOpenFile = new System.Windows.Forms.Button();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.lblActivityStatusBar = new System.Windows.Forms.ToolStripStatusLabel();
            this.ctlSaveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.ctlSaveFileAnalysis = new System.Windows.Forms.Button();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(13, 39);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(120, 95);
            this.listBox1.TabIndex = 0;
            // 
            // ctlOpenFileDialog
            // 
            this.ctlOpenFileDialog.Filter = "Text files (*.txt)|*.txt";
            // 
            // ctlFilePath
            // 
            this.ctlFilePath.Location = new System.Drawing.Point(13, 13);
            this.ctlFilePath.Name = "ctlFilePath";
            this.ctlFilePath.Size = new System.Drawing.Size(583, 20);
            this.ctlFilePath.TabIndex = 1;
            // 
            // ctlOpenFile
            // 
            this.ctlOpenFile.Location = new System.Drawing.Point(602, 10);
            this.ctlOpenFile.Name = "ctlOpenFile";
            this.ctlOpenFile.Size = new System.Drawing.Size(75, 23);
            this.ctlOpenFile.TabIndex = 2;
            this.ctlOpenFile.Text = "Open";
            this.ctlOpenFile.UseVisualStyleBackColor = true;
            this.ctlOpenFile.Click += new System.EventHandler(this.ctlOpenFile_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblActivityStatusBar});
            this.statusStrip1.Location = new System.Drawing.Point(0, 578);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(686, 22);
            this.statusStrip1.TabIndex = 3;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // lblActivityStatusBar
            // 
            this.lblActivityStatusBar.Name = "lblActivityStatusBar";
            this.lblActivityStatusBar.Size = new System.Drawing.Size(0, 17);
            // 
            // ctlSaveFileDialog
            // 
            this.ctlSaveFileDialog.DefaultExt = "txt";
            this.ctlSaveFileDialog.Filter = "Text Files (*.txt)|*.txt";
            // 
            // ctlSaveFileAnalysis
            // 
            this.ctlSaveFileAnalysis.Location = new System.Drawing.Point(599, 539);
            this.ctlSaveFileAnalysis.Name = "ctlSaveFileAnalysis";
            this.ctlSaveFileAnalysis.Size = new System.Drawing.Size(75, 23);
            this.ctlSaveFileAnalysis.TabIndex = 4;
            this.ctlSaveFileAnalysis.Text = "Save";
            this.ctlSaveFileAnalysis.UseVisualStyleBackColor = true;
            this.ctlSaveFileAnalysis.Click += new System.EventHandler(this.ctlSaveAnalysis_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(686, 600);
            this.Controls.Add(this.ctlSaveFileAnalysis);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.ctlOpenFile);
            this.Controls.Add(this.ctlFilePath);
            this.Controls.Add(this.listBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.OpenFileDialog ctlOpenFileDialog;
        private System.Windows.Forms.TextBox ctlFilePath;
        private System.Windows.Forms.Button ctlOpenFile;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel lblActivityStatusBar;
        private System.Windows.Forms.SaveFileDialog ctlSaveFileDialog;
        private System.Windows.Forms.Button ctlSaveFileAnalysis;
    }
}

