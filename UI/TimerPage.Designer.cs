namespace TimeTable.UI
{
    partial class TimerPage
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
            label1 = new Label();
            button1 = new Button();
            button2 = new Button();
            button3 = new Button();
            SwitchModeButton = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.Font = new Font("Segoe UI", 80F);
            label1.Location = new Point(224, 180);
            label1.Name = "label1";
            label1.Size = new Size(400, 180);
            label1.TabIndex = 0;
            label1.Text = "99:59";
            // 
            // button1
            // 
            button1.Font = new Font("Segoe UI", 30F);
            button1.Location = new Point(189, 497);
            button1.Name = "button1";
            button1.Size = new Size(180, 98);
            button1.TabIndex = 1;
            button1.Text = "Stop";
            button1.UseVisualStyleBackColor = true;
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
            SwitchModeButton.Font = new Font("Segoe UI", 20F);
            SwitchModeButton.Location = new Point(299, 70);
            SwitchModeButton.Name = "SwitchModeButton";
            SwitchModeButton.Size = new Size(224, 63);
            SwitchModeButton.TabIndex = 4;
            SwitchModeButton.Text = "StopWatch";
            SwitchModeButton.UseVisualStyleBackColor = true;
            // 
            // TimerPage
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
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

        private Label label1;
        private Button button1;
        private Button button2;
        private Button button3;
        private Button SwitchModeButton;
    }
}
