using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeTable.Logic
{
    public class DailyPlan //not in use
    {
        public DateTime Date { get; set; }

        public List<Task> Tasks { get; set; }
        public int totalTasks { get; set; }
        public bool isHoliday { get; set; }
    }
}
