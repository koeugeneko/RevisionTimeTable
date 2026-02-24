using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeTable.Logic
{
    public class UserSettings
    {
        public int maxDailyTasks { get; set; }
        public int maxHoildayDailyTasks { get; set; }
        public string Region { get; set; }
        public bool taskReminderEnabled { get; set; }
    }
}
