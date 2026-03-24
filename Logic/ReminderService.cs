using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeTable.Data;
using System.Windows.Forms;

namespace TimeTable.Logic
{
    public class ReminderService
    {
        public static void CheckLastLoginAndRemind()
        {
            try
            {
                DateTime lastLogin = DataLayer.GetLastLogin(CurrentUser.UserId);
                TimeSpan daysSinceLogin = DateTime.Now.Date - lastLogin.Date;

                if (daysSinceLogin.Days >= 3)
                {
                    MessageBox.Show(
                        $"Welcome back! It's been {daysSinceLogin.Days} days since your last login.\nDon't forget to study today!",
                        "TimeTable Reminder",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                }
            }
            catch (Exception)
            {
            }
        }

        public static void ShowTaskReminder(int overdueCount)
        {
            if (overdueCount > 0)
            {
                MessageBox.Show(
                    $"You have {overdueCount} overdue task(s)!\nPlease check your daily tasks.",
                    "Task Reminder",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
            }
        }

        public static void ShowStudyReminder()
        {
            MessageBox.Show(
                "Time to study! Open TimeTable and complete your daily tasks.",
                "Study Reminder",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }
    }
}
