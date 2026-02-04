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
            dataGridView1 = new DataGridView();
            button1 = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // progressBar1
            // 
            progressBar1.Location = new Point(65, 138);
            progressBar1.Margin = new Padding(4, 4, 4, 4);
            progressBar1.Name = "progressBar1";
            progressBar1.Size = new Size(472, 36);
            progressBar1.TabIndex = 0;
            progressBar1.Click += progressBar1_Click;
            // 
            // lblDate
            // 
            lblDate.Font = new Font("Segoe UI", 12F);
            lblDate.Location = new Point(689, 138);
            lblDate.Margin = new Padding(4, 0, 4, 0);
            lblDate.Name = "lblDate";
            lblDate.Size = new Size(235, 31);
            lblDate.TabIndex = 1;
            lblDate.Text = "00/00/0000, wed";
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(65, 209);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 62;
            dataGridView1.Size = new Size(859, 488);
            dataGridView1.TabIndex = 2;
            // 
            // button1
            // 
            button1.Location = new Point(79, 747);
            button1.Name = "button1";
            button1.Size = new Size(218, 84);
            button1.TabIndex = 3;
            button1.Text = "Add emergcy task";
            button1.UseVisualStyleBackColor = true;
            // 
            // DailyTaskPage
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(button1);
            Controls.Add(dataGridView1);
            Controls.Add(lblDate);
            Controls.Add(progressBar1);
            Margin = new Padding(4, 4, 4, 4);
            Name = "DailyTaskPage";
            Size = new Size(1070, 901);
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private ProgressBar progressBar1;
        private Label lblDate;
        private DataGridView dataGridView1;
        private Button button1;
    }
}
