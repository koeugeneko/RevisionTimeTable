using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeTable.Logic
{
    public class Task
    {
        public int TaskId { get; set; }
        public int UserId { get; set; }
        public int? SubjectId { get; set; }
        public string Description { get; set; }
        public int EstimatedMinutes { get; set; }
        public int Priority { get; set; }  // 1=Low, 2=Medium, 3=High
        public DateTime? DueDate { get; set; }
        public bool Completed { get; set; }
        public DateTime? CompletedAt { get; set; }
        public DateTime CreatedAt { get; set; }

        // 可加方法（行為封裝）
        public double CalculatePriorityScore()
        {
            double score = Priority * 10;
            if (DueDate.HasValue)
                score += (DueDate.Value - DateTime.Today).TotalDays * -5;  // 越近到期分越高
            return score;
        }
    }
}
