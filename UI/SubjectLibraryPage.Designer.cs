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
            SubjectNameColumn = new DataGridViewTextBoxColumn();
            AddNewSubject = new Button();
            panel1 = new Panel();
            button1 = new Button();
            addNewSubjectPage1 = new AddNewSubjectPage();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { SubjectNameColumn });
            dataGridView1.Location = new Point(44, 51);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(760, 359);
            dataGridView1.TabIndex = 0;
            // 
            // SubjectNameColumn
            // 
            SubjectNameColumn.HeaderText = "Subject name";
            SubjectNameColumn.MinimumWidth = 6;
            SubjectNameColumn.Name = "SubjectNameColumn";
            SubjectNameColumn.Width = 200;
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
            // panel1
            // 
            panel1.Controls.Add(addNewSubjectPage1);
            panel1.Location = new Point(274, 426);
            panel1.Name = "panel1";
            panel1.Size = new Size(530, 280);
            panel1.TabIndex = 2;
            // 
            // button1
            // 
            button1.Location = new Point(44, 548);
            button1.Name = "button1";
            button1.Size = new Size(192, 65);
            button1.TabIndex = 3;
            button1.Text = "Delete Subject";
            button1.UseVisualStyleBackColor = true;
            // 
            // addNewSubjectPage1
            // 
            addNewSubjectPage1.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            addNewSubjectPage1.Location = new Point(20, 46);
            addNewSubjectPage1.Name = "addNewSubjectPage1";
            addNewSubjectPage1.Size = new Size(1070, 901);
            addNewSubjectPage1.TabIndex = 0;
            // 
            // SubjectLibraryPage
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(button1);
            Controls.Add(panel1);
            Controls.Add(AddNewSubject);
            Controls.Add(dataGridView1);
            Name = "SubjectLibraryPage";
            Size = new Size(856, 721);
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            panel1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dataGridView1;
        private DataGridViewTextBoxColumn SubjectNameColumn;
        private Button AddNewSubject;
        private Panel panel1;
        private Button button1;
        private AddNewSubjectPage addNewSubjectPage1;
    }
}
