﻿namespace Primes_Computation_Mulithreaded
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblProgress = new System.Windows.Forms.Label();
            this.progressBar2 = new System.Windows.Forms.ProgressBar();
            this.lblFactorsProgress = new System.Windows.Forms.Label();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.lblMsg = new System.Windows.Forms.Label();
            this.lstViewResults = new System.Windows.Forms.ListView();
            this.colNumber = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colFactors = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnCompute = new System.Windows.Forms.Button();
            this.msktxtLowerBound = new System.Windows.Forms.MaskedTextBox();
            this.msktxtUpperBound = new System.Windows.Forms.MaskedTextBox();
            this.lblLowerBound = new System.Windows.Forms.Label();
            this.lblUpperBound = new System.Windows.Forms.Label();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lblProgress);
            this.panel1.Controls.Add(this.progressBar2);
            this.panel1.Controls.Add(this.lblFactorsProgress);
            this.panel1.Controls.Add(this.progressBar1);
            this.panel1.Controls.Add(this.lblMsg);
            this.panel1.Controls.Add(this.lstViewResults);
            this.panel1.Controls.Add(this.btnCompute);
            this.panel1.Controls.Add(this.msktxtLowerBound);
            this.panel1.Controls.Add(this.msktxtUpperBound);
            this.panel1.Controls.Add(this.lblLowerBound);
            this.panel1.Controls.Add(this.lblUpperBound);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(666, 725);
            this.panel1.TabIndex = 0;
            // 
            // lblProgress
            // 
            this.lblProgress.AutoSize = true;
            this.lblProgress.Location = new System.Drawing.Point(33, 343);
            this.lblProgress.Name = "lblProgress";
            this.lblProgress.Size = new System.Drawing.Size(101, 13);
            this.lblProgress.TabIndex = 14;
            this.lblProgress.Text = "Primes List Progress";
            // 
            // progressBar2
            // 
            this.progressBar2.Location = new System.Drawing.Point(36, 441);
            this.progressBar2.Name = "progressBar2";
            this.progressBar2.Size = new System.Drawing.Size(189, 15);
            this.progressBar2.TabIndex = 13;
            // 
            // lblFactorsProgress
            // 
            this.lblFactorsProgress.AutoSize = true;
            this.lblFactorsProgress.Location = new System.Drawing.Point(33, 425);
            this.lblFactorsProgress.Name = "lblFactorsProgress";
            this.lblFactorsProgress.Size = new System.Drawing.Size(111, 13);
            this.lblFactorsProgress.TabIndex = 12;
            this.lblFactorsProgress.Text = "Factorisation Progress";
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(36, 359);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(189, 15);
            this.progressBar1.TabIndex = 9;
            // 
            // lblMsg
            // 
            this.lblMsg.AutoSize = true;
            this.lblMsg.Location = new System.Drawing.Point(33, 278);
            this.lblMsg.Name = "lblMsg";
            this.lblMsg.Size = new System.Drawing.Size(37, 13);
            this.lblMsg.TabIndex = 8;
            this.lblMsg.Text = "Status";
            this.lblMsg.Visible = false;
            // 
            // lstViewResults
            // 
            this.lstViewResults.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colNumber,
            this.colFactors});
            this.lstViewResults.HideSelection = false;
            this.lstViewResults.Location = new System.Drawing.Point(332, 73);
            this.lstViewResults.Name = "lstViewResults";
            this.lstViewResults.Size = new System.Drawing.Size(308, 564);
            this.lstViewResults.TabIndex = 7;
            this.lstViewResults.UseCompatibleStateImageBehavior = false;
            this.lstViewResults.View = System.Windows.Forms.View.Details;
            // 
            // colNumber
            // 
            this.colNumber.Text = "Number";
            this.colNumber.Width = 86;
            // 
            // colFactors
            // 
            this.colFactors.Text = "Factors";
            this.colFactors.Width = 203;
            // 
            // btnCompute
            // 
            this.btnCompute.Location = new System.Drawing.Point(36, 160);
            this.btnCompute.Name = "btnCompute";
            this.btnCompute.Size = new System.Drawing.Size(100, 40);
            this.btnCompute.TabIndex = 6;
            this.btnCompute.Text = "Compute";
            this.btnCompute.UseVisualStyleBackColor = true;
            this.btnCompute.Click += new System.EventHandler(this.btnCompute_Click);
            // 
            // msktxtLowerBound
            // 
            this.msktxtLowerBound.Location = new System.Drawing.Point(109, 109);
            this.msktxtLowerBound.Mask = "000000000000000000";
            this.msktxtLowerBound.Name = "msktxtLowerBound";
            this.msktxtLowerBound.Size = new System.Drawing.Size(116, 20);
            this.msktxtLowerBound.TabIndex = 5;
            // 
            // msktxtUpperBound
            // 
            this.msktxtUpperBound.Location = new System.Drawing.Point(109, 73);
            this.msktxtUpperBound.Mask = "000000000000000000";
            this.msktxtUpperBound.Name = "msktxtUpperBound";
            this.msktxtUpperBound.Size = new System.Drawing.Size(116, 20);
            this.msktxtUpperBound.TabIndex = 4;
            // 
            // lblLowerBound
            // 
            this.lblLowerBound.AutoSize = true;
            this.lblLowerBound.Location = new System.Drawing.Point(33, 112);
            this.lblLowerBound.Name = "lblLowerBound";
            this.lblLowerBound.Size = new System.Drawing.Size(70, 13);
            this.lblLowerBound.TabIndex = 1;
            this.lblLowerBound.Text = "Lower Bound";
            // 
            // lblUpperBound
            // 
            this.lblUpperBound.AutoSize = true;
            this.lblUpperBound.Location = new System.Drawing.Point(33, 76);
            this.lblUpperBound.Name = "lblUpperBound";
            this.lblUpperBound.Size = new System.Drawing.Size(70, 13);
            this.lblUpperBound.TabIndex = 0;
            this.lblUpperBound.Text = "Upper Bound";
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgWorkerDoWork_Compute);
            this.backgroundWorker1.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorker1_ProgressChanged);
            this.backgroundWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted);
            // 
            // Form1
            // 
            this.AcceptButton = this.btnCompute;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(690, 749);
            this.Controls.Add(this.panel1);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MultiThreaded Computation";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.MaskedTextBox msktxtLowerBound;
        private System.Windows.Forms.MaskedTextBox msktxtUpperBound;
        private System.Windows.Forms.Label lblLowerBound;
        private System.Windows.Forms.Label lblUpperBound;
        private System.Windows.Forms.Button btnCompute;
        private System.Windows.Forms.ListView lstViewResults;
        private System.Windows.Forms.ColumnHeader colNumber;
        private System.Windows.Forms.ColumnHeader colFactors;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Label lblMsg;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.ProgressBar progressBar2;
        private System.Windows.Forms.Label lblFactorsProgress;
        private System.Windows.Forms.Label lblProgress;
    }
}

