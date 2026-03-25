using Microsoft.VisualBasic.ApplicationServices;
using Npgsql;
using System.Diagnostics;
using System.Xml.Linq;
using TimeTable.Logic;

namespace TimeTable.Data
{
    public class DataLayer
    {
        private static readonly string ConnectionString = "Host=localhost;Port=5432;Database=TimeTable;Username=postgres;Password=Ek001";
        private static readonly string ConnectionString2 = "Host=localhost;Port=5432;Database=TimeTable;Username=postgres;Password=Ek002";


        // INSERT / UPDATE / DELETE mutiple data
        public static int ExecuteNonQuery(string sql, Dictionary<string, object> parameters = null)
        {
            try
            {
                using var conn = new NpgsqlConnection(ConnectionString);
                conn.Open();

                using var cmd = new NpgsqlCommand(sql, conn);
                if (parameters != null)
                {
                    foreach (var p in parameters)
                        cmd.Parameters.AddWithValue(p.Key, p.Value);
                }

                return cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                using var conn = new NpgsqlConnection(ConnectionString2);
                conn.Open();

                using var cmd = new NpgsqlCommand(sql, conn);
                if (parameters != null)
                {
                    foreach (var p in parameters)
                        cmd.Parameters.AddWithValue(p.Key, p.Value);
                }
                Debug.WriteLine(e.ToString());
                return cmd.ExecuteNonQuery();
            }
            
        }
        // SELECT signel data
        public static object ExecuteScalar(string sql, Dictionary<string, object> parameters = null)
        {
            try
            {
                using var conn = new NpgsqlConnection(ConnectionString);

                conn.Open();

                using var cmd = new NpgsqlCommand(sql, conn);
                if (parameters != null)
                {
                    foreach (var p in parameters)
                        cmd.Parameters.AddWithValue(p.Key, p.Value);
                }

                return cmd.ExecuteScalar();
            }
            catch (Exception e)
            {
                using var conn = new NpgsqlConnection(ConnectionString2);
                conn.Open();

                using var cmd = new NpgsqlCommand(sql, conn);
                if (parameters != null)
                {
                    foreach (var p in parameters)
                        cmd.Parameters.AddWithValue(p.Key, p.Value);
                }

                Debug.WriteLine(e.ToString());

                return cmd.ExecuteScalar();
            }
        }
        // SELECT muli data with a reader
        public static List<Dictionary<string, object>> ExecuteQuery(string sql, Dictionary<string, object> parameters = null)
        {

            try
            {
                var result = new List<Dictionary<string, object>>();


                using var conn = new NpgsqlConnection(ConnectionString);
                conn.Open();

                using var cmd = new NpgsqlCommand(sql, conn);
                if (parameters != null)
                {
                    foreach (var p in parameters)
                        cmd.Parameters.AddWithValue(p.Key, p.Value);
                }

                using var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    var row = new Dictionary<string, object>();
                    for (int i = 0; i < reader.FieldCount; i++)
                    {
                        row[reader.GetName(i)] = reader.GetValue(i);
                    }
                    result.Add(row);
                }

                return result;
            }
            catch (Exception e)
            {
                var result = new List<Dictionary<string, object>>();


                using var conn = new NpgsqlConnection(ConnectionString2);
                conn.Open();

                using var cmd = new NpgsqlCommand(sql, conn);
                if (parameters != null)
                {
                    foreach (var p in parameters)
                        cmd.Parameters.AddWithValue(p.Key, p.Value);
                }

                using var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    var row = new Dictionary<string, object>();
                    for (int i = 0; i < reader.FieldCount; i++)
                    {
                        row[reader.GetName(i)] = reader.GetValue(i);
                    }
                    result.Add(row);
                }

