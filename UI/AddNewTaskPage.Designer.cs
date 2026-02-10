namespace TimeTable.UI
{
    partial class AddNewTaskPage
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
            comboBoxSubject = new ComboBox();
            labelSubject = new Label();
            labelDescription = new Label();
            textBoxDescription = new TextBox();
            labelEstamiatedTime = new Label();
            labelPriority = new Label();
            monthCalendarDueDate = new MonthCalendar();
            numericUpDownPriority = new NumericUpDown();
            labelDueDate = new Label();
            buttonClear = new Button();
            buttonConfirm = new Button();
            dateTimePickerEstamiatedTime = new DateTimePicker();
            ((System.ComponentModel.ISupportInitialize)numericUpDownPriority).BeginInit();
            SuspendLayout();
            // 
            // comboBoxSubject
            // 
            comboBoxSubject.FormattingEnabled = true;
            comboBoxSubject.Location = new Point(212, 34);
            comboBoxSubject.Name = "comboBoxSubject";
            comboBoxSubject.Size = new Size(151, 28);
            comboBoxSubject.TabIndex = 0;
            comboBoxSubject.Click += comboBoxSubject_Click;
            // 
            // labelSubject
            // 
            labelSubject.AutoSize = true;
            labelSubject.Location = new Point(55, 37);
            labelSubject.Name = "labelSubject";
            labelSubject.Size = new Size(58, 20);
            labelSubject.TabIndex = 1;
            labelSubject.Text = "Subject";
            // 
            // labelDescription
            // 
            labelDescription.AutoSize = true;
            labelDescription.Location = new Point(55, 201);
            labelDescription.Name = "labelDescription";
            labelDescription.Size = new Size(85, 20);
            labelDescription.TabIndex = 2;
            labelDescription.Text = "Description";
            // 
            // textBoxDescription
            // 
            textBoxDescription.Location = new Point(212, 198);
            textBoxDescription.Multiline = true;
            textBoxDescription.Name = "textBoxDescription";
            textBoxDescription.Size = new Size(308, 187);
            textBoxDescription.TabIndex = 3;
            // 
            // labelEstamiatedTime
            // 
            labelEstamiatedTime.AutoSize = true;
            labelEstamiatedTime.Location = new Point(50, 92);
            labelEstamiatedTime.Name = "labelEstamiatedTime";
            labelEstamiatedTime.Size = new Size(117, 20);
            labelEstamiatedTime.TabIndex = 4;
            labelEstamiatedTime.Text = "Estamiated time";
            // 
            // labelPriority
            // 
            labelPriority.AutoSize = true;
            labelPriority.Location = new Point(55, 141);
            labelPriority.Name = "labelPriority";
            labelPriority.Size = new Size(56, 20);
            labelPriority.TabIndex = 6;
            labelPriority.Text = "Priority";
            // 
            // monthCalendarDueDate
            // 
            monthCalendarDueDate.Location = new Point(212, 407);
            monthCalendarDueDate.Name = "monthCalendarDueDate";
            monthCalendarDueDate.TabIndex = 7;
            // 
            // numericUpDownPriority
            // 
            numericUpDownPriority.Location = new Point(213, 141);
            numericUpDownPriority.Name = "numericUpDownPriority";
            numericUpDownPriority.Size = new Size(150, 27);
            numericUpDownPriority.TabIndex = 8;
            // 
            // labelDueDate
            // 
            labelDueDate.AutoSize = true;
            labelDueDate.Location = new Point(55, 407);
            labelDueDate.Name = "labelDueDate";
            labelDueDate.Size = new Size(72, 20);
            labelDueDate.TabIndex = 9;
            labelDueDate.Text = "Due Date";
            // 
            // buttonClear
            // 
            buttonClear.Location = new Point(500, 640);
            buttonClear.Name = "buttonClear";
            buttonClear.Size = new Size(158, 59);
            buttonClear.TabIndex = 10;
            buttonClear.Text = "Clear";
            buttonClear.UseVisualStyleBackColor = true;
            buttonClear.Click += buttonClear_Click;
            // 
            // buttonConfirm
            // 
            buttonConfirm.Location = new Point(677, 640);
            buttonConfirm.Name = "buttonConfirm";
            buttonConfirm.Size = new Size(158, 59);
            buttonConfirm.TabIndex = 11;
            buttonConfirm.Text = "Confirm";
            buttonConfirm.UseVisualStyleBackColor = true;
            buttonConfirm.Click += buttonConfirm_Click;
            // 
            // dateTimePickerEstamiatedTime
            // 
            dateTimePickerEstamiatedTime.CustomFormat = "HH:mm";
            dateTimePickerEstamiatedTime.Format = DateTimePickerFormat.Custom;
            dateTimePickerEstamiatedTime.Location = new Point(212, 87);
            dateTimePickerEstamiatedTime.Name = "dateTimePickerEstamiatedTime";
            dateTimePickerEstamiatedTime.ShowUpDown = true;
            dateTimePickerEstamiatedTime.Size = new Size(151, 27);
            dateTimePickerEstamiatedTime.TabIndex = 12;
            dateTimePickerEstamiatedTime.Value = new DateTime(2026, 2, 10, 0, 0, 0, 0);
            // 
            // AddNewTaskPage
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(dateTimePickerEstamiatedTime);
            Controls.Add(buttonConfirm);
            Controls.Add(buttonClear);
            Controls.Add(labelDueDate);
            Controls.Add(numericUpDownPriority);
            Controls.Add(monthCalendarDueDate);
            Controls.Add(labelPriority);
            Controls.Add(labelEstamiatedTime);
            Controls.Add(textBoxDescription);
            Controls.Add(labelDescription);
            Controls.Add(labelSubject);
            Controls.Add(comboBoxSubject);
            Name = "AddNewTaskPage";
            Size = new Size(856, 721);
            ((System.ComponentModel.ISupportInitialize)numericUpDownPriority).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox comboBoxSubject;
        private Label labelSubject;
        private Label labelDescription;
        private TextBox textBoxDescription;
        private Label labelEstamiatedTime;
        private Label labelPriority;
        private MonthCalendar monthCalendarDueDate;
        private NumericUpDown numericUpDownPriority;
        private Label labelDueDate;
        private Button buttonClear;
        private Button buttonConfirm;
        private DateTimePicker dateTimePickerEstamiatedTime;
    }
}
