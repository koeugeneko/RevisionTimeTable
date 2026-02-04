using Microsoft.VisualBasic.ApplicationServices;
using Npgsql;
using System.Diagnostics;
using TimeTable.Logic;

namespace TimeTable.Data
{
    public class DataLayer
    {
        private static readonly string ConnectionString = "Host=localhost;Port=5432;Database=TimeTable;Username=postgres;Password=Ek002";


        // INSERT / UPDATE / DELETE mutiple data
        public static int ExecuteNonQuery(string sql, Dictionary<string, object> parameters = null)
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
        // SELECT signel data
        public static object ExecuteScalar(string sql, Dictionary<string, object> parameters = null)
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
        // SELECT muli data with a reader
        public static List<Dictionary<string, object>> ExecuteQuery(string sql, Dictionary<string, object> parameters = null)
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

        // user related
        public static string GetHashedPasswordFromDatabase(string username)
        {
            Debug.WriteLine("GetHashedPasswordFromDatabase");
            string sql = @"
                SELECT up.hashed_password
                FROM users u
                INNER JOIN userpasswords up ON u.user_id = up.user_id
                WHERE u.username = @username";
            
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
                return Convert.ToString(result[0]);
            }
        }
        public static string GetSaltFromDatabase(string username)
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
            return Convert.ToString(result[0]);
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
        public static bool InsertUserPasswordIntoDatabase(SignupUser user)
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
        public static Logic.User GetLastLogin(Logic.User user)
        {
            string sql = @"
            SELECT last_login
            FROM users
            Where user_id = @userID
            AND username = @username";

            user.lastLogin = Convert.ToDateTime(ExecuteScalar(sql));
            return user;

        }

        // user prefence related
        public static void UpdateMaxDailyTasks(Logic.User user)
        {
            string sql = @"
            UPDATE usersettins
            set max_daily_task = 
            where user_id = @userID";

            var parameters = new Dictionary<string, object>
            {
                { "@userID", user.UserId}
            };

            ExecuteNonQuery(sql, parameters);
        }

        // task related
        public static void GetTasksFromDatabase()
        {
            string sql = $@"
                SELECT task_id, description, priority, estimated_min 
                FROM tasks WHERE completed = false 
                AND DueDate >= {TimeOnly.FromDateTime(DateTime.Now)}";
        }
        public static void InsertTaskIntoDatabase()
        {
            string sql = @"INSERT INTO tasks (description, priority, estimated_min, due_date, subject_id) VALUES (@description, @priority, @estimated_min, @due_date, @subject_id);";
        }
        public static void UpdateTaskInDatabase()
        {
            string sql = @"UPDATE tasks SET description = @description, priority = @priority, estimated_min = @estimated_min, due_date = @due_date, subject_id = @subject_id WHERE task_id = @task_id;";
        }
        public static void DeleteTaskFromDatabase()
        {
            string sql = @"DELETE FROM tasks WHERE task_id = @task_id;";
        }
        public static void MarkTaskAsCompletedInDatabase()
        {
            string sql = @"UPDATE tasks SET completed = true WHERE task_id = @task_id;";
        }

        // subject related
        public static void GetSubjectsFromDatabase()
        {
            string sql = @"SELECT subject_name
                FROM subjects, users
                JOIN
                WHERE subject.user_id = users.user_id";
        }

        public static void InsertSubjectIntoDatabase()
        {
            string sql = @"INSERT INTO subjects (subject_name, color) VALUES (@subject_name, @color);";
        }
        public static void UpdateSubjectInDatabase()
        {
            string sql = @"UPDATE subjects SET subject_name = @subject_name, color = @color WHERE subject_id = @subject_id;";
        }
        public static void DeleteSubjectFromDatabase()
        {
            string sql = @"DELETE FROM subjects WHERE subject_id = @subject_id;";
        }

        // plan related
        public static void GetPlansFromDatabase()
        {
            string sql = @"SELECT plan_id, plan_name, start_time, end_time, recurrence FROM plans";
        }
        public static void InsertPlanIntoDatabase()
        {
            string sql = @"INSERT INTO plans (plan_name, start_time, end_time, recurrence) VALUES (@plan_name, @start_time, @end_time, @recurrence);";
        }

        
    }
}
