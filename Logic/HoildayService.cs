//public class HolidayService
//{
//    private readonly HttpClient _client = new HttpClient();

//    public async Task<HolidayInfo> GetTodayHolidayInfoAsync(string countryCode = "HK")
//    {
//        string url = $"https://date.nager.at/api/v3/publicholidays/{DateTime.Today.Year}/{countryCode}";

//        try
//        {
//            string json = await _client.GetStringAsync(url);
//            var holidays = JsonConvert.DeserializeObject<List<Holiday>>(json);

//            var todayHoliday = holidays?.FirstOrDefault(h =>
//                h.Date.Date == DateTime.Today.Date);

//            if (todayHoliday == null)
//                return new HolidayInfo { IsHoliday = false, IsImportant = false };

//            bool isImportant = IsImportantHoliday(todayHoliday.Name);

//            return new HolidayInfo
//            {
//                IsHoliday = true,
//                HolidayName = todayHoliday.Name,
//                IsImportant = isImportant
//            };
//        }
//        catch
//        {
//            return new HolidayInfo { IsHoliday = false, IsImportant = false }; // API 失敗當普通日
//        }
//    }

//    private bool IsImportantHoliday(string name)
//    {
//        string n = name.ToLower();
//        return n.Contains("christmas") || n.Contains("new year") ||
//               n.Contains("easter") || n.Contains("lunar") ||
//               n.Contains("national day");
//    }
//}

//public class HolidayInfo
//{
//    public bool IsHoliday { get; set; }
//    public string HolidayName { get; set; }
//    public bool IsImportant { get; set; }
//}