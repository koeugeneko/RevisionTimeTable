using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeTable.Logic
{
    public class Task // not in use
    {
        public int TaskId { get; }
        public int UserId { get; }
        public int? SubjectId { get; }
        public string Description { get; set; }
        public int EstimatedMinutes { get; set; }
        public int Priority { get; set; }  // 1=Low, 2=Medium, 3=High
        public DateTime? DueDate { get; set; }
        public bool Completed { get; set; }
        public DateTime? CompletedAt { get; set; }
        public DateTime CreatedAt { get; set; }

        public Task()
        {
            CreatedAt = DateTime.Now;
            Completed = false;
        }
    }
}
