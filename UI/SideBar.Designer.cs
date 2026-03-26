namespace TimeTable.UI
{
    partial class SideBar
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
            DailyTaskButton = new Button();
            TaskLibraryButton = new Button();
            SubjectLibraryButton = new Button();
            ReportStatButton = new Button();
            SettingButton = new Button();
            SuspendLayout();
            // 
            // DailyTaskButton
            // 
            DailyTaskButton.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            DailyTaskButton.BackgroundImageLayout = ImageLayout.Zoom;
            DailyTaskButton.Location = new Point(18, 44);
            DailyTaskButton.Margin = new Padding(4);
            DailyTaskButton.Name = "DailyTaskButton";
            DailyTaskButton.Size = new Size(148, 112);
            DailyTaskButton.TabIndex = 0;
            DailyTaskButton.Text = "Daily task";
            DailyTaskButton.UseVisualStyleBackColor = true;
            DailyTaskButton.Click += DailyTaskButton_Click;
            // 
            // TaskLibraryButton
            // 
            TaskLibraryButton.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            TaskLibraryButton.BackgroundImageLayout = ImageLayout.Zoom;
            TaskLibraryButton.Location = new Point(18, 189);
            TaskLibraryButton.Margin = new Padding(4);
            TaskLibraryButton.Name = "TaskLibraryButton";
            TaskLibraryButton.RightToLeft = RightToLeft.No;
            TaskLibraryButton.Size = new Size(148, 112);
            TaskLibraryButton.TabIndex = 1;
            TaskLibraryButton.Text = "Task library";
            TaskLibraryButton.UseVisualStyleBackColor = true;
            TaskLibraryButton.Click += TaskLibraryButton_Click;
            // 
            // SubjectLibraryButton
            // 
            SubjectLibraryButton.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            SubjectLibraryButton.Location = new Point(18, 330);
            SubjectLibraryButton.Margin = new Padding(4);
            SubjectLibraryButton.Name = "SubjectLibraryButton";
            SubjectLibraryButton.Size = new Size(148, 112);
            SubjectLibraryButton.TabIndex = 2;
            SubjectLibraryButton.Text = "Subject library";
            SubjectLibraryButton.UseVisualStyleBackColor = true;
            SubjectLibraryButton.Click += SubjectLibraryButton_Click;
            // 
            // ReportStatButton
            // 
            ReportStatButton.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            ReportStatButton.BackgroundImageLayout = ImageLayout.Zoom;
            ReportStatButton.Location = new Point(18, 474);
            ReportStatButton.Margin = new Padding(4);
            ReportStatButton.Name = "ReportStatButton";
            ReportStatButton.RightToLeft = RightToLeft.No;
            ReportStatButton.Size = new Size(148, 112);
            ReportStatButton.TabIndex = 3;
            ReportStatButton.Text = "Report";
            ReportStatButton.UseVisualStyleBackColor = true;
            ReportStatButton.Click += ReportStatButton_Click;
            // 
            // SettingButton
            // 
            SettingButton.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            SettingButton.BackgroundImageLayout = ImageLayout.Zoom;
            SettingButton.Location = new Point(18, 629);
            SettingButton.Margin = new Padding(4);
            SettingButton.Name = "SettingButton";
            SettingButton.Size = new Size(148, 112);
            SettingButton.TabIndex = 4;
            SettingButton.Text = "Settings";
            SettingButton.UseVisualStyleBackColor = true;
            SettingButton.Click += SettingButton_Click;
            // 
            // SideBar
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(SettingButton);
            Controls.Add(ReportStatButton);
            Controls.Add(SubjectLibraryButton);
            Controls.Add(TaskLibraryButton);
            Controls.Add(DailyTaskButton);
            Margin = new Padding(2);
            Name = "SideBar";
            Size = new Size(188, 776);
            ResumeLayout(false);
        }

        #endregion

        private Button DailyTaskButton;
        private Button TaskLibraryButton;
        private Button SubjectLibraryButton;
        private Button ReportStatButton;
        private Button SettingButton;
    }
}
