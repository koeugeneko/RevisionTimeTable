namespace TimeTable.UI
{
    partial class DailyTaskPage
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            progressBar1 = new ProgressBar();
            lblDate = new Label();
            SuspendLayout();
            // 
            // progressBar1
            // 
            progressBar1.Location = new Point(52, 110);
            progressBar1.Name = "progressBar1";
            progressBar1.Size = new Size(378, 29);
            progressBar1.TabIndex = 0;
            // 
            // lblDate
            // 
            lblDate.Location = new Point(563, 110);
            lblDate.Name = "lblDate";
            lblDate.Size = new Size(113, 25);
            lblDate.TabIndex = 1;
            lblDate.Text = "00/00/0000";
            // 
            // DailyTaskPage
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(lblDate);
            Controls.Add(progressBar1);
            Name = "DailyTaskPage";
            Size = new Size(856, 721);
            ResumeLayout(false);
        }

        #endregion

        private ProgressBar progressBar1;
        private Label lblDate;
    }
}
