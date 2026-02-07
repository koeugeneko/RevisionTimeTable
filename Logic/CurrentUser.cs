using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeTable.Logic
{
    public static class CurrentUser
    {

        public static string Username { get; set; }

        public static int UserId;


        private static int _UserId;

        public static int getUserId()
        {
            return _UserId;
        }

        private static bool haveSet = false;
        public static void setUserId(int userId) // only allow userID to be set once
        {   
            if (haveSet)
            {
                throw new InvalidOperationException("User ID has already been set and cannot be changed.");
            }
            else if (!haveSet)
            {
                _UserId = userId;
                haveSet = true;
            }
        }


    }
}
