namespace TimeTable.UI
{
    partial class TimerPage
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
            labelTaskName = new Label();
            labelTaskTime = new Label();
            label1 = new Label();
            button1 = new Button();
            button2 = new Button();
            button3 = new Button();
            SwitchModeButton = new Button();
            SuspendLayout();
            // 
            // labelTaskName
            // 
            labelTaskName.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            labelTaskName.Location = new Point(50, 30);
            labelTaskName.Name = "labelTaskName";
            labelTaskName.Size = new Size(756, 50);
            labelTaskName.TabIndex = 5;
            labelTaskName.Text = "Task Name";
            labelTaskName.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // labelTaskTime
            // 
            labelTaskTime.Font = new Font("Segoe UI", 12F);
            labelTaskTime.Location = new Point(50, 85);
            labelTaskTime.Name = "labelTaskTime";
            labelTaskTime.Size = new Size(756, 30);
            labelTaskTime.TabIndex = 6;
            labelTaskTime.Text = "Estimated: 30 min";
            labelTaskTime.TextAlign = ContentAlignment.MiddleCenter;
            labelTaskTime.ForeColor = Color.Gray;
            // 
            // label1
            // 
            label1.Font = new Font("Segoe UI", 80F);
            label1.Location = new Point(224, 150);
            label1.Name = "label1";
            label1.Size = new Size(400, 180);
            label1.TabIndex = 0;
            label1.Text = "25:00";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // button1
            // 
            button1.Font = new Font("Segoe UI", 30F);
            button1.Location = new Point(189, 497);
            button1.Name = "button1";
            button1.Size = new Size(180, 98);
            button1.TabIndex = 1;
            button1.Text = "Reset";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Font = new Font("Segoe UI", 30F);
            button2.Location = new Point(483, 497);
            button2.Name = "button2";
            button2.Size = new Size(180, 98);
            button2.TabIndex = 2;
            button2.Text = "Start";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // button3
            // 
            button3.Font = new Font("Segoe UI", 20F);
            button3.Location = new Point(328, 417);
            button3.Name = "button3";
            button3.Size = new Size(217, 54);
            button3.TabIndex = 3;
            button3.Text = "Add 5 min";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // SwitchModeButton
            // 
            SwitchModeButton.Font = new Font("Segoe UI", 14F);
            SwitchModeButton.Location = new Point(300, 370);
            SwitchModeButton.Name = "SwitchModeButton";
            SwitchModeButton.Size = new Size(256, 40);
            SwitchModeButton.TabIndex = 4;
            SwitchModeButton.Text = "StopWatch Mode";
            SwitchModeButton.UseVisualStyleBackColor = true;
            // 
            // TimerPage
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(labelTaskTime);
            Controls.Add(labelTaskName);
            Controls.Add(SwitchModeButton);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(label1);
            Name = "TimerPage";
            Size = new Size(856, 721);
            ResumeLayout(false);
        }

        #endregion

        private Label labelTaskName;
        private Label labelTaskTime;
        private Label label1;
        private Button button1;
        private Button button2;
        private Button button3;
        private Button SwitchModeButton;
    }
}
