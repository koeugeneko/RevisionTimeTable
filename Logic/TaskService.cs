using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeTable.Data;

namespace TimeTable.Logic
{
    internal static class TaskService
    {

        public static void AddNewTask(string subjectName, DateTime estamiatedTime, decimal priority, string description, DateTime dueDate)
        {
            Task task = new Task();
            {
                task.SubjectId = DataLayer.GetSubjectIdFromDatabse(CurrentUser.UserId, subjectName);
                task.EstimatedMinutes = estamiatedTime.Minute;
                task.Priority = Convert.ToInt32(priority);
            }
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
