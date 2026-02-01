namespace TimeTable.UI
{
    partial class SideBarTop
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
            minSideBarButton = new Button();
            SuspendLayout();
            // 
            // minSideBarButton
            // 
            minSideBarButton.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            minSideBarButton.Location = new Point(17, 10);
            minSideBarButton.Name = "minSideBarButton";
            minSideBarButton.Size = new Size(118, 70);
            minSideBarButton.TabIndex = 0;
            minSideBarButton.Text = ". . . ";
            minSideBarButton.UseVisualStyleBackColor = true;
            minSideBarButton.Click += MinSideBarButton_Click;
            // 
            // SideBarTop
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(minSideBarButton);
            Name = "SideBarTop";
            Size = new Size(150, 100);
            ResumeLayout(false);
        }

        #endregion

        private Button minSideBarButton;
    }
}
