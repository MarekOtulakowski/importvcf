namespace MSOutlookImportVCF
{
    partial class F_Main
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
            this.B_browse = new System.Windows.Forms.Button();
            this.L_pathInfo = new System.Windows.Forms.Label();
            this.PB_progress = new System.Windows.Forms.ProgressBar();
            this.TB_path = new System.Windows.Forms.TextBox();
            this.B_import = new System.Windows.Forms.Button();
            this.B_Abort = new System.Windows.Forms.Button();
            this.L_stat = new System.Windows.Forms.Label();
            this.L_advInfo = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // B_browse
            // 
            this.B_browse.Location = new System.Drawing.Point(205, 29);
            this.B_browse.Name = "B_browse";
            this.B_browse.Size = new System.Drawing.Size(75, 23);
            this.B_browse.TabIndex = 0;
            this.B_browse.Text = "Browse";
            this.B_browse.UseVisualStyleBackColor = true;
            this.B_browse.Click += new System.EventHandler(this.B_browse_Click);
            // 
            // L_pathInfo
            // 
            this.L_pathInfo.AutoSize = true;
            this.L_pathInfo.Location = new System.Drawing.Point(12, 15);
            this.L_pathInfo.Name = "L_pathInfo";
            this.L_pathInfo.Size = new System.Drawing.Size(85, 13);
            this.L_pathInfo.TabIndex = 1;
            this.L_pathInfo.Text = "Path to VCF files";
            // 
            // PB_progress
            // 
            this.PB_progress.Location = new System.Drawing.Point(12, 66);
            this.PB_progress.Name = "PB_progress";
            this.PB_progress.Size = new System.Drawing.Size(268, 11);
            this.PB_progress.TabIndex = 2;
            // 
            // TB_path
            // 
            this.TB_path.Location = new System.Drawing.Point(12, 31);
            this.TB_path.Name = "TB_path";
            this.TB_path.Size = new System.Drawing.Size(186, 20);
            this.TB_path.TabIndex = 3;
            // 
            // B_import
            // 
            this.B_import.Location = new System.Drawing.Point(49, 95);
            this.B_import.Name = "B_import";
            this.B_import.Size = new System.Drawing.Size(75, 23);
            this.B_import.TabIndex = 4;
            this.B_import.Text = "Import";
            this.B_import.UseVisualStyleBackColor = true;
            this.B_import.Click += new System.EventHandler(this.B_import_Click);
            // 
            // B_Abort
            // 
            this.B_Abort.Location = new System.Drawing.Point(163, 95);
            this.B_Abort.Name = "B_Abort";
            this.B_Abort.Size = new System.Drawing.Size(75, 23);
            this.B_Abort.TabIndex = 5;
            this.B_Abort.Text = "Abort";
            this.B_Abort.UseVisualStyleBackColor = true;
            this.B_Abort.Click += new System.EventHandler(this.B_abort_Click);
            // 
            // L_stat
            // 
            this.L_stat.AutoSize = true;
            this.L_stat.Location = new System.Drawing.Point(12, 123);
            this.L_stat.Name = "L_stat";
            this.L_stat.Size = new System.Drawing.Size(53, 13);
            this.L_stat.TabIndex = 6;
            this.L_stat.Text = "No action";
            // 
            // L_advInfo
            // 
            this.L_advInfo.AutoSize = true;
            this.L_advInfo.Location = new System.Drawing.Point(12, 143);
            this.L_advInfo.Name = "L_advInfo";
            this.L_advInfo.Size = new System.Drawing.Size(10, 13);
            this.L_advInfo.TabIndex = 7;
            this.L_advInfo.Text = ".";
            // 
            // F_Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(292, 169);
            this.Controls.Add(this.L_advInfo);
            this.Controls.Add(this.L_stat);
            this.Controls.Add(this.B_Abort);
            this.Controls.Add(this.B_import);
            this.Controls.Add(this.TB_path);
            this.Controls.Add(this.PB_progress);
            this.Controls.Add(this.L_pathInfo);
            this.Controls.Add(this.B_browse);
            this.Name = "F_Main";
            this.Text = "Import VCF to MS Outlook v.1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button B_browse;
        private System.Windows.Forms.Label L_pathInfo;
        private System.Windows.Forms.ProgressBar PB_progress;
        private System.Windows.Forms.TextBox TB_path;
        private System.Windows.Forms.Button B_import;
        private System.Windows.Forms.Button B_Abort;
        private System.Windows.Forms.Label L_stat;
        private System.Windows.Forms.Label L_advInfo;
    }
}

