using System;
using System.Diagnostics;
using System.Net;
using TimeTable.Data;


namespace TimeTable.Logic
{
    public static class DailyPlanService
    {
        // Recursive Backtracking + Memoization (DP) using LinkedList
        // Recursive Backtracking + Memoization (DP) using LinkedList
        public static LinkedList<Task> FindOptimalTasks(
            List<Task> tasks,
            int maxMinutes,
            int index,
            Dictionary<string, LinkedList<Task>> memo)
        {
            if (index >= tasks.Count || maxMinutes <= 0)
                return new LinkedList<Task>();

            string key = $"{index}-{maxMinutes}";
            if (memo.ContainsKey(key))
                return memo[key];

            // Skip 
            var skip = FindOptimalTasks(tasks, maxMinutes, index + 1, memo);

            // Take 
            LinkedList<Task> take = new LinkedList<Task>();

            if (tasks[index].EstimatedMinutes <= maxMinutes)
            {
                var next = FindOptimalTasks(
                    tasks,
                    maxMinutes - tasks[index].EstimatedMinutes,
                    index + 1,
                    memo);

                // clone to avoid modifying memo result
                take = new LinkedList<Task>(next);
                take.AddLast(tasks[index]);
            }

            //  Compare 
            LinkedList<Task> best =
                take.Count > skip.Count
                ? take
                : new LinkedList<Task>(skip); // clone skip too for safety

            memo[key] = best;
            return best;
        }

        static List<Task> tasks = DataLayer.GetUnFinishedTasksFromDatabase(CurrentUser.UserId);


        static bool? isHoliday;
        public async static void CallPublicHolidayApi()
        {
            using var client = new HttpClient();

            var request = new HttpRequestMessage(HttpMethod.Get, $"https://date.nager.at/api/v3/IsTodayPublicHoliday/us");

            using var response = await client.SendAsync(request);

            Debug.WriteLine(response);
            switch (response.StatusCode)
            {
                case HttpStatusCode.OK:
                    isHoliday = true;
                    break;
                case HttpStatusCode.Accepted:
                    isHoliday = false;
                    break;
                case HttpStatusCode.NotFound:
                    isHoliday = null;
                    break;
            }

        } // find if todays a holiday
    }
}
