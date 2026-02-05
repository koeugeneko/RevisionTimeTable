using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeTable.Logic
{
    internal class DailyPlanService
    {
        public List<Task> GenerateDailyPlan(int maxTasks, int userId)
        {
            List<Task> unfinishedTasks = GetUnfinishedTasks(userId);

            // PriorityQueue + Greedy 
            var pq = new PriorityQueue<Task, double>(Comparer<double>.Create((a, b) => b.CompareTo(a)));  // max-heap

            foreach (var task in unfinishedTasks)
            {
                double score = task.Priority * 10;  // 優先級加權

                if (task.DueDate.HasValue)
                {
                    double daysToDue = (DateTime.Today - task.DueDate.Value).TotalDays;
                    score += daysToDue * -5;  // 越近到期分越高
                }

                score += task.EstimatedMinutes * -0.5;  // 短任務優先

                pq.Enqueue(task, score);
            }

            // 貪婪取前 maxTasks 項
            var suggested = new List<Task>();
            while (suggested.Count < maxTasks && pq.Count > 0)
            {
                suggested.Add(pq.Dequeue());
            }

            return suggested;
        }

        private List<Task> GetUnfinishedTasks(int userId)
        {
            var sql = @"SELECT t.task_id, t.description, t.priority, t.estimated_minutes, t.due_date
                    FROM Tasks t
                    WHERE t.user_id = @userId AND t.completed = false
                    ORDER BY t.priority DESC";

            var param = new Dictionary<string, object> { { "@userId", userId } };

            var rows = DatabaseHelper.ExecuteQuery(sql, param);

            return rows.Select(row => new Task
            {
                TaskId = Convert.ToInt32(row["task_id"]),
                Description = row["description"].ToString(),
                Priority = Convert.ToInt32(row["priority"]),
                EstimatedMinutes = Convert.ToInt32(row["estimated_minutes"]),
                DueDate = row.ContainsKey("due_date") && row["due_date"] != DBNull.Value ? (DateTime?)row["due_date"] : null
            }).ToList();
        }
    }
}
