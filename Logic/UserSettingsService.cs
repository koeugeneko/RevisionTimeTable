using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeTable.Data;

namespace TimeTable.Logic
{
    public static class UserSettingsService
    {
        public static void signout()
        {
            CurrentUser.UserId = 0;
            CurrentUser.Username = null;
        }
        public static UserSettings settings;
        public static void getUserSettings()
        {
            settings = DataLayer.GetUserSettingsFromDatabase(CurrentUser.UserId);
        }
        
        public static void changeMaxDailytasks(int newMax)
        {
            settings.maxDailyTasks = newMax;
            updateUserSettings();
        }
        public static void changeMaxHolidayDailyTask(int newMax)
        {
            settings.maxHoildayDailyTasks = newMax;
            updateUserSettings();
        }

        public static void updateUserSettings()
        {
            // Update user settings in database for the current user
            DataLayer.UpdateUserSettingsInDatabase(CurrentUser.UserId, settings);
        }


    }
}
