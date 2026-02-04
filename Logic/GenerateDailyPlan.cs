using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeTable.Data;


namespace TimeTable.Logic
{
    internal class GenerateDailyPlan
    {
        Task task1 = new Task();

        //List<Task> tasks = DataLayer.GetTasksFromDatabase();

        LinkedList<Task> todaysTasks = new LinkedList<Task>();

        // call public hoilday
        // 
        // if the region of the hoilday is on important hoilday, set less task or no task
    }
}
