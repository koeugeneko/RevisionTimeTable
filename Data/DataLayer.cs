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
                { "@hashed_password", user.HashedPassword },
                { "@created_at", user.CreatedAt },
                { "@last_login", user.lastLogin }
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

            DateTime lastLogin = Convert.ToDateTime(ExecuteScalar(sql));
            return lastLogin;

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
                    taskReminderEnabled = Convert.ToBoolean(row["enable_notifcation"]),
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
                    enable_notifcation = @taskReminderEnabled,       
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
        }

        // task related
        public static List<Logic.Task> GetTasksFromDatabase(int userId)
        {
            string sql = $@"
                SELECT task_id, description, priority, estimated_min 
                FROM tasks 
                WHERE user_id = @userID";

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
                    EstimatedMinutes = Convert.ToInt32(row["estimated_min"])
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
        public static string GetSubjectNameFromDatabse(int userId, string subjectId)
        {
            string sql = @"
                SELECT subject_name
                FROM subjects
                WHERE Subjects.user_id = @userId
                AND subjectId = @subjectId";

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
    }
}
