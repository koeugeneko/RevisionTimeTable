using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeTable.Logic
{
    internal class DailyPlanService
    {
        // Recursive Backtracking + Memoization (DP)
        private List<Task> FindOptimalTasks(List<Task> tasks, int maxMinutes, int index, Dictionary<string, List<Task>> memo)
        {
            if (index == tasks.Count || maxMinutes <= 0) return new List<Task>();

            string key = $"{index}-{maxMinutes}";
            if (memo.ContainsKey(key)) return memo[key];

            // skip choice
            var skip = FindOptimalTasks(tasks, maxMinutes, index + 1, memo);

            // take choice
            var take = new List<Task>();
            if (tasks[index].EstimatedMinutes <= maxMinutes)
            {
                take = FindOptimalTasks(tasks, maxMinutes - tasks[index].EstimatedMinutes, index + 1, memo);
                take.Add(tasks[index]);
            }

            // 選分數高嘅
            var best = take.Count > skip.Count ? take : skip;
            memo[key] = best;
            return best;
        }
    }
}
