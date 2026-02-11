using System;
using System.Diagnostics;
using System.Net;



namespace TimeTable.Logic
{
    public static class DailyPlanService
    {
        // Recursive Backtracking + Memoization (DP)
        public static List<Task> FindOptimalTasks(List<Task> tasks, int maxMinutes, int index, Dictionary<string, List<Task>> memo)
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

            var best = take.Count > skip.Count ? take : skip;
            memo[key] = best;
            return best;
        }

        public async static void CallPublicHolidayApi()
        {
            /*string url = "https://date.nager.at";

            HttpClient client = new HttpClient();

            try
            {
                HttpResponseMessage response = await client.GetAsync(url);
                response.EnsureSuccessStatusCode();

                string json = await response.Content.ReadAsStringAsync();
                return json;
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
                return $"error: {e.Message}";
            }*/

            using var client = new HttpClient();

            var request = new HttpRequestMessage(HttpMethod.Get, $"https://date.nager.at/api/v3/IsTodayPublicHoliday/us");

            using var response = await client.SendAsync(request);

            Debug.WriteLine(response);
            bool? isHoliday;
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
        }
    }
}
