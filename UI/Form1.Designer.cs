namespace TimeTable
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            panelMain = new Panel();
            panelSide = new Panel();
            panelSideTop = new Panel();
            panelSideBottom = new Panel();
            panelSide.SuspendLayout();
            SuspendLayout();
            // 
            // panelMain
            // 
            panelMain.BackColor = Color.Transparent;
            panelMain.Dock = DockStyle.Fill;
            panelMain.Location = new Point(150, 0);
            panelMain.Name = "panelMain";
            panelMain.Size = new Size(856, 721);
            panelMain.TabIndex = 0;
            // 
            // panelSide
            // 
            panelSide.BackColor = Color.Transparent;
            panelSide.Controls.Add(panelSideTop);
            panelSide.Controls.Add(panelSideBottom);
            panelSide.Dock = DockStyle.Left;
            panelSide.Location = new Point(0, 0);
            panelSide.Name = "panelSide";
            panelSide.Size = new Size(150, 721);
            panelSide.TabIndex = 1;
            // 
            // panelSideTop
            // 
            panelSideTop.BackColor = Color.Transparent;
            panelSideTop.Location = new Point(0, 0);
            panelSideTop.Margin = new Padding(2);
            panelSideTop.Name = "panelSideTop";
            panelSideTop.Size = new Size(150, 100);
            panelSideTop.TabIndex = 0;
            // 
            // panelSideBottom
            // 
            panelSideBottom.BackColor = Color.DimGray;
            panelSideBottom.Location = new Point(0, 100);
            panelSideBottom.Name = "panelSideBottom";
            panelSideBottom.Size = new Size(150, 621);
            panelSideBottom.TabIndex = 0;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1006, 721);
            Controls.Add(panelMain);
            Controls.Add(panelSide);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MaximumSize = new Size(1024, 768);
            MinimumSize = new Size(1024, 768);
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Revision Tracker";
            Load += Form1_Load;
            panelSide.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel panelMain;
        private Panel panelSide;
        private Panel panelSideTop;
        private Panel panelSideBottom;
    }
}
