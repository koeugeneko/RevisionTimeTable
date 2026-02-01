namespace TimeTable.UI
{
    partial class SignUpPage
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
            txtPassword = new TextBox();
            lblLoginPassword = new Label();
            txtUsername = new TextBox();
            lblUsername = new Label();
            txtPassword2 = new TextBox();
            label2 = new Label();
            label1 = new Label();
            txtEmail = new TextBox();
            btnSignup = new Button();
            labelLogin = new Label();
            UsernameErrorLabel = new Label();
            ErrorlabelPassword = new Label();
            ErrorLabelPassword2 = new Label();
            EmailErrorLabel = new Label();
            SignupSuccessLabel = new Label();
            SuspendLayout();
            // 
            // txtPassword
            // 
            txtPassword.BackColor = Color.White;
            txtPassword.BorderStyle = BorderStyle.FixedSingle;
            txtPassword.ForeColor = Color.DimGray;
            txtPassword.Location = new Point(189, 273);
            txtPassword.Name = "txtPassword";
            txtPassword.Size = new Size(401, 27);
            txtPassword.TabIndex = 10;
            txtPassword.Text = "Password";
            txtPassword.Click += txtPassword_Click;
            // 
            // lblLoginPassword
            // 
            lblLoginPassword.AutoSize = true;
            lblLoginPassword.FlatStyle = FlatStyle.Flat;
            lblLoginPassword.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblLoginPassword.Location = new Point(182, 238);
            lblLoginPassword.Name = "lblLoginPassword";
            lblLoginPassword.Size = new Size(171, 31);
            lblLoginPassword.TabIndex = 9;
            lblLoginPassword.Text = "Enter password";
            // 
            // txtUsername
            // 
            txtUsername.BackColor = Color.White;
            txtUsername.BorderStyle = BorderStyle.FixedSingle;
            txtUsername.ForeColor = Color.DimGray;
            txtUsername.Location = new Point(191, 173);
            txtUsername.Name = "txtUsername";
            txtUsername.Size = new Size(401, 27);
            txtUsername.TabIndex = 8;
            txtUsername.Text = "Username";
            txtUsername.Click += txtUsername_Click;
            // 
            // lblUsername
            // 
            lblUsername.AutoSize = true;
            lblUsername.FlatStyle = FlatStyle.Flat;
            lblUsername.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblUsername.Location = new Point(191, 131);
            lblUsername.Name = "lblUsername";
            lblUsername.Size = new Size(173, 31);
            lblUsername.TabIndex = 7;
            lblUsername.Text = "Enter username";
            // 
            // txtPassword2
            // 
            txtPassword2.BackColor = Color.White;
            txtPassword2.BorderStyle = BorderStyle.FixedSingle;
            txtPassword2.ForeColor = Color.DimGray;
            txtPassword2.Location = new Point(189, 374);
            txtPassword2.Name = "txtPassword2";
            txtPassword2.Size = new Size(401, 27);
            txtPassword2.TabIndex = 11;
            txtPassword2.Text = "Password";
            txtPassword2.Click += txtPassword2_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.FlatStyle = FlatStyle.Flat;
            label2.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(182, 438);
            label2.Name = "label2";
            label2.Size = new Size(129, 31);
            label2.TabIndex = 13;
            label2.Text = "Enter Email";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.FlatStyle = FlatStyle.Flat;
            label1.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(182, 340);
            label1.Name = "label1";
            label1.Size = new Size(232, 31);
            label1.TabIndex = 14;
            label1.Text = "Enter Password again";
            // 
            // txtEmail
            // 
            txtEmail.BackColor = Color.White;
            txtEmail.BorderStyle = BorderStyle.FixedSingle;
            txtEmail.ForeColor = Color.DimGray;
            txtEmail.Location = new Point(191, 472);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(401, 27);
            txtEmail.TabIndex = 15;
            txtEmail.Text = "Email";
            txtEmail.Click += txtEmail_Click;
            // 
            // btnSignup
            // 
            btnSignup.BackColor = Color.White;
            btnSignup.FlatStyle = FlatStyle.Flat;
            btnSignup.Location = new Point(386, 536);
            btnSignup.Name = "btnSignup";
            btnSignup.Size = new Size(204, 52);
            btnSignup.TabIndex = 16;
            btnSignup.Text = "Signup";
            btnSignup.UseVisualStyleBackColor = false;
            btnSignup.Click += btnSignup_Click;
            // 
            // labelLogin
            // 
            labelLogin.Font = new Font("Segoe UI", 9F);
            labelLogin.Location = new Point(189, 536);
            labelLogin.Name = "labelLogin";
            labelLogin.RightToLeft = RightToLeft.No;
            labelLogin.Size = new Size(132, 25);
            labelLogin.TabIndex = 17;
            labelLogin.Text = "I have an account";
            labelLogin.Click += labelLogin_Click;
            labelLogin.MouseEnter += labelLogin_MouseEnter;
            labelLogin.MouseLeave += labelLogin_MouseLeave;
            // 
            // UsernameErrorLabel
            // 
            UsernameErrorLabel.AutoSize = true;
            UsernameErrorLabel.ForeColor = Color.Red;
            UsernameErrorLabel.Location = new Point(192, 111);
            UsernameErrorLabel.Name = "UsernameErrorLabel";
            UsernameErrorLabel.Size = new Size(301, 20);
            UsernameErrorLabel.TabIndex = 18;
            UsernameErrorLabel.Text = "Username must be at least 6 characters long";
            // 
            // ErrorlabelPassword
            // 
            ErrorlabelPassword.AutoSize = true;
            ErrorlabelPassword.ForeColor = Color.Red;
            ErrorlabelPassword.Location = new Point(192, 218);
            ErrorlabelPassword.Name = "ErrorlabelPassword";
            ErrorlabelPassword.Size = new Size(0, 20);
            ErrorlabelPassword.TabIndex = 19;
            // 
            // ErrorLabelPassword2
            // 
            ErrorLabelPassword2.AutoSize = true;
            ErrorLabelPassword2.ForeColor = Color.Red;
            ErrorLabelPassword2.Location = new Point(189, 320);
            ErrorLabelPassword2.Name = "ErrorLabelPassword2";
            ErrorLabelPassword2.Size = new Size(191, 20);
            ErrorLabelPassword2.TabIndex = 20;
            ErrorLabelPassword2.Text = "Password must be the same";
            // 
            // EmailErrorLabel
            // 
            EmailErrorLabel.AutoSize = true;
            EmailErrorLabel.ForeColor = Color.Red;
            EmailErrorLabel.Location = new Point(189, 418);
            EmailErrorLabel.Name = "EmailErrorLabel";
            EmailErrorLabel.Size = new Size(192, 20);
            EmailErrorLabel.TabIndex = 21;
            EmailErrorLabel.Text = "Email must be a vaild email";
            // 
            // SignupSuccessLabel
            // 
            SignupSuccessLabel.AutoSize = true;
            SignupSuccessLabel.ForeColor = Color.Red;
            SignupSuccessLabel.Location = new Point(386, 513);
            SignupSuccessLabel.Name = "SignupSuccessLabel";
            SignupSuccessLabel.Size = new Size(109, 20);
            SignupSuccessLabel.TabIndex = 22;
            SignupSuccessLabel.Text = "Signup Success";
            // 
            // SignUpPage
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(SignupSuccessLabel);
            Controls.Add(EmailErrorLabel);
            Controls.Add(ErrorLabelPassword2);
            Controls.Add(ErrorlabelPassword);
            Controls.Add(UsernameErrorLabel);
            Controls.Add(labelLogin);
            Controls.Add(btnSignup);
            Controls.Add(txtEmail);
            Controls.Add(label1);
            Controls.Add(label2);
            Controls.Add(txtPassword2);
            Controls.Add(txtPassword);
            Controls.Add(lblLoginPassword);
            Controls.Add(txtUsername);
            Controls.Add(lblUsername);
            Margin = new Padding(2);
            Name = "SignUpPage";
            Size = new Size(856, 721);
            Load += SignUpPage_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtPassword;
        private Label lblLoginPassword;
        private TextBox txtUsername;
        private Label lblUsername;
        private TextBox txtPassword2;
        private Label label2;
        private Label label1;
        private TextBox txtEmail;
        private Button btnSignup;
        private Label labelLogin;
        private Label UsernameErrorLabel;
        private Label ErrorlabelPassword;
        private Label ErrorLabelPassword2;
        private Label EmailErrorLabel;
        private Label SignupSuccessLabel;
    }
}
