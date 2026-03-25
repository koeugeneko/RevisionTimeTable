using Microsoft.VisualBasic.Logging;
using System.IO;
using TimeTable.Data;
using TimeTable.Logic;
using TimeTable.UI;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace TimeTable
{
    public partial class LoginPage : UserControl
    {
        private readonly string _rememberMeFile = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "TimeTable", "rememberme.txt");

        public LoginPage()
        {
            InitializeComponent();
            LoadRememberedUser();
        }

        private void LoadRememberedUser()
        {
            try
            {
                if (File.Exists(_rememberMeFile))
                {
                    string savedUsername = File.ReadAllText(_rememberMeFile).Trim();
                    if (!string.IsNullOrEmpty(savedUsername))
                    {
                        txtUsername.Text = savedUsername;
                        txtUsername.ForeColor = Color.Black;
                        chkRememberMe.Checked = true;
                    }
                }
            }
            catch { }
        }

        private void SaveRememberedUser(string username)
        {
            try
            {
                string directory = Path.GetDirectoryName(_rememberMeFile);
                if (!Directory.Exists(directory))
                    Directory.CreateDirectory(directory);

                File.WriteAllText(_rememberMeFile, username);
            }
            catch { }
        }

        private void ClearRememberedUser()
        {
            try
            {
                if (File.Exists(_rememberMeFile))
                    File.Delete(_rememberMeFile);
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
                    SaveRememberedUser(txtUsername.Text);
                else
                    ClearRememberedUser();

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
