using System;
using System.IO;
using System.Text.Json;
using System.Diagnostics;

namespace TimeTable.Logic
{
    public class ConfigService
    {
        private static ConfigData _config;
        private static readonly string _configPath = Path.Combine(
            AppDomain.CurrentDomain.BaseDirectory, 
            "Config", 
            "config.json");

        // Default values
        private const string DEFAULT_CONNECTION_STRING = "Host=localhost;Port=5432;Database=TimeTable;Username=postgres;Password=Ek001";
        private const string DEFAULT_CONNECTION_STRING_2 = "Host=localhost;Port=5432;Database=TimeTable;Username=postgres;Password=Ek002";
        private const string DEFAULT_HOLIDAY_API_URL = "https://date.nager.at/api/v3/IsTodayPublicHoliday/";
        private const string DEFAULT_HOLIDAY_COUNTRY = "uk";
        private const int DEFAULT_HOLIDAY_TIMEOUT = 5;
        private const int DEFAULT_TIMER_MINUTES = 25;
        private const string DEFAULT_STORAGE_FOLDER = "revisionTimeTable";

        static ConfigService()
        {
            LoadConfig();
        }

        private static void LoadConfig()
        {
            try
            {
                if (File.Exists(_configPath))
                {
                    string json = File.ReadAllText(_configPath);
                    _config = JsonSerializer.Deserialize<ConfigData>(json);
                    Debug.WriteLine($"Config loaded from: {_configPath}");
                }
                else
                {
                    _config = new ConfigData();
                    Debug.WriteLine("Config file not found, using defaults");
                }
            }
            catch (Exception ex)
            {
                _config = new ConfigData();
                Debug.WriteLine($"Error loading config: {ex.Message}, using defaults");
            }
        }

        // Connection Strings
        public static string ConnectionString
        {
            get => _config?.ConnectionStrings?.Primary ?? DEFAULT_CONNECTION_STRING;
        }

        public static string ConnectionString2
        {
            get => _config?.ConnectionStrings?.Secondary ?? DEFAULT_CONNECTION_STRING_2;
        }

        // Holiday API
        public static string HolidayApiUrl
        {
            get => _config?.HolidayApi?.BaseUrl ?? DEFAULT_HOLIDAY_API_URL;
        }

        public static string HolidayApiCountry
        {
            get => _config?.HolidayApi?.Country ?? DEFAULT_HOLIDAY_COUNTRY;
        }

        public static int HolidayApiTimeout
        {
            get => _config?.HolidayApi?.TimeoutSeconds ?? DEFAULT_HOLIDAY_TIMEOUT;
        }

        // Timer
        public static int TimerDefaultMinutes
        {
            get => _config?.Timer?.DefaultMinutes ?? DEFAULT_TIMER_MINUTES;
        }

        // Storage
        public static string StorageFolderPath
        {
            get => _config?.Storage?.FolderPath ?? DEFAULT_STORAGE_FOLDER;
        }

        public static string StorageFileName
        {
            get => _config?.Storage?.FileName ?? "rememberMe.json";
        }
    }

    // Config data classes
    public class ConfigData
    {
        public ConnectionStringsConfig ConnectionStrings { get; set; } = new ConnectionStringsConfig();
        public HolidayApiConfig HolidayApi { get; set; } = new HolidayApiConfig();
        public TimerConfig Timer { get; set; } = new TimerConfig();
        public StorageConfig Storage { get; set; } = new StorageConfig();
    }

    public class ConnectionStringsConfig
    {
        public string Primary { get; set; }
        public string Secondary { get; set; }
    }

    public class HolidayApiConfig
    {
        public string BaseUrl { get; set; }
        public string Country { get; set; }
        public int TimeoutSeconds { get; set; }
    }

    public class TimerConfig
    {
        public int DefaultMinutes { get; set; }
    }

    public class StorageConfig
    {
        public string FolderPath { get; set; }
        public string FileName { get; set; }
    }
}
