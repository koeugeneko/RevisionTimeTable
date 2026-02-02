using Microsoft.VisualBasic.Logging;
using TimeTable.Logic; 

namespace TimeTable
{
    public partial class LoginPage : UserControl
    {
        public LoginPage()
        {
            InitializeComponent();
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

        public Action loginSuccessful;
        private void btnLoginLogin_Click(object sender, EventArgs e)
        {
            bool loginSuccess = AuthService.Login(txtUsername.Text, txtPassword.Text);
            if (!loginSuccess)
            {
                ErrorLabel.Show();
            }
            else
            {
                loginSuccessful?.Invoke();
            }
            loginSuccessful?.Invoke(); // For testing purposes only, remove this line in production

        }

        private void LoginPage_Load(object sender, EventArgs e)
        {
            /*// Set focus to the username label when login page loads - workaround for text box focus issue
            this.BeginInvoke(new Action(() =>
            {
                lblUsername.Focus();
            }));*/
            ErrorLabel.Hide();
        }


        private void chkRememberMe_CheckedChanged(object sender, EventArgs e)
        {
            // need to save username and password to local storage // add a autofill funtion here
        }

        public Action SignUpClicked;
        private void labelSignUp_Click(object sender, EventArgs e)
        {
            SignUpClicked?.Invoke();
        }

        Font originalFont;
        private void labelSignUp_MouseEnter(object sender, EventArgs e)
        {
            if (originalFont == null)
                originalFont = labelSignUp.Font;

            labelSignUp.Font = new Font(originalFont, FontStyle.Underline); // underline animation when mouse hover
            labelSignUp.ForeColor = Color.Blue;
            labelSignUp.Cursor = Cursors.Hand;
        }

        private void labelSignUp_MouseLeave(object sender, EventArgs e)
        {
            if (originalFont != null)
            {
                labelSignUp.Font = originalFont;
                labelSignUp.ForeColor = SystemColors.ControlText;
                labelSignUp.Cursor = Cursors.Default;
            }
        }


    }
}
