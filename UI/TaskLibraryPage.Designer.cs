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
            SubjectColumn = new DataGridViewTextBoxColumn();
            DescriptionColumn = new DataGridViewTextBoxColumn();
            EstimatedTimeColumn = new DataGridViewTextBoxColumn();
            DueDateColumn = new DataGridViewTextBoxColumn();
            PriorityColumn = new DataGridViewTextBoxColumn();
            StatsColumn = new DataGridViewCheckBoxColumn();
            AddNewTask = new Button();
            DeleteTaskButton = new Button();
            EditTaskButton = new Button();
            panel1 = new Panel();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { SubjectColumn, DescriptionColumn, EstimatedTimeColumn, DueDateColumn, PriorityColumn, StatsColumn });
            dataGridView1.Location = new Point(55, 54);
            dataGridView1.Margin = new Padding(4, 4, 4, 4);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(966, 435);
            dataGridView1.TabIndex = 0;
            dataGridView1.CellContentClick += dataGridView1_CellContentClick;
            // 
            // SubjectColumn
            // 
            SubjectColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            SubjectColumn.HeaderText = "Subject";
            SubjectColumn.MinimumWidth = 6;
            SubjectColumn.Name = "SubjectColumn";
            // 
            // DescriptionColumn
            // 
            DescriptionColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            DescriptionColumn.HeaderText = "Description";
            DescriptionColumn.MinimumWidth = 6;
            DescriptionColumn.Name = "DescriptionColumn";
            // 
            // EstimatedTimeColumn
            // 
            EstimatedTimeColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            EstimatedTimeColumn.HeaderText = "Time";
            EstimatedTimeColumn.MinimumWidth = 6;
            EstimatedTimeColumn.Name = "EstimatedTimeColumn";
            // 
            // DueDateColumn
            // 
            DueDateColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            DueDateColumn.HeaderText = "Due Date";
            DueDateColumn.MinimumWidth = 6;
            DueDateColumn.Name = "DueDateColumn";
            // 
            // PriorityColumn
            // 
            PriorityColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            PriorityColumn.HeaderText = "Priority";
            PriorityColumn.MinimumWidth = 6;
            PriorityColumn.Name = "PriorityColumn";
            // 
            // StatsColumn
            // 
            StatsColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            StatsColumn.HeaderText = "Stats";
            StatsColumn.MinimumWidth = 6;
            StatsColumn.Name = "StatsColumn";
            // 
            // AddNewTask
            // 
            AddNewTask.Location = new Point(55, 532);
            AddNewTask.Margin = new Padding(4);
            AddNewTask.Name = "AddNewTask";
            AddNewTask.Size = new Size(240, 81);
            AddNewTask.TabIndex = 2;
            AddNewTask.Text = "Add new task";
            AddNewTask.UseVisualStyleBackColor = true;
            // 
            // DeleteTaskButton
            // 
            DeleteTaskButton.Location = new Point(55, 763);
            DeleteTaskButton.Margin = new Padding(4);
            DeleteTaskButton.Name = "DeleteTaskButton";
            DeleteTaskButton.Size = new Size(240, 81);
            DeleteTaskButton.TabIndex = 3;
            DeleteTaskButton.Text = "DeleteTask";
            DeleteTaskButton.UseVisualStyleBackColor = true;
            // 
            // EditTaskButton
            // 
            EditTaskButton.Location = new Point(55, 648);
            EditTaskButton.Margin = new Padding(4);
            EditTaskButton.Name = "EditTaskButton";
            EditTaskButton.Size = new Size(240, 81);
            EditTaskButton.TabIndex = 4;
            EditTaskButton.Text = "Edit task";
            EditTaskButton.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            panel1.Location = new Point(346, 512);
            panel1.Name = "panel1";
            panel1.Size = new Size(675, 332);
            panel1.TabIndex = 5;
            // 
            // TaskLibraryPage
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(panel1);
            Controls.Add(EditTaskButton);
            Controls.Add(DeleteTaskButton);
            Controls.Add(AddNewTask);
            Controls.Add(dataGridView1);
            Margin = new Padding(4, 4, 4, 4);
            Name = "TaskLibraryPage";
            Size = new Size(1070, 901);
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dataGridView1;
        private DataGridViewTextBoxColumn SubjectColumn;
        private DataGridViewTextBoxColumn DescriptionColumn;
        private DataGridViewTextBoxColumn EstimatedTimeColumn;
        private DataGridViewTextBoxColumn DueDateColumn;
        private DataGridViewTextBoxColumn PriorityColumn;
        private DataGridViewCheckBoxColumn StatsColumn;
        private Button AddNewTask;
        private Button DeleteTaskButton;
        private Button EditTaskButton;
        private Panel panel1;
    }
}
