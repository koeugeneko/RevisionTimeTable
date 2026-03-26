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
            lblProgress = new Label();
            dataGridView1 = new DataGridView();
            button2 = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // progressBar1
            // 
            progressBar1.ForeColor = Color.Black;
            progressBar1.Location = new Point(52, 110);
            progressBar1.Name = "progressBar1";
            progressBar1.Size = new Size(378, 29);
            progressBar1.TabIndex = 0;
            // 
            // lblProgress
            // 
            lblProgress.Font = new Font("Segoe UI", 10F);
            lblProgress.Location = new Point(52, 142);
            lblProgress.Name = "lblProgress";
            lblProgress.Size = new Size(400, 25);
            lblProgress.TabIndex = 5;
            lblProgress.Text = "0 of 0 tasks completed";
            lblProgress.ForeColor = Color.Gray;
            // 
            // lblDate
            // 
            lblDate.Font = new Font("Segoe UI", 12F);
            lblDate.Location = new Point(521, 110);
            lblDate.Name = "lblDate";
            lblDate.Size = new Size(295, 29);
            lblDate.TabIndex = 1;
            lblDate.Text = "00/00/0000, Friday";
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(52, 167);
            dataGridView1.Margin = new Padding(2);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.ReadOnly = true;
            dataGridView1.RowHeadersWidth = 62;
            dataGridView1.Size = new Size(726, 372);
            dataGridView1.TabIndex = 2;
            // 
            // button2
            // 
            button2.Location = new Point(557, 602);
            button2.Margin = new Padding(2);
            button2.Name = "button2";
            button2.Size = new Size(174, 67);
            button2.TabIndex = 4;
            button2.Text = "Regenrate daily plan";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // DailyTaskPage
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(button2);
            Controls.Add(dataGridView1);
            Controls.Add(lblProgress);
            Controls.Add(lblDate);
            Controls.Add(progressBar1);
            Name = "DailyTaskPage";
            Size = new Size(856, 721);
            Load += DailyTaskPage_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private ProgressBar progressBar1;
        private Label lblDate;
        private Label lblProgress;
        private DataGridView dataGridView1;
        private Button button2;
    }
}
