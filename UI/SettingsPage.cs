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
            UserSettingsService.changeMaxDailytasks(Convert.ToInt32(numericUpDown1.Value));
        }

        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {
            UserSettingsService.changeMaxDailyMinutes(Convert.ToInt32(numericUpDown2.Value));
        }
        private void DelectAccountButton_Click(object sender, EventArgs e)
        {
            // Initializes the variables to pass to the MessageBox.Show method.
            string message = "Confirm to delete account. This action can not be revert";
            string caption = "Delete my account";
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result;

            // Displays the MessageBox.
            result = MessageBox.Show(message, caption, buttons);
            if (result == DialogResult.Yes)
            {
                // Delect account
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
            // Initializes the variables to pass to the MessageBox.Show method.
            string message = "Function to be added";
            string caption = "Change my password";
            MessageBoxButtons buttons = MessageBoxButtons.OK;
            DialogResult result;

            // Displays the MessageBox.
            result = MessageBox.Show(message, caption, buttons);

        }

        
        
    }
}
