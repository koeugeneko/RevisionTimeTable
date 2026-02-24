using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeTable.Data;

namespace TimeTable.Logic
{
    internal class UserSettingsService
    {
        public void signout()
        {
            CurrentUser.UserId = 0;
            CurrentUser.Username = null;
        }

        UserSettingsservice()
        {
            UserSettings settings = DataLayer.GetUserSettingsFromDatabase(CurrentUser.UserId);
        }
        public void changeMaxDailytasks(int newMax)
        {
            
        }
        public void changeMaxDailyMinutes(int newMax)
        {
           
        }
        public void updateUserSettings(UserSettings newSettings)
        {
            // Update user settings in database for the current user
            DataLayer.UpdateUserSettingsInDatabase(CurrentUser.UserId, newSettings);
        }


    }
}
