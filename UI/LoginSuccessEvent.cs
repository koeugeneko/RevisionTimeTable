using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeTable.Logic;

namespace TimeTable.UI
{
    public class LoginSuccessEvent : EventArgs
    {
        public int userId { get; }

        public LoginSuccessEvent(int userId)
        {
            this.userId = userId;
        }
        

    }
}
