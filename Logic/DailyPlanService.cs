using System;
using System.Diagnostics;
using System.Net;
using TimeTable.Data;


namespace TimeTable.Logic
{
     static class DailyPlanService
     {
        // Recursive Backtracking + Memoization (DP) using LinkedList
        private static LinkedList<Task> FindOptimalTasks(
            List<Task> tasks,
            int maxTasks,
            int index,
            Dictionary<string, LinkedList<Task>> memo)
        {
            if (index >= tasks.Count || maxTasks <= 0)
                return new LinkedList<Task>();

            string key = $"{index}-{maxTasks}";
            if (memo.ContainsKey(key))
                return memo[key];

            // Skip 
            var skip = FindOptimalTasks(tasks, maxTasks, index + 1, memo);

            // Take 
            LinkedList<Task> take = new LinkedList<Task>();

            if (tasks[index].EstimatedMinutes <= maxTasks)
            {
                var next = FindOptimalTasks(
                    tasks,
                    maxTasks - tasks[index].EstimatedMinutes,
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


        public static LinkedList<Task> GenerateDailyPlan()
        {
            List<Task> tasks = DataLayer.GetTasksFromDatabase(CurrentUser.UserId);

            CallPublicHolidayApi(); // Now synchronous - waits for result

            int maxTask;
            UserSettings userSettings = DataLayer.GetUserSettingsFromDatabase(CurrentUser.UserId);
            if (userSettings == null)
            {
                maxTask = 2;
            }
            else if (isHoliday == true)
            {
                maxTask = userSettings.maxHoildayDailyTasks;
                Debug.WriteLine("Today is a holiday! Using holiday task limit.");
            }
            else
            {
                maxTask = userSettings.maxDailyTasks > 0 ? userSettings.maxDailyTasks : 2;
            }

            Debug.WriteLine($"Max tasks for today: {maxTask}, isHoliday: {isHoliday}");

            int index = 0;
            var memo = new Dictionary<string, LinkedList<Task>>();

            return FindOptimalTasks(tasks, maxTask, index, memo);

        }
        static bool? isHoliday = false; // default to false

        public static void CallPublicHolidayApi()
        {
            try
            {
                using var client = new HttpClient();
                client.Timeout = TimeSpan.FromSeconds(5);

                var response = client.GetAsync("https://date.nager.at/api/v3/IsTodayPublicHoliday/uk").Result;

                Debug.WriteLine($"Holiday API Response: {response.StatusCode}");

                if (response.StatusCode == HttpStatusCode.OK)
                {
                    isHoliday = true;
                }
                else
                {
                    isHoliday = false;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Holiday API Error: {ex.Message}");
                isHoliday = null;
            }
        }
    }
}
