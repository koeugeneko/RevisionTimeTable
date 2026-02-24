namespace TimeTable.UI
{
    partial class SettingsPage
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
            label3 = new Label();
            Userlabel = new Label();
            button1 = new Button();
            button2 = new Button();
            DelectAccountButton = new Button();
            label7 = new Label();
            label8 = new Label();
            checkBox1 = new CheckBox();
            numericUpDown1 = new NumericUpDown();
            label6 = new Label();
            comboBox1 = new ComboBox();
            numericUpDown2 = new NumericUpDown();
            label9 = new Label();
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown2).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.Font = new Font("Segoe UI", 10F);
            label1.Location = new Point(41, 42);
            label1.Name = "label1";
            label1.Size = new Size(188, 39);
            label1.TabIndex = 0;
            label1.Text = "Task limit per day:";
            // 
            // label3
            // 
            label3.Font = new Font("Segoe UI", 10F);
            label3.Location = new Point(41, 282);
            label3.Name = "label3";
            label3.Size = new Size(250, 40);
            label3.TabIndex = 5;
            label3.Text = "Task reminder";
            // 
            // Userlabel
            // 
            Userlabel.Font = new Font("Segoe UI", 10F);
            Userlabel.Location = new Point(41, 376);
            Userlabel.Name = "Userlabel";
            Userlabel.Size = new Size(188, 25);
            Userlabel.TabIndex = 6;
            Userlabel.Text = "User: Eugene";
            // 
            // button1
            // 
            button1.Location = new Point(41, 419);
            button1.Name = "button1";
            button1.Size = new Size(166, 35);
            button1.TabIndex = 7;
            button1.Text = "Change my pasword";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Location = new Point(224, 419);
            button2.Name = "button2";
            button2.Size = new Size(166, 35);
            button2.TabIndex = 8;
            button2.Text = "Sign out";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // DelectAccountButton
            // 
            DelectAccountButton.Location = new Point(423, 419);
            DelectAccountButton.Name = "DelectAccountButton";
            DelectAccountButton.Size = new Size(166, 35);
            DelectAccountButton.TabIndex = 9;
            DelectAccountButton.Text = "Delete account";
            DelectAccountButton.UseVisualStyleBackColor = true;
            DelectAccountButton.Click += DelectAccountButton_Click;
            // 
            // label7
            // 
            label7.Font = new Font("Segoe UI", 10F);
            label7.Location = new Point(41, 638);
            label7.Name = "label7";
            label7.Size = new Size(188, 33);
            label7.TabIndex = 12;
            label7.Text = "Version: 1.0.0";
            // 
            // label8
            // 
            label8.Font = new Font("Segoe UI", 10F);
            label8.Location = new Point(41, 671);
            label8.Name = "label8";
            label8.Size = new Size(502, 33);
            label8.TabIndex = 13;
            label8.Text = "Developer: Eugene (A level NEA)";
            // 
            // checkBox1
            // 
            checkBox1.Location = new Point(243, 289);
            checkBox1.Name = "checkBox1";
            checkBox1.Size = new Size(126, 30);
            checkBox1.TabIndex = 17;
            checkBox1.UseVisualStyleBackColor = true;
            // 
            // numericUpDown1
            // 
            numericUpDown1.Location = new Point(239, 42);
            numericUpDown1.Maximum = new decimal(new int[] { 5, 0, 0, 0 });
            numericUpDown1.Name = "numericUpDown1";
            numericUpDown1.Size = new Size(150, 27);
            numericUpDown1.TabIndex = 18;
            numericUpDown1.ValueChanged += numericUpDown1_ValueChanged;
            // 
            // label6
            // 
            label6.Font = new Font("Segoe UI", 10F);
            label6.Location = new Point(41, 163);
            label6.Name = "label6";
            label6.Size = new Size(153, 30);
            label6.TabIndex = 19;
            label6.Text = "Region:";
            // 
            // comboBox1
            // 
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(238, 166);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(151, 28);
            comboBox1.TabIndex = 20;
            // 
            // numericUpDown2
            // 
            numericUpDown2.Location = new Point(243, 99);
            numericUpDown2.Maximum = new decimal(new int[] { 5, 0, 0, 0 });
            numericUpDown2.Name = "numericUpDown2";
            numericUpDown2.Size = new Size(150, 27);
            numericUpDown2.TabIndex = 22;
            numericUpDown2.ValueChanged += numericUpDown2_ValueChanged;
            // 
            // label9
            // 
            label9.Font = new Font("Segoe UI", 10F);
            label9.Location = new Point(41, 98);
            label9.Name = "label9";
            label9.Size = new Size(188, 50);
            label9.TabIndex = 21;
            label9.Text = "Task limit on hoilday and week end:";
            // 
            // SettingsPage
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(numericUpDown2);
            Controls.Add(label9);
            Controls.Add(comboBox1);
            Controls.Add(label6);
            Controls.Add(numericUpDown1);
            Controls.Add(checkBox1);
            Controls.Add(label8);
            Controls.Add(label7);
            Controls.Add(DelectAccountButton);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(Userlabel);
            Controls.Add(label3);
            Controls.Add(label1);
            Name = "SettingsPage";
            Size = new Size(856, 721);
            Load += SettingsPage_Load;
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown2).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Label label1;
        private Label label3;
        private Label Userlabel;
        private Button button1;
        private Button button2;
        private Button DelectAccountButton;
        private Label label7;
        private Label label8;
        private CheckBox checkBox1;
        private NumericUpDown numericUpDown1;
        private Label label6;
        private ComboBox comboBox1;
        private NumericUpDown numericUpDown2;
        private Label label9;
    }
}
