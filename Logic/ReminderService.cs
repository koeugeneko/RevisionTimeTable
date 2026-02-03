using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Toolkit.Uwp.Notifications;


namespace TimeTable.Logic
{
    internal class ReminderService
    {
        Queue<string> reminder = new Queue<string>();

        // get last login
        // if more then 3 days
        // sent reminder

        /*public void ShowNotification()
        {
            new ToastContentBuilder()
            .AddArgument("action", "viewDetails")
            .AddText("Notification Title")
            .AddText("This is the notification message.")
            .(); // Displays the notification
        }*/



    }

}
