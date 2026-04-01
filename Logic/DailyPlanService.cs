using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using TimeTable.Data;

namespace TimeTable.Logic
{
    static class DailyPlanService
    {
        static bool? isHoliday = false; // default to false

        // Calculate score for a task based on weighted factors
        private static double CalculateTaskScore(Task task)
        {
            // Priority score (40% weight) - higher priority = higher score
            double priorityScore = task.Priority / 3.0;

            // Due date score (30% weight) - closer due date = higher score
            double daysUntilDue = task.DueDate.HasValue 
                ? (task.DueDate.Value - DateTime.Now).TotalDays 
                : 30; // Default to 30 days if no due date
            double dueDateScore = 1.0 / (Math.Max(daysUntilDue, 0) + 1);

            // Time score (20% weight) - shorter estimated time = higher score
            double timeScore = 1.0 / (task.EstimatedMinutes + 1);

            // Holiday score (10% weight) - fixed at 1.0 (holiday affects maxTasks, not score)
            double holidayScore = 1.0;

            double finalScore = (priorityScore * 0.4) + (dueDateScore * 0.3) + (timeScore * 0.2) + (holidayScore * 0.1);

            Debug.WriteLine($"Task: {task.Description}, Priority: {priorityScore:F2}, Due: {dueDateScore:F2}, Time: {timeScore:F2}, Holiday: {holidayScore:F2}, Final: {finalScore:F2}");

            return finalScore;
        }

        public static LinkedList<Task> GenerateDailyPlan()
        {
            // 1. Get all tasks for current user
            List<Task> allTasks = DataLayer.GetTasksFromDatabase(CurrentUser.UserId);

            // 2. Filter out completed tasks
            List<Task> incompleteTasks = allTasks.Where(t => !t.Completed).ToList();

            Debug.WriteLine($"Found {incompleteTasks.Count} incomplete tasks");

            // 3. Get user settings
            UserSettings userSettings = DataLayer.GetUserSettingsFromDatabase(CurrentUser.UserId);

            // 4. Call holiday API
            CallPublicHolidayApi();

            // 5. Determine max tasks based on holiday
            int maxTasks;
            if (userSettings == null)
            {
                maxTasks = 2;
            }
            else if (isHoliday == true)
            {
                maxTasks = userSettings.maxHoildayDailyTasks;
                Debug.WriteLine("Today is a holiday! Using holiday task limit.");
            }
            else
            {
                maxTasks = userSettings.maxDailyTasks > 0 ? userSettings.maxDailyTasks : 2;
            }

            Debug.WriteLine($"Max tasks for today: {maxTasks}, isHoliday: {isHoliday}");

            // 6. Calculate scores for all tasks
            var taskScores = new Dictionary<Task, double>();
            foreach (var task in incompleteTasks)
            {
                double score = CalculateTaskScore(task);
                taskScores[task] = score;
            }

            // 7. Calculate dynamic target score (average)
            double targetScore = taskScores.Values.Count > 0 ? taskScores.Values.Average() : 0.5;
            Debug.WriteLine($"Dynamic target score (average): {targetScore:F2}");

            // 8. Sort by score descending
            var sortedTasks = taskScores.OrderByDescending(kvp => kvp.Value).ToList();

            // 9. Select tasks meeting target, up to maxTasks
            LinkedList<Task> result = new LinkedList<Task>();
            int selectedCount = 0;

            foreach (var kvp in sortedTasks)
            {
                if (kvp.Value >= targetScore && selectedCount < maxTasks)
                {
                    result.AddLast(kvp.Key);
                    selectedCount++;
                    Debug.WriteLine($"Selected: {kvp.Key.Description}, Score: {kvp.Value:F2}");
                }
            }

            Debug.WriteLine($"Selected {selectedCount} tasks for today's plan");

            // 10. Save plan to database
            DataLayer.SaveDailyPlan(CurrentUser.UserId, result, DateTime.Now.Date);

            return result;
        }

        public static void CallPublicHolidayApi()
        {
            try
            {
                using var client = new HttpClient();
                client.Timeout = TimeSpan.FromSeconds(ConfigService.HolidayApiTimeout);

                string url = $"{ConfigService.HolidayApiUrl}{ConfigService.HolidayApiCountry}";
                var response = client.GetAsync(url).Result;

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
