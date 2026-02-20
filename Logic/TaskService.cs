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
                task.Description = description;
                task.DueDate = dueDate;
            }

            DataLayer.InsertTaskIntoDatabase(task);
        }

        public static List<Logic.Task> GetTasksForCurrentUser()
        {
            return DataLayer.GetTasksFromDatabase(CurrentUser.UserId);

        }

        public static void UpdateTask(Logic.Task task)
        {
            DataLayer.UpdateTaskInDatabase(task);
        }
        public static void MarkTaskAsCompleted(Logic.Task task)
        {
            DataLayer.UpdateTaskInDatabase(task);
        }

        public static void DeleteTask(int taskId) 
        {
            DataLayer.DeleteTaskFromDatabase(taskId, CurrentUser.UserId);
        }
    }
}
