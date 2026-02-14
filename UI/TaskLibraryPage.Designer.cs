namespace TimeTable.UI
{
    partial class TaskLibraryPage
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
            AddNewTask = new Button();
            DeleteTaskButton = new Button();
            EditTaskButton = new Button();
            button2 = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(44, 43);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.ReadOnly = true;
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(773, 348);
            dataGridView1.TabIndex = 0;
            // 
            // AddNewTask
            // 
            AddNewTask.Location = new Point(44, 426);
            AddNewTask.Name = "AddNewTask";
            AddNewTask.Size = new Size(192, 65);
            AddNewTask.TabIndex = 2;
            AddNewTask.Text = "Add new task";
            AddNewTask.UseVisualStyleBackColor = true;
            AddNewTask.Click += AddNewTask_Click;
            // 
            // DeleteTaskButton
            // 
            DeleteTaskButton.Location = new Point(44, 610);
            DeleteTaskButton.Name = "DeleteTaskButton";
            DeleteTaskButton.Size = new Size(192, 65);
            DeleteTaskButton.TabIndex = 3;
            DeleteTaskButton.Text = "DeleteTask";
            DeleteTaskButton.UseVisualStyleBackColor = true;
            // 
            // EditTaskButton
            // 
            EditTaskButton.Location = new Point(44, 518);
            EditTaskButton.Name = "EditTaskButton";
            EditTaskButton.Size = new Size(192, 65);
            EditTaskButton.TabIndex = 4;
            EditTaskButton.Text = "Edit task";
            EditTaskButton.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            button2.Location = new Point(625, 426);
            button2.Name = "button2";
            button2.Size = new Size(192, 65);
            button2.TabIndex = 5;
            button2.Text = "Refersh";
            button2.UseVisualStyleBackColor = true;
            button2.Click += TaskLibraryPage_Load;
            // 
            // TaskLibraryPage
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(button2);
            Controls.Add(EditTaskButton);
            Controls.Add(DeleteTaskButton);
            Controls.Add(AddNewTask);
            Controls.Add(dataGridView1);
            Name = "TaskLibraryPage";
            Size = new Size(856, 721);
            Load += TaskLibraryPage_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dataGridView1;
        private Button AddNewTask;
        private Button DeleteTaskButton;
        private Button EditTaskButton;
        private Button button2;
    }
}
