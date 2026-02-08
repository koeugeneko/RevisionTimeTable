using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeTable.Data;

namespace TimeTable.Logic
{
    internal static class TaskService
    {

        public static void AddNewTask()
        {
            Task task = new Task();

        }

        public static List<Subject> GetSubjectsForCurrentUser()
        {
            return DataLayer.GetSubjectsFromDatabase(CurrentUser.UserId);
        }
        public static void UpdateTask()
        {

        }

        public static void DeleteTask() 
        {

        }
    }
}
