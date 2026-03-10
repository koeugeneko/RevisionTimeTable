using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeTable.Logic
{
    internal class ReportService
    {
        public List<Task> MergeSortTasks(List<Task> tasks) // recursion
        {
            if (tasks.Count <= 1) return tasks;

            int mid = tasks.Count / 2;
            var left = MergeSortTasks(tasks.Take(mid).ToList());
            var right = MergeSortTasks(tasks.Skip(mid).ToList());

            return Merge(left, right);
        }

        private List<Task> Merge(List<Task> left, List<Task> right)
        {
            var result = new List<Task>();
            int i = 0, j = 0;

            while (i < left.Count && j < right.Count)
            {
                if (CompareTasks(left[i], right[j]) <= 0)
                    result.Add(left[i++]);
                else
                    result.Add(right[j++]);
            }

            result.AddRange(left.Skip(i));
            result.AddRange(right.Skip(j));
            return result;
        }

        private int CompareTasks(Task a, Task b)
        {
            int cmp = b.Priority.CompareTo(a.Priority);  // DESC
            if (cmp == 0) cmp = (a.DueDate ?? DateTime.MaxValue).CompareTo(b.DueDate ?? DateTime.MaxValue);  // ASC
            if (cmp == 0) cmp = a.EstimatedMinutes.CompareTo(b.EstimatedMinutes);  // ASC
            return cmp;
        }
    }
}
