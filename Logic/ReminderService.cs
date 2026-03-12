using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Toolkit.Uwp.Notifications;
using TimeTable.Data;
using System.Net;
using System.Net.Mail;


namespace TimeTable.Logic
{
    public class ReminderService
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

        public void adf()
        {
            DateTime lastlogin = Data.DataLayer.GetLastLogin(CurrentUser.UserId);
            //if( DateTime.Now.Date - lastlogin.Date >= 3)
            {

            }
        }

        public static async void asdf()
        {
            MailMessage mail = new MailMessage();
            mail.From = new MailAddress("youremail@gmail.com");
            mail.To.Add("eugeneko@exe-coll.co.uk");
            mail.Subject = "Test Email";
            mail.Body = "Hello from C#";

            SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
            smtp.Credentials = new NetworkCredential("youremail@gmail.com", "yourpassword");
            smtp.EnableSsl = true;

            await smtp.SendMailAsync(mail);
        }

    }

}
