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
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { SubjectNameColumn });
            dataGridView1.Location = new Point(55, 64);
            dataGridView1.Margin = new Padding(4, 4, 4, 4);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(950, 449);
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
            AddNewSubject.Location = new Point(55, 565);
            AddNewSubject.Margin = new Padding(4, 4, 4, 4);
            AddNewSubject.Name = "AddNewSubject";
            AddNewSubject.Size = new Size(240, 81);
            AddNewSubject.TabIndex = 1;
            AddNewSubject.Text = "Add new subject";
            AddNewSubject.UseVisualStyleBackColor = true;
            AddNewSubject.Click += AddNewSubject_Click;
            // 
            // panel1
            // 
            panel1.Location = new Point(348, 537);
            panel1.Margin = new Padding(4, 4, 4, 4);
            panel1.Name = "panel1";
            panel1.Size = new Size(657, 345);
            panel1.TabIndex = 2;
            // 
            // button1
            // 
            button1.Location = new Point(55, 685);
            button1.Margin = new Padding(4, 4, 4, 4);
            button1.Name = "button1";
            button1.Size = new Size(240, 81);
            button1.TabIndex = 3;
            button1.Text = "Delete Subject";
            button1.UseVisualStyleBackColor = true;
            // 
            // SubjectLibraryPage
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(button1);
            Controls.Add(panel1);
            Controls.Add(AddNewSubject);
            Controls.Add(dataGridView1);
            Margin = new Padding(4, 4, 4, 4);
            Name = "SubjectLibraryPage";
            Size = new Size(1070, 901);
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dataGridView1;
        private DataGridViewTextBoxColumn SubjectNameColumn;
        private Button AddNewSubject;
        private Panel panel1;
        private Button button1;
    }
}
