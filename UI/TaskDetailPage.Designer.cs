namespace TimeTable.UI
{
    partial class TaskDetailPage
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        private void InitializeComponent()
        {
            labelTitle = new Label();
            labelDescription = new Label();
            labelPriority = new Label();
            labelEstimatedTime = new Label();
            labelDueDate = new Label();
            textBoxDescription = new TextBox();
            numericUpDownPriority = new NumericUpDown();
            numericUpDownEstimatedTime = new NumericUpDown();
            dateTimePickerDueDate = new DateTimePicker();
            buttonSave = new Button();
            buttonBack = new Button();
            ((System.ComponentModel.ISupportInitialize)numericUpDownPriority).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownEstimatedTime).BeginInit();
            SuspendLayout();
            // 
            // labelTitle
            // 
            labelTitle.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
            labelTitle.Location = new Point(250, 30);
            labelTitle.Name = "labelTitle";
            labelTitle.Size = new Size(350, 50);
            labelTitle.TabIndex = 0;
            labelTitle.Text = "Task Details";
            labelTitle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // labelDescription
            // 
            labelDescription.Font = new Font("Segoe UI", 12F);
            labelDescription.Location = new Point(100, 120);
            labelDescription.Name = "labelDescription";
            labelDescription.Size = new Size(150, 30);
            labelDescription.TabIndex = 1;
            labelDescription.Text = "Description:";
            // 
            // labelPriority
            // 
            labelPriority.Font = new Font("Segoe UI", 12F);
            labelPriority.Location = new Point(100, 200);
            labelPriority.Name = "labelPriority";
            labelPriority.Size = new Size(150, 30);
            labelPriority.TabIndex = 2;
            labelPriority.Text = "Priority (1-3):";
            // 
            // labelEstimatedTime
            // 
            labelEstimatedTime.Font = new Font("Segoe UI", 12F);
            labelEstimatedTime.Location = new Point(100, 280);
            labelEstimatedTime.Name = "labelEstimatedTime";
            labelEstimatedTime.Size = new Size(180, 30);
            labelEstimatedTime.TabIndex = 3;
            labelEstimatedTime.Text = "Estimated Time (min):";
            // 
            // labelDueDate
            // 
            labelDueDate.Font = new Font("Segoe UI", 12F);
            labelDueDate.Location = new Point(100, 360);
            labelDueDate.Name = "labelDueDate";
            labelDueDate.Size = new Size(150, 30);
            labelDueDate.TabIndex = 4;
            labelDueDate.Text = "Due Date:";
            // 
            // textBoxDescription
            // 
            textBoxDescription.Font = new Font("Segoe UI", 12F);
            textBoxDescription.Location = new Point(300, 120);
            textBoxDescription.Multiline = true;
            textBoxDescription.Name = "textBoxDescription";
            textBoxDescription.Size = new Size(400, 60);
            textBoxDescription.TabIndex = 5;
            // 
            // numericUpDownPriority
            // 
            numericUpDownPriority.Font = new Font("Segoe UI", 12F);
            numericUpDownPriority.Location = new Point(300, 200);
            numericUpDownPriority.Maximum = new decimal(new int[] { 3, 0, 0, 0 });
            numericUpDownPriority.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numericUpDownPriority.Name = "numericUpDownPriority";
            numericUpDownPriority.Size = new Size(100, 30);
            numericUpDownPriority.TabIndex = 6;
            numericUpDownPriority.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // numericUpDownEstimatedTime
            // 
            numericUpDownEstimatedTime.Font = new Font("Segoe UI", 12F);
            numericUpDownEstimatedTime.Location = new Point(300, 280);
            numericUpDownEstimatedTime.Maximum = new decimal(new int[] { 480, 0, 0, 0 });
            numericUpDownEstimatedTime.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numericUpDownEstimatedTime.Name = "numericUpDownEstimatedTime";
            numericUpDownEstimatedTime.Size = new Size(100, 30);
            numericUpDownEstimatedTime.TabIndex = 7;
            numericUpDownEstimatedTime.Value = new decimal(new int[] { 30, 0, 0, 0 });
            // 
            // dateTimePickerDueDate
            // 
            dateTimePickerDueDate.Font = new Font("Segoe UI", 12F);
            dateTimePickerDueDate.Location = new Point(300, 360);
            dateTimePickerDueDate.Name = "dateTimePickerDueDate";
            dateTimePickerDueDate.Size = new Size(200, 30);
            dateTimePickerDueDate.TabIndex = 8;
            // 
            // buttonSave
            // 
            buttonSave.BackColor = System.Drawing.Color.LightGreen;
            buttonSave.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            buttonSave.Location = new Point(250, 450);
            buttonSave.Name = "buttonSave";
            buttonSave.Size = new Size(150, 50);
            buttonSave.TabIndex = 9;
            buttonSave.Text = "Save";
            buttonSave.UseVisualStyleBackColor = false;
            buttonSave.Click += buttonSave_Click;
            // 
            // buttonBack
            // 
            buttonBack.Font = new Font("Segoe UI", 14F);
            buttonBack.Location = new Point(450, 450);
            buttonBack.Name = "buttonBack";
            buttonBack.Size = new Size(150, 50);
            buttonBack.TabIndex = 10;
            buttonBack.Text = "Back";
            buttonBack.UseVisualStyleBackColor = true;
            buttonBack.Click += buttonBack_Click;
            // 
            // TaskDetailPage
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(buttonBack);
            Controls.Add(buttonSave);
            Controls.Add(dateTimePickerDueDate);
            Controls.Add(numericUpDownEstimatedTime);
            Controls.Add(numericUpDownPriority);
            Controls.Add(textBoxDescription);
            Controls.Add(labelDueDate);
            Controls.Add(labelEstimatedTime);
            Controls.Add(labelPriority);
            Controls.Add(labelDescription);
            Controls.Add(labelTitle);
            Name = "TaskDetailPage";
            Size = new Size(856, 721);
            ((System.ComponentModel.ISupportInitialize)numericUpDownPriority).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownEstimatedTime).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label labelTitle;
        private Label labelDescription;
        private Label labelPriority;
        private Label labelEstimatedTime;
        private Label labelDueDate;
        private TextBox textBoxDescription;
        private NumericUpDown numericUpDownPriority;
        private NumericUpDown numericUpDownEstimatedTime;
        private DateTimePicker dateTimePickerDueDate;
        private Button buttonSave;
        private Button buttonBack;
    }
}
