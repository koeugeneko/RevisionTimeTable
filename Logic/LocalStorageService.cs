using System;
using System.IO;
using System.Text.Json;
using System.Diagnostics;

namespace TimeTable.Logic
{
    public class LocalStorageService
    {
        private static string FolderPath => Path.Combine(
            Environment.GetFolderPath(Environment.SpecialFolder.Desktop),
            ConfigService.StorageFolderPath);
        
        private static string FilePath => Path.Combine(FolderPath, ConfigService.StorageFileName);

        public class RememberMeData
        {
            public string Username { get; set; }
            public string Password { get; set; }
        }

        public static void SaveCredentials(string username, string password)
        {
            try
            {
                if (!Directory.Exists(FolderPath))
                    Directory.CreateDirectory(FolderPath);

                var data = new RememberMeData
                {
                    Username = username,
                    Password = password
                };

                string json = JsonSerializer.Serialize(data);
                File.WriteAllText(FilePath, json);
                
                Debug.WriteLine($"Credentials saved to: {FilePath}");
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error saving credentials: {ex.Message}");
            }
        }

        public static (string username, string password)? LoadCredentials()
        {
            try
            {
                if (!File.Exists(FilePath))
                    return null;

                string json = File.ReadAllText(FilePath);
                var data = JsonSerializer.Deserialize<RememberMeData>(json);
                
                if (data != null && !string.IsNullOrEmpty(data.Username))
                {
                    Debug.WriteLine($"Loaded credentials for: {data.Username}");
                    return (data.Username, data.Password);
                }
                
                return null;
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error loading credentials: {ex.Message}");
                return null;
            }
        }

        public static void ClearCredentials()
        {
            try
            {
                if (File.Exists(FilePath))
                {
                    File.Delete(FilePath);
                    Debug.WriteLine("Credentials cleared");
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error clearing credentials: {ex.Message}");
            }
        }

        public static bool HasCredentials()
        {
            return File.Exists(FilePath);
        }
    }
}
