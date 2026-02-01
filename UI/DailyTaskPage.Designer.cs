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
            label1 = new Label();
            SuspendLayout();
            // 
            // progressBar1
            // 
            progressBar1.Location = new Point(52, 110);
            progressBar1.Name = "progressBar1";
            progressBar1.Size = new Size(378, 29);
            progressBar1.TabIndex = 0;
            // 
            // label1
            // 
            label1.Location = new Point(594, 101);
            label1.Name = "label1";
            label1.Size = new Size(113, 25);
            label1.TabIndex = 1;
            label1.Text = "label1";
            // 
            // DailyTaskPage
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(label1);
            Controls.Add(progressBar1);
            Name = "DailyTaskPage";
            Size = new Size(856, 721);
            ResumeLayout(false);
        }

        #endregion

        private ProgressBar progressBar1;
        private Label label1;
    }
}
