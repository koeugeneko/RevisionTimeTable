using TimeTable.Data;
using TimeTable.Logic;
using TimeTable.UI;

namespace TimeTable
{
    public partial class LoginPage : UserControl
    {
        public LoginPage()
        {
            InitializeComponent();
            LoadRememberedCredentials();
        }

        private void LoadRememberedCredentials()
        {
            try
            {
                var credentials = LocalStorageService.LoadCredentials();
                if (credentials.HasValue)
                {
                    txtUsername.Text = credentials.Value.username;
                    txtUsername.ForeColor = Color.Black;
                    txtPassword.Text = credentials.Value.password;
                    txtPassword.ForeColor = Color.Black;
                    txtPassword.UseSystemPasswordChar = true;
                    chkRememberMe.Checked = true;
                }
            }
            catch { }
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

        public event EventHandler<LoginSuccessEvent>? LoginSuccessful;
        private void btnLoginLogin_Click(object sender, EventArgs e)
        {
            bool loginSuccess = AuthService.Login(txtUsername.Text, txtPassword.Text);
            if (!loginSuccess)
            {
                ErrorLabel.Show();
            }
            else
            {
                if (chkRememberMe.Checked)
                {
                    LocalStorageService.SaveCredentials(txtUsername.Text, txtPassword.Text);
                }
                else
                {
                    LocalStorageService.ClearCredentials();
                }

                int userId = DataLayer.GetUserIdFromDatabase(txtUsername.Text);
                LoginSuccessful?.Invoke(
                    this,
                    new LoginSuccessEvent(userId)
                    );
            }
        }

        private void LoginPage_Load(object sender, EventArgs e)
        {
            ErrorLabel.Hide();
        }

        private void chkRememberMe_CheckedChanged(object sender, EventArgs e)
        {
            // Will be applied on next successful login
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

            labelSignUp.Font = new Font(originalFont, FontStyle.Underline);
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
