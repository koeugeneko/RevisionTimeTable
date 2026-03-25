using TimeTable.Logic;

namespace TimeTable.UI
{
    public partial class SettingsPage : UserControl
    {
        public SettingsPage()
        {
            InitializeComponent();
        }
        private void numericUpDown1_ValueChanged(object sender, EventArgs e) // max task per day
        {
            UserSettingsService.changeMaxDailytasks(Convert.ToInt16(numericUpDown1.Value));
        }

        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {
            UserSettingsService.changeMaxHolidayDailyTask(Convert.ToInt32(numericUpDown2.Value));
        }
        private void DelectAccountButton_Click(object sender, EventArgs e)
        {
            string message = "Confirm to delete account. This action cannot be undone.\n\nAll your tasks, subjects, and settings will be permanently deleted.";
            string caption = "Delete my account";
            DialogResult result = MessageBox.Show(message, caption, MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                try
                {
                    TimeTable.Data.DataLayer.DeleteUserAccount(CurrentUser.UserId);
                    MessageBox.Show("Your account has been deleted.", "Account Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Environment.Exit(0);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error deleting account: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        public Action signoutButtonClicked;
        private void button2_Click(object sender, EventArgs e) //sign out
        {
            signoutButtonClicked?.Invoke();
        }

        private void SettingsPage_Load(object sender, EventArgs e)
        {
            Userlabel.Text = $"User: {CurrentUser.Username}";
            UserSettingsService.getUserSettings();
        }

        private void button1_Click(object sender, EventArgs e) //change my password button
        {
            string currentPassword = Microsoft.VisualBasic.Interaction.InputBox("Enter current password:", "Change Password", "");
            if (string.IsNullOrEmpty(currentPassword)) return;

            string newPassword = Microsoft.VisualBasic.Interaction.InputBox("Enter new password:", "Change Password", "");
            if (string.IsNullOrEmpty(newPassword)) return;

            string confirmPassword = Microsoft.VisualBasic.Interaction.InputBox("Confirm new password:", "Change Password", "");
            if (string.IsNullOrEmpty(confirmPassword)) return;

            if (newPassword != confirmPassword)
            {
                MessageBox.Show("New passwords do not match.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            bool success = AuthService.ChangePassword(CurrentUser.Username, currentPassword, newPassword);
            if (success)
            {
                MessageBox.Show("Password changed successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Current password is incorrect.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



    }
}
