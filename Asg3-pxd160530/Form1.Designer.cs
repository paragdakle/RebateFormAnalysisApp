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
            this.ctlOpenFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.ctlFilePath = new System.Windows.Forms.TextBox();
            this.ctlOpenFileBrowser = new System.Windows.Forms.Button();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.lblActivityStatusBar = new System.Windows.Forms.ToolStripStatusLabel();
            this.ctlSaveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.ctlSaveFileAnalysis = new System.Windows.Forms.Button();
            this.ctlOpenFile = new System.Windows.Forms.Button();
            this.ctlAnalysisResultsListView = new System.Windows.Forms.ListView();
            this.lblFilePath = new System.Windows.Forms.Label();
            this.columnAnalysisLabel = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnAnalysisResult = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lblInstructionsHeader = new System.Windows.Forms.Label();
            this.lblStep1 = new System.Windows.Forms.Label();
            this.lblStep2 = new System.Windows.Forms.Label();
            this.lblStep4 = new System.Windows.Forms.Label();
            this.lblNotes = new System.Windows.Forms.Label();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // ctlOpenFileDialog
            // 
            this.ctlOpenFileDialog.Filter = "Text files (*.txt)|*.txt";
            // 
            // ctlFilePath
            // 
            this.ctlFilePath.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctlFilePath.Location = new System.Drawing.Point(146, 13);
            this.ctlFilePath.Name = "ctlFilePath";
            this.ctlFilePath.Size = new System.Drawing.Size(265, 22);
            this.ctlFilePath.TabIndex = 1;
            this.ctlFilePath.TextChanged += new System.EventHandler(this.ctlFilePath_TextChanged);
            // 
            // ctlOpenFileBrowser
            // 
            this.ctlOpenFileBrowser.Location = new System.Drawing.Point(417, 8);
            this.ctlOpenFileBrowser.Name = "ctlOpenFileBrowser";
            this.ctlOpenFileBrowser.Size = new System.Drawing.Size(78, 28);
            this.ctlOpenFileBrowser.TabIndex = 2;
            this.ctlOpenFileBrowser.Text = "Browse";
            this.ctlOpenFileBrowser.UseVisualStyleBackColor = true;
            this.ctlOpenFileBrowser.Click += new System.EventHandler(this.ctlOpenFile_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblActivityStatusBar});
            this.statusStrip1.Location = new System.Drawing.Point(0, 422);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(656, 22);
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
            this.ctlSaveFileAnalysis.Location = new System.Drawing.Point(573, 8);
            this.ctlSaveFileAnalysis.Name = "ctlSaveFileAnalysis";
            this.ctlSaveFileAnalysis.Size = new System.Drawing.Size(74, 28);
            this.ctlSaveFileAnalysis.TabIndex = 4;
            this.ctlSaveFileAnalysis.Text = "Save";
            this.ctlSaveFileAnalysis.UseVisualStyleBackColor = true;
            this.ctlSaveFileAnalysis.Click += new System.EventHandler(this.ctlSaveAnalysis_Click);
            // 
            // ctlOpenFile
            // 
            this.ctlOpenFile.Location = new System.Drawing.Point(501, 8);
            this.ctlOpenFile.Name = "ctlOpenFile";
            this.ctlOpenFile.Size = new System.Drawing.Size(66, 28);
            this.ctlOpenFile.TabIndex = 5;
            this.ctlOpenFile.Text = "Open";
            this.ctlOpenFile.UseVisualStyleBackColor = true;
            this.ctlOpenFile.Click += new System.EventHandler(this.ctlOpenFile_Click_1);
            // 
            // ctlAnalysisResultsListView
            // 
            this.ctlAnalysisResultsListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnAnalysisLabel,
            this.columnAnalysisResult});
            this.ctlAnalysisResultsListView.Location = new System.Drawing.Point(13, 45);
            this.ctlAnalysisResultsListView.MultiSelect = false;
            this.ctlAnalysisResultsListView.Name = "ctlAnalysisResultsListView";
            this.ctlAnalysisResultsListView.Size = new System.Drawing.Size(398, 369);
            this.ctlAnalysisResultsListView.TabIndex = 6;
            this.ctlAnalysisResultsListView.UseCompatibleStateImageBehavior = false;
            this.ctlAnalysisResultsListView.View = System.Windows.Forms.View.Details;
            // 
            // lblFilePath
            // 
            this.lblFilePath.AutoSize = true;
            this.lblFilePath.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFilePath.Location = new System.Drawing.Point(10, 16);
            this.lblFilePath.Name = "lblFilePath";
            this.lblFilePath.Size = new System.Drawing.Size(136, 16);
            this.lblFilePath.TabIndex = 7;
            this.lblFilePath.Text = "Rebate Records File:";
            // 
            // columnAnalysisLabel
            // 
            this.columnAnalysisLabel.Text = "Analysis Type";
            this.columnAnalysisLabel.Width = 293;
            // 
            // columnAnalysisResult
            // 
            this.columnAnalysisResult.Text = "Value";
            this.columnAnalysisResult.Width = 100;
            // 
            // lblInstructionsHeader
            // 
            this.lblInstructionsHeader.AutoSize = true;
            this.lblInstructionsHeader.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInstructionsHeader.Location = new System.Drawing.Point(417, 45);
            this.lblInstructionsHeader.Name = "lblInstructionsHeader";
            this.lblInstructionsHeader.Size = new System.Drawing.Size(77, 16);
            this.lblInstructionsHeader.TabIndex = 8;
            this.lblInstructionsHeader.Text = "Instructions:";
            // 
            // lblStep1
            // 
            this.lblStep1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStep1.Location = new System.Drawing.Point(417, 70);
            this.lblStep1.Name = "lblStep1";
            this.lblStep1.Size = new System.Drawing.Size(227, 72);
            this.lblStep1.TabIndex = 9;
            this.lblStep1.Text = "1. Select the file containing rebate buyer records. You can either type the compl" +
    "ete file path or choose the file using the Browse button.";
            // 
            // lblStep2
            // 
            this.lblStep2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStep2.Location = new System.Drawing.Point(417, 143);
            this.lblStep2.Name = "lblStep2";
            this.lblStep2.Size = new System.Drawing.Size(227, 70);
            this.lblStep2.TabIndex = 10;
            this.lblStep2.Text = "2. Open the selected file using the Open button. This will load the file for anal" +
    "ysis and populate the analysis results.";
            // 
            // lblStep4
            // 
            this.lblStep4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStep4.Location = new System.Drawing.Point(417, 216);
            this.lblStep4.Name = "lblStep4";
            this.lblStep4.Size = new System.Drawing.Size(227, 38);
            this.lblStep4.TabIndex = 11;
            this.lblStep4.Text = "3. You can save the analysis results using the Save button.";
            // 
            // lblNotes
            // 
            this.lblNotes.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNotes.Location = new System.Drawing.Point(417, 262);
            this.lblNotes.Name = "lblNotes";
            this.lblNotes.Size = new System.Drawing.Size(227, 84);
            this.lblNotes.TabIndex = 12;
            this.lblNotes.Text = "Repeat the above steps for analysis different files.\r\nNote: For errors and status" +
    " details, kindly view the message on the status bar at the bottom.";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(656, 444);
            this.Controls.Add(this.lblNotes);
            this.Controls.Add(this.lblStep4);
            this.Controls.Add(this.lblStep2);
            this.Controls.Add(this.lblStep1);
            this.Controls.Add(this.lblInstructionsHeader);
            this.Controls.Add(this.lblFilePath);
            this.Controls.Add(this.ctlAnalysisResultsListView);
            this.Controls.Add(this.ctlOpenFile);
            this.Controls.Add(this.ctlSaveFileAnalysis);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.ctlOpenFileBrowser);
            this.Controls.Add(this.ctlFilePath);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.OpenFileDialog ctlOpenFileDialog;
        private System.Windows.Forms.TextBox ctlFilePath;
        private System.Windows.Forms.Button ctlOpenFileBrowser;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel lblActivityStatusBar;
        private System.Windows.Forms.SaveFileDialog ctlSaveFileDialog;
        private System.Windows.Forms.Button ctlSaveFileAnalysis;
        private System.Windows.Forms.Button ctlOpenFile;
        private System.Windows.Forms.ListView ctlAnalysisResultsListView;
        private System.Windows.Forms.ColumnHeader columnAnalysisLabel;
        private System.Windows.Forms.ColumnHeader columnAnalysisResult;
        private System.Windows.Forms.Label lblFilePath;
        private System.Windows.Forms.Label lblInstructionsHeader;
        private System.Windows.Forms.Label lblStep1;
        private System.Windows.Forms.Label lblStep2;
        private System.Windows.Forms.Label lblStep4;
        private System.Windows.Forms.Label lblNotes;
    }
}

