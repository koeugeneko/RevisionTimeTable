namespace TimeTable.UI
{
    partial class SubjectLibraryPage
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
        /// contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            dataGridView1 = new DataGridView();
            AddNewSubject = new Button();
            button1 = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(44, 51);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.ReadOnly = true;
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(760, 359);
            dataGridView1.TabIndex = 0;
            // 
            // AddNewSubject
            // 
            AddNewSubject.Location = new Point(44, 452);
            AddNewSubject.Name = "AddNewSubject";
            AddNewSubject.Size = new Size(192, 65);
            AddNewSubject.TabIndex = 1;
            AddNewSubject.Text = "Add new subject";
            AddNewSubject.UseVisualStyleBackColor = true;
            AddNewSubject.Click += AddNewSubject_Click;
            // 
            // button1
            // 
            button1.Location = new Point(44, 548);
            button1.Name = "button1";
            button1.Size = new Size(192, 65);
            button1.TabIndex = 3;
            button1.Text = "Delete Subject";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // SubjectLibraryPage
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(button1);
            Controls.Add(AddNewSubject);
            Controls.Add(dataGridView1);
            Name = "SubjectLibraryPage";
            Size = new Size(856, 721);
            Load += SubjectLibraryPage_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dataGridView1;
        private Button AddNewSubject;
        private Button button1;
    }
}
