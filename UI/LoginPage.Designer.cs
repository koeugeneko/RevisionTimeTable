namespace TimeTable
{
    partial class LoginPage
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
            lblUsername = new Label();
            txtUsername = new TextBox();
            txtPassword = new TextBox();
            lblLoginPassword = new Label();
            btnLoginLogin = new Button();
            chkRememberMe = new CheckBox();
            labelSignUp = new Label();
            ErrorLabel = new Label();
            SuspendLayout();
            // 
            // lblUsername
            // 
            lblUsername.AutoSize = true;
            lblUsername.FlatStyle = FlatStyle.Flat;
            lblUsername.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblUsername.Location = new Point(207, 200);
            lblUsername.Name = "lblUsername";
            lblUsername.Size = new Size(117, 31);
            lblUsername.TabIndex = 0;
            lblUsername.Text = "Username";
            // 
            // txtUsername
            // 
            txtUsername.BackColor = Color.White;
            txtUsername.BorderStyle = BorderStyle.FixedSingle;
            txtUsername.ForeColor = Color.Black;
            txtUsername.Location = new Point(207, 242);
            txtUsername.Name = "txtUsername";
            txtUsername.Size = new Size(401, 27);
            txtUsername.TabIndex = 1;
            txtUsername.Text = "Username";
            txtUsername.Click += txtUsername_Click;
            // 
            // txtPassword
            // 
            txtPassword.BackColor = Color.White;
            txtPassword.BorderStyle = BorderStyle.FixedSingle;
            txtPassword.ForeColor = Color.DimGray;
            txtPassword.Location = new Point(207, 326);
            txtPassword.Name = "txtPassword";
            txtPassword.Size = new Size(401, 27);
            txtPassword.TabIndex = 3;
            txtPassword.Text = "Password";
            txtPassword.Click += txtPassword_Click;
            // 
            // lblLoginPassword
            // 
            lblLoginPassword.AutoSize = true;
            lblLoginPassword.FlatStyle = FlatStyle.Flat;
            lblLoginPassword.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblLoginPassword.Location = new Point(200, 291);
            lblLoginPassword.Name = "lblLoginPassword";
            lblLoginPassword.Size = new Size(110, 31);
            lblLoginPassword.TabIndex = 2;
            lblLoginPassword.Text = "Password";
            // 
            // btnLoginLogin
            // 
            btnLoginLogin.BackColor = Color.White;
            btnLoginLogin.FlatStyle = FlatStyle.Flat;
            btnLoginLogin.Location = new Point(404, 409);
            btnLoginLogin.Name = "btnLoginLogin";
            btnLoginLogin.Size = new Size(204, 52);
            btnLoginLogin.TabIndex = 4;
            btnLoginLogin.Text = "login";
            btnLoginLogin.UseVisualStyleBackColor = false;
            btnLoginLogin.Click += btnLoginLogin_Click;
            // 
            // chkRememberMe
            // 
            chkRememberMe.AutoSize = true;
            chkRememberMe.Location = new Point(207, 384);
            chkRememberMe.Name = "chkRememberMe";
            chkRememberMe.Size = new Size(125, 24);
            chkRememberMe.TabIndex = 5;
            chkRememberMe.Text = "RememberMe";
            chkRememberMe.UseVisualStyleBackColor = true;
            chkRememberMe.CheckedChanged += chkRememberMe_CheckedChanged;
            // 
            // labelSignUp
            // 
            labelSignUp.Font = new Font("Segoe UI", 9F);
            labelSignUp.Location = new Point(207, 436);
            labelSignUp.Name = "labelSignUp";
            labelSignUp.RightToLeft = RightToLeft.No;
            labelSignUp.Size = new Size(63, 25);
            labelSignUp.TabIndex = 6;
            labelSignUp.Text = "Sign up";
            labelSignUp.Click += labelSignUp_Click;
            labelSignUp.MouseEnter += labelSignUp_MouseEnter;
            labelSignUp.MouseLeave += labelSignUp_MouseLeave;
            // 
            // ErrorLabel
            // 
            ErrorLabel.AutoSize = true;
            ErrorLabel.ForeColor = Color.Red;
            ErrorLabel.Location = new Point(207, 170);
            ErrorLabel.Name = "ErrorLabel";
            ErrorLabel.Size = new Size(222, 20);
            ErrorLabel.TabIndex = 7;
            ErrorLabel.Text = "Username or password incorrect";
            // 
            // LoginPage
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImageLayout = ImageLayout.Stretch;
            Controls.Add(ErrorLabel);
            Controls.Add(labelSignUp);
            Controls.Add(chkRememberMe);
            Controls.Add(btnLoginLogin);
            Controls.Add(txtPassword);
            Controls.Add(lblLoginPassword);
            Controls.Add(txtUsername);
            Controls.Add(lblUsername);
            DoubleBuffered = true;
            Name = "LoginPage";
            Size = new Size(856, 721);
            Load += LoginPage_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblUsername;
        private TextBox txtUsername;
        private TextBox txtPassword;
        private Label lblLoginPassword;
        private Button btnLoginLogin;
        private CheckBox chkRememberMe;
        private Label labelSignUp;
        private Label ErrorLabel;
    }
}
