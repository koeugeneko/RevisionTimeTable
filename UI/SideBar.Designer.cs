namespace TimeTable.UI
{
    partial class SideBar
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
            DailyTaskButton.Location = new Point(14, 35);
            DailyTaskButton.Name = "DailyTaskButton";
            DailyTaskButton.Size = new Size(118, 90);
            DailyTaskButton.TabIndex = 0;
            DailyTaskButton.Text = "Daily task";
            DailyTaskButton.UseVisualStyleBackColor = true;
            DailyTaskButton.Click += DailyTaskButton_Click;
            //
            // TaskLibraryButton
            //
            TaskLibraryButton.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            TaskLibraryButton.BackgroundImageLayout = ImageLayout.Zoom;
            TaskLibraryButton.Location = new Point(14, 151);
            TaskLibraryButton.Name = "TaskLibraryButton";
            TaskLibraryButton.RightToLeft = RightToLeft.No;
            TaskLibraryButton.Size = new Size(118, 90);
            TaskLibraryButton.TabIndex = 1;
            TaskLibraryButton.Text = "Task library";
            TaskLibraryButton.UseVisualStyleBackColor = true;
            TaskLibraryButton.Click += TaskLibraryButton_Click;
            //
            // SubjectLibraryButton
            //
            SubjectLibraryButton.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            SubjectLibraryButton.Location = new Point(14, 264);
            SubjectLibraryButton.Name = "SubjectLibraryButton";
            SubjectLibraryButton.Size = new Size(118, 90);
            SubjectLibraryButton.TabIndex = 2;
            SubjectLibraryButton.Text = "Subject library";
            SubjectLibraryButton.UseVisualStyleBackColor = true;
            SubjectLibraryButton.Click += SubjectLibraryButton_Click;
            // 
            // ReportStatButton
            // 
            ReportStatButton.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            ReportStatButton.BackgroundImageLayout = ImageLayout.Zoom;
            ReportStatButton.Location = new Point(14, 379);
            ReportStatButton.Name = "ReportStatButton";
            ReportStatButton.RightToLeft = RightToLeft.No;
            ReportStatButton.Size = new Size(118, 90);
            ReportStatButton.TabIndex = 3;
            ReportStatButton.Text = "Stats";
            ReportStatButton.UseVisualStyleBackColor = true;
            ReportStatButton.Click += ReportStatButton_Click;
            // 
            // SettingButton
            // 
            SettingButton.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            SettingButton.BackgroundImageLayout = ImageLayout.Zoom;
            SettingButton.Location = new Point(14, 503);
            SettingButton.Name = "SettingButton";
            SettingButton.Size = new Size(118, 90);
            SettingButton.TabIndex = 4;
            SettingButton.Text = "Settings";
            SettingButton.UseVisualStyleBackColor = true;
            SettingButton.Click += SettingButton_Click;
            // 
            // SideBar
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(SettingButton);
            Controls.Add(ReportStatButton);
            Controls.Add(SubjectLibraryButton);
            Controls.Add(TaskLibraryButton);
            Controls.Add(DailyTaskButton);
            Margin = new Padding(2);
            Name = "SideBar";
            Size = new Size(150, 621);
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
