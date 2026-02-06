using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeTable.Logic
{
    internal class UserSettingsService
    {

        public void signout()
        {
            CurrentUser.UserId = 0;
            CurrentUser.Username = null;
        }
    }
}
