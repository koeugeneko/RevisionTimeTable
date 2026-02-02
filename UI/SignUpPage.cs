using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TimeTable.Logic;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace TimeTable.UI
{
    public partial class SignUpPage : UserControl
    {
        public SignUpPage()
        {
            InitializeComponent();
        }

        public void SignUpPage_Load(object sender, EventArgs e)
        {
            UsernameErrorLabel.Hide();
            ErrorlabelPassword.Hide();
            ErrorLabelPassword2.Hide();
            EmailErrorLabel.Hide();
            SignupSuccessLabel.Hide();
        }

        private void btnSignup_Click(object sender, EventArgs e)
        {   
            if (!AuthService.ValidateUsername(txtUsername.Text))
            {
                UsernameErrorLabel.Show();
                return;
            }
            else UsernameErrorLabel.Hide();
            if (!AuthService.ValidatePassword(txtPassword.Text))
            {
                ErrorlabelPassword.Text = "Password must be at least 8 characters long and contain at least 1 Uppercase and at least 1 number";
                ErrorlabelPassword.Show();
                return;
            }
            else ErrorlabelPassword.Hide();
            if (!AuthService.ValidatePasswordMatch(txtPassword.Text, txtPassword2.Text))
            {
                ErrorLabelPassword2.Show();
                return;
            }
            else ErrorLabelPassword2.Hide();
            if (!AuthService.ValidateEmail(txtEmail.Text))
            {
                EmailErrorLabel.Show();
                return;
            }
            else EmailErrorLabel.Hide();

            AuthService.SignUp(txtUsername.Text, txtPassword.Text, txtEmail.Text);
            SignupSuccessLabel.Show();
        }

        private void txtUsername_Click(object sender, EventArgs e)
        {
            if (txtUsername.Text == "Username")
            {
                txtUsername.Clear();
                txtUsername.ForeColor = Color.Black;
            }
        }

        private void txtPassword_Click(object sender, EventArgs e)
        {
            if (txtPassword.Text == "Password")
            {
                txtPassword.Clear();
                txtPassword.UseSystemPasswordChar = true;
                txtPassword.ForeColor = Color.Black;
            }
        }

        private void txtPassword2_Click(object sender, EventArgs e)
        {
            if (txtPassword2.Text == "Password")
            {
                txtPassword2.Clear();
                txtPassword2.UseSystemPasswordChar = true;
                txtPassword2.ForeColor = Color.Black;
            }
        }

        private void txtEmail_Click(object sender, EventArgs e)
        {
            if (txtEmail.Text == "Email")
            {
                txtEmail.Clear();
                txtEmail.ForeColor = Color.Black;
            }
        }

        public Action LoginClicked;
        private void labelLogin_Click(object sender, EventArgs e)
        {
            LoginClicked?.Invoke();
        }

        Font originalFont;
        private void labelLogin_MouseEnter(object sender, EventArgs e)
        {
            if (originalFont == null)
                originalFont = labelLogin.Font;

            labelLogin.Font = new Font(originalFont, FontStyle.Underline); // underline animation when mouse hover
            labelLogin.ForeColor = Color.Blue;
            labelLogin.Cursor = Cursors.Hand;
        }

        private void labelLogin_MouseLeave(object sender, EventArgs e)
        {
            if (originalFont != null)
            {
                labelLogin.Font = originalFont;
                labelLogin.ForeColor = SystemColors.ControlText;
                labelLogin.Cursor = Cursors.Default;

            }
        }
    }
}
