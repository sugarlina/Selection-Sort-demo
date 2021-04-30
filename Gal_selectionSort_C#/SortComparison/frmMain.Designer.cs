namespace SortComparison
{
    partial class frmMain
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
            this.cmdSort = new System.Windows.Forms.Button();
            this.pnlSort1 = new System.Windows.Forms.PictureBox();
            this.lblSamples = new System.Windows.Forms.Label();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.textBox1 = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.pnlSort1)).BeginInit();
            this.SuspendLayout();
            // 
            // cmdSort
            // 
            this.cmdSort.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.cmdSort.Location = new System.Drawing.Point(344, 312);
            this.cmdSort.Name = "cmdSort";
            this.cmdSort.Size = new System.Drawing.Size(75, 23);
            this.cmdSort.TabIndex = 5;
            this.cmdSort.Text = "Sort";
            this.cmdSort.UseVisualStyleBackColor = true;
            this.cmdSort.Click += new System.EventHandler(this.cmdSort_Click);
            // 
            // pnlSort1
            // 
            this.pnlSort1.BackColor = System.Drawing.Color.White;
            this.pnlSort1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlSort1.Location = new System.Drawing.Point(13, 12);
            this.pnlSort1.Name = "pnlSort1";
            this.pnlSort1.Size = new System.Drawing.Size(406, 240);
            this.pnlSort1.TabIndex = 6;
            this.pnlSort1.TabStop = false;
            // 
            // lblSamples
            // 
            this.lblSamples.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.lblSamples.AutoSize = true;
            this.lblSamples.Location = new System.Drawing.Point(10, 256);
            this.lblSamples.Name = "lblSamples";
            this.lblSamples.Size = new System.Drawing.Size(0, 13);
            this.lblSamples.TabIndex = 9;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(13, 271);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(406, 20);
            this.textBox1.TabIndex = 35;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(434, 347);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.lblSamples);
            this.Controls.Add(this.cmdSort);
            this.Controls.Add(this.pnlSort1);
            this.MaximumSize = new System.Drawing.Size(10000, 10000);
            this.MinimumSize = new System.Drawing.Size(450, 386);
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Selection Sort Demo";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmMain_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Resize += new System.EventHandler(this.frmMain_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.pnlSort1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button cmdSort;
        private System.Windows.Forms.PictureBox pnlSort1;
        private System.Windows.Forms.Label lblSamples;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.TextBox textBox1;
    }
}