                Debug.WriteLine(e.ToString());
                return result;
            }
        }

        // user related
        public static string GetHashedPasswordFromDatabase(string username)
        {
            Debug.WriteLine("GetHashedPasswordFromDatabase");
            string sql = @"
                SELECT up.hashed_password
                FROM users u
                INNER JOIN userpasswords up ON u.user_id = up.user_id
                WHERE u.username = @username;";
            
            var parameters = new Dictionary<string, object>
            {
                { "@username", username }
            };

            var result = ExecuteQuery(sql, parameters);

            if(result.Count == 0)
            {
                return null;
            }
            else
            {
                return Convert.ToString(result[0]["hashed_password"]);
            }
        }
        public static string GetSaltFromDatabase(string username) // Didn't pass userid as parameter because we can get it from username in the same query, and this way we can avoid an extra query to get userid first
        {
            Debug.WriteLine("GetSaltFromDatabase");
            string sql = @"
                SELECT up.salt
                FROM users u
                INNER JOIN userpasswords up ON u.user_id = up.user_id
                WHERE u.username = @username";
            var parameters = new Dictionary<string, object>
            {
                { "@username", username }
            };

            var result = ExecuteQuery(sql, parameters);
            if (result.Count == 0)
            {
                return null;
            }

            Debug.WriteLine($"Salt retrieved: {Convert.ToString(result[0]["salt"])}");
            return Convert.ToString(result[0]["salt"]);
        } 
        public static bool InsertUserIntoDatabase(SignupUser user)
        { 
            string sql = @"
                INSERT INTO users (username, user_email, created_at, last_login)
                VALUES (@username, @email, @created_at, @last_login )";

            var parameters = new Dictionary<string, object>
            {
                { "@username", user.Username },
                { "@email", user.Email },
                { "@created_at", user.CreatedAt },
                { "@last_login", DateTime.Now }
            };
            Debug.WriteLine($"HashedPassword: {user.HashedPassword}");
            Debug.WriteLine($"Salt: {user.Salt}");

            ExecuteNonQuery(sql, parameters);
            return true;
        }
        public static bool InsertUserPasswordSaltIntoDatabase(SignupUser user)
        {
            string sql = @"
                INSERT INTO userpasswords (user_id, hashed_password, salt)
                VALUES (
                    (SELECT user_id FROM users WHERE username = @username),
                    @hashed_password,
                    @salt
                )";

            var parameters = new Dictionary<string, object>
            {
                { "@username", user.Username},
                { "@hashed_password", user.HashedPassword},
                { "@salt", user.Salt}
            };

            ExecuteNonQuery(sql, parameters);
            return true;

        }
        public static int GetUserIdFromDatabase(string username)
        {
            string sql = @"
                SELECT user_id
                FROM users
                Where username = @username";
            var parameters = new Dictionary<string, object>
            {
                { "@username", username }
            };
            return Convert.ToInt32(ExecuteScalar(sql, parameters));
        }
        public static DateTime GetLastLogin(int UserId)
        {
            string sql = @"
            SELECT last_login
            FROM users
            Where user_id = @userID";

            var parameters = new Dictionary<string, object>
            {
                { "@userID",UserId}
            };

            var result = ExecuteScalar(sql, parameters);
            if (result == null || result == DBNull.Value)
                return DateTime.Now;

            return Convert.ToDateTime(result);
        }

        // user prefence related
        public static UserSettings GetUserSettingsFromDatabase(int userID)
        {
            string sql = @"
                SELECT max_daily_tasks, region, enable_notifcations, max_holiday_daily_tasks
                FROM usersettings
                WHERE user_id = @userID";   

            var parameters = new Dictionary<string, object>
            {
                { "@userID", userID }
            };
            var result = ExecuteQuery(sql, parameters);
            if (result.Count == 0)
            {
                return null;
            }
            else
            {
                var row = result[0];
                return new UserSettings
                {
                    maxDailyTasks = Convert.ToInt32(row["max_daily_tasks"]),
                    Region = Convert.ToString(row["region"]),
                    taskReminderEnabled = Convert.ToBoolean(row["enable_notifications"]),
                    maxHoildayDailyTasks = Convert.ToInt32(row["max_holiday_daily_tasks"])
                };
            }

        }
        public static void UpdateUserSettingsInDatabase(int userId, UserSettings userSettings)
        {
            string sql = @"
                UPDATE usersettings
                SET max_daily_tasks = @maxDailyTasks,
                    region = @region,
                    enable_notifications = @taskReminderEnabled,       
                    max_holiday_daily_tasks = @maxHoildayDailyTasks
                WHERE user_id = @userId;";

            var parameters = new Dictionary<string, object>
            {
                { "@maxDailyTasks", userSettings.maxDailyTasks },
                { "@region", userSettings.Region },
                { "@taskReminderEnabled", userSettings.taskReminderEnabled },
                { "@maxHoildayDailyTasks", userSettings.maxHoildayDailyTasks },
                { "@userId", userId }
            };

            ExecuteNonQuery(sql, parameters);
        }
        public static void InsertUserSettingsInDatabase(int userId, UserSettings userSettings)
        {
            string sql = @"
                INSERT INTO usersettings (user_id, max_daily_tasks, region, enable_notifications, max_holiday_daily_tasks)
                VALUES (@userId, @maxDailyTasks, @region, @taskReminderEnabled, @maxHoildayDailyTasks)";

            var parameters = new Dictionary<string, object>
            {
                { "@maxDailyTasks", userSettings.maxDailyTasks },
                { "@region", userSettings.Region },
                { "@taskReminderEnabled", userSettings.taskReminderEnabled },
                { "@maxHoildayDailyTasks", userSettings.maxHoildayDailyTasks },
                { "@userId", userId }
            };

            ExecuteNonQuery(sql, parameters);
        }
        // task related
        public static List<Logic.Task> GetTasksFromDatabase(int userId)
        {
            string sql = $@"
                SELECT t.task_id, t.description, t.priority, t.estimated_min, t.subject_id, t.due_date, t.completed, t.completed_at, t.created_at,
                       COALESCE(s.subject_name, 'No Subject') as subject_name
                FROM tasks t
                LEFT JOIN subjects s ON t.subject_id = s.subject_id
                WHERE t.user_id = @userID";

            var parameters = new Dictionary<string, object>
            {
                { "@userID", userId}
            };

            var results = ExecuteQuery(sql, parameters);

            var tasks = new List<Logic.Task>(); // load the data into task objects
            foreach (var row in results)
            {
                tasks.Add(new Logic.Task
                {
                    UserId = userId,
                    TaskId = Convert.ToInt32(row["task_id"]),
                    Description = Convert.ToString(row["description"]),
                    Priority = Convert.ToInt32(row["priority"]),
                    EstimatedMinutes = Convert.ToInt32(row["estimated_min"]),
                    SubjectId = row["subject_id"] != DBNull.Value ? Convert.ToInt32(row["subject_id"]) : (int?)null,
                    subjectname = Convert.ToString(row["subject_name"]),
                    DueDate = row["due_date"] != DBNull.Value ? Convert.ToDateTime(row["due_date"]) : (DateTime?)null,
                    Completed = Convert.ToBoolean(row["completed"]),
                    CompletedAt = row["completed_at"] != DBNull.Value ? Convert.ToDateTime(row["completed_at"]) : (DateTime?)null,
                    CreatedAt = Convert.ToDateTime(row["created_at"])
                });
            }

            Debug.WriteLine($"Retrieved {tasks.Count} task for user {userId}");
            return tasks;
        }
        public static void InsertTaskIntoDatabase(Logic.Task task)
        {
            string sql = @"INSERT INTO tasks (user_id, description, priority, estimated_min, due_date, created_at, subject_id, completed) 
                VALUES (@userId, @description, @priority, @estimated_min, @due_date, @created_at, @subject_id, @completed);";

            var parameters = new Dictionary<string, object>
            {
                { "@userId", task.UserId},
                { "@description", task.Description},
                { "@priority", task.Priority },
                { "@estimated_min", task.EstimatedMinutes },
                { "@due_date", task.DueDate },
                { "@created_at", task.CreatedAt },
                { "@subject_id", task.SubjectId },
                { "@completed", task.Completed }
            };

            ExecuteNonQuery(sql, parameters);
            Debug.WriteLine("Insert Task Into Database");
        }
        public static void UpdateTaskInDatabase(Logic.Task task)
        {
            string sql = @"UPDATE tasks 
                SET description = @description,
                    priority = @priority,
                    estimated_min = @estimated_min, 
                    due_date = @due_date, 
                    subject_id = @subject_id,
                    completed = @completed,
                    completed_at = @completed_at
                WHERE task_id = @task_id
                AND user_id = @userId;";

            var parameters = new Dictionary<string, object>
            {
                { "@description", task.Description},
                { "@priority", task.Priority },
                { "@estimated_min", task.EstimatedMinutes },
                { "@due_date", task.DueDate },
                { "@subject_id", task.SubjectId },
                { "@task_id", task.TaskId },
                { "@userId", task.UserId },
                { "@completed", task.Completed },
                { "@completed_at", task.CompletedAt }
            };
            
            ExecuteNonQuery(sql, parameters);
            Debug.WriteLine("Update Task In Database");

        }
        
        public static void DeleteTaskFromDatabase(int taskId, int userId)
        {
            string sql = @"DELETE FROM tasks 
                WHERE task_id = @taskId
                AND user_id = @userId;";

            var parameters = new Dictionary<string, object>
            {
                { "@taskId", taskId},
                { "@userId", userId}
            };  

            ExecuteNonQuery(sql, parameters);
            Debug.WriteLine("Delete Task From Database");
        }
       
        public static int GetNumberOfTasksFromDatabse(int userId)
        {
            string sql = @"
            SELECT COUNT(*)
            FROM tasks
            WHERE user_id = @userId";

            var parameters = new Dictionary<string, object>
            {
                { @"user_id", userId }
            };

            var results = ExecuteScalar(sql, parameters);
            return Convert.ToInt32(results);

        }

        // subject related
        public static List<Subject> GetSubjectsFromDatabase(int UserId)
        {
            string sql = @"
                SELECT subject_id, subject_name, user_id
                FROM subjects
                WHERE user_id = @userID";

            var parameters = new Dictionary<string, object>
            {
                { "@userID", UserId}
            };

            var results = ExecuteQuery(sql, parameters);
            var subjects = new List<Logic.Subject>();

            foreach (var row in results)
            {
                subjects.Add(new Subject
                {
                    SubjectId = Convert.ToInt32(row["subject_id"]),
                    Name = Convert.ToString(row["subject_name"]),
                    UserId = Convert.ToInt32(row["user_id"])
                });
            }

            Debug.WriteLine($"Retrieved {subjects.Count} subjects for user {UserId}");
            return subjects;
        }
        public static string GetSubjectNameFromDatabse(int userId, int subjectId)
        {
            string sql = @"
                SELECT subject_name
                FROM subjects
                WHERE subjects.user_id = @userId
                AND subject_id = @subjectId;";

            var parameters = new Dictionary<string, object>
            {
                { "@userId", userId },
                { "@subjectId", subjectId }
            };

            var result = ExecuteScalar(sql, parameters);
            Debug.WriteLine($"{result.ToString()}");
            return Convert.ToString(result);
;
        }
        public static int GetSubjectIdFromDatabase(int userID, string subjectName)
        {
            string sql = @"
                SELECT subject_id
                FROM subjects
                WHERE subjects.user_id = @userId
                AND subject_name = @subjectName";

            var parameters = new Dictionary<string, object>
            {
                { "@userId", userID },
                { "@subjectName", subjectName }
            };

            var result = ExecuteScalar(sql, parameters);
            Debug.WriteLine($"{result.ToString()}");
            return Convert.ToInt32(result);
        }
        public static void InsertSubjectIntoDatabase(string subjectName, int userId)
        {
            string sql = @"
                INSERT INTO subjects (subject_name, user_id)
                VALUES (@subjectName, @userID)";
            
            var parameters = new Dictionary<string, object>
            {
                { "@subjectName", subjectName },
                { "@userID", userId}
            };
            Debug.WriteLine("InsertSubjectIntoDatabase");
            ExecuteNonQuery(sql, parameters);
            
        }
        public static void DeleteSubjectFromDatabase(string subjectName, int userId)
        {
            string sql = @"
                DELETE FROM subjects
                WHERE user_id = @userId
                AND subject_name = @subjectName;";

            var parameters = new Dictionary<string, object>
            {
                { "@userId", userId },
                { "@subjectName", subjectName }
            };

            ExecuteNonQuery(sql, parameters);
        }

        public static void GetSubjectTimeStatsFromDatabse()
        {
            string sql = @"
                SELECT s.subject_name, 
                SUM(t.estimated_min) as total_minutes,
                COUNT(t.task_id) as task_count,
                AVG(t.priority) as avg_priority
                FROM subjects s
                LEFT JOIN tasks t ON s.subject_id = t.subject_id
                INNER JOIN users u ON s.user_id = u.user_id
                INNER JOIN usersettings us ON u.user_id = us.user_id
                WHERE s.user_id = @userID
                GROUP BY s.subject_name;
";
        }
        
        public static void GgetSubjectCompletionRateFromDatabase()
        {
            string sql = @"
                SELECT s.subject_name,
                COUNT(t.task_id) as total,
                SUM(CASE WHEN t.completed = true THEN 1 ELSE 0 END) as completed,
                (SUM(CASE WHEN t.completed = true THEN 1 ELSE 0 END)::float / COUNT(t.task_id) * 100) as rate
                FROM subjects s
                INNER JOIN tasks t ON s.subject_id = t.subject_id
                INNER JOIN users u ON t.user_id = u.user_id
                LEFT JOIN usersettings us ON u.user_id = us.user_id
                WHERE t.user_id = @userID
                GROUP BY s.subject_name;";
        }
        // plan related
        public static void GetPlansFromDatabase()
        {
            string sql = $@"
                SELECT plan_id
                FROM plans
                WHERE plan_date = {DateTime.Now.Date};";

        }

        public static void InsertPlanIntoDatabase()
        {
            string sql = @"
                INSERT INTO plans
                ;";
        }

        // Statistics methods for ReportStatsPage
        public static int GetTotalTaskCount(int userId)
        {
            string sql = "SELECT COUNT(*) FROM tasks WHERE user_id = @userID";
            var parameters = new Dictionary<string, object> { { "@userID", userId } };
            var result = ExecuteScalar(sql, parameters);
            return Convert.ToInt32(result);
        }

        public static int GetCompletedTaskCount(int userId)
        {
            string sql = "SELECT COUNT(*) FROM tasks WHERE user_id = @userID AND completed = true";
            var parameters = new Dictionary<string, object> { { "@userID", userId } };
            var result = ExecuteScalar(sql, parameters);
            return Convert.ToInt32(result);
        }

        public static int GetOverdueTaskCount(int userId)
        {
            string sql = "SELECT COUNT(*) FROM tasks WHERE user_id = @userID AND completed = false AND due_date < @today";
            var parameters = new Dictionary<string, object> 
            { 
                { "@userID", userId },
                { "@today", DateTime.Now.Date }
            };
            var result = ExecuteScalar(sql, parameters);
            return Convert.ToInt32(result);
        }

        public static int GetTotalStudyMinutes(int userId)
        {
            string sql = "SELECT COALESCE(SUM(estimated_min), 0) FROM tasks WHERE user_id = @userID";
            var parameters = new Dictionary<string, object> { { "@userID", userId } };
            var result = ExecuteScalar(sql, parameters);
            return Convert.ToInt32(result);
        }

        public static int GetTotalSubjectCount(int userId)
        {
            string sql = "SELECT COUNT(*) FROM subjects WHERE user_id = @userID";
            var parameters = new Dictionary<string, object> { { "@userID", userId } };
            var result = ExecuteScalar(sql, parameters);
            return Convert.ToInt32(result);
        }

        public static Dictionary<string, int> GetSubjectTimeStats(int userId)
        {
            string sql = @"
                SELECT s.subject_name, COALESCE(SUM(t.estimated_min), 0) as total_minutes
                FROM subjects s
                LEFT JOIN tasks t ON s.subject_id = t.subject_id
                WHERE s.user_id = @userID
                GROUP BY s.subject_name";
            var parameters = new Dictionary<string, object> { { "@userID", userId } };
            var results = ExecuteQuery(sql, parameters);
            var stats = new Dictionary<string, int>();
            foreach (var row in results)
            {
                stats[Convert.ToString(row["subject_name"])] = Convert.ToInt32(row["total_minutes"]);
            }
            return stats;
        }

        public static void DeleteUserAccount(int userId)
        {
            ExecuteNonQuery("DELETE FROM tasks WHERE user_id = @userId", new Dictionary<string, object> { { "@userId", userId } });
            ExecuteNonQuery("DELETE FROM subjects WHERE user_id = @userId", new Dictionary<string, object> { { "@userId", userId } });
            ExecuteNonQuery("DELETE FROM usersettings WHERE user_id = @userId", new Dictionary<string, object> { { "@userId", userId } });
            ExecuteNonQuery("DELETE FROM userpasswords WHERE user_id = @userId", new Dictionary<string, object> { { "@userId", userId } });
            ExecuteNonQuery("DELETE FROM users WHERE user_id = @userId", new Dictionary<string, object> { { "@userId", userId } });
        }
    }
}
