using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using TimeTable.Data;

namespace TimeTable.Logic
{
    internal static class AuthService
    {   
        public static bool SignUp(string username, string password, string email)
        {
            User user = new User();
            if (!ValidateUsername(username)) return false;
            if (!ValidatePassword(password)) return false;
            if (!ValidateEmail(email)) return false;
            return true;
        }

        public static bool Login(string username, string password)
        {
            User user = new User();
            TimeTable.Data.DataLayer.GetHashedPasswordFromDatabase(user);
            return true;
        }

        public static bool ValidateUsername(string username)
        {
            if (string.IsNullOrEmpty(username)) return false; // check if username is empty

            string pattern = @"^[A-Za-z0-9_]{6,50}$";
            return Regex.IsMatch(username, pattern);

            /*else if (username.Length < 6 || username.Length > 50) // check if username length is between 5 and 12
            {
                return false;
            }
            return true;*/
        }
        public static bool ValidateEmail(string email)
        {
            string pattern = @"^[\w\.-]+@[\w\.-]+\.\w+$";
            return Regex.IsMatch(email, pattern);
        }
        public static bool ValidatePassword(string password)
        {
            if (string.IsNullOrEmpty(password)) return false; // check if password is empty

            string pattern = @"^(?=.*[A-Z])(?=.*\d)[A-Za-z\d!@#$%^&*]{8,16}$";
            return Regex.IsMatch(password, pattern);

            /*else if (password.Length < 8 || password.Length > 16) // check if password length is between 8 and 16
            {
                return false;
            }

            bool containsUpper = false; // check if password contains at least 1 Upper case
            foreach (char c in password)
            {
                if (char.IsUpper(c))
                {
                    containsUpper = true;
                    break;
                }
            }
            if (!containsUpper)
            {
                return false;
            }

            bool containsNumber = false; // check if password contains at least 1 number
            foreach (char c in password)
            {
                if (char.IsDigit(c))
                {
                    containsNumber = true;
                    break;
                }
            }
            if (!containsNumber)
            {
                return false;
            }

            return true;*/
        }
        public static string HashPassword(string username, string password)
        {
            int iterations = 2;
            int saltLength = 16;
            string salt = GenerateSalt(saltLength);

            string plaintext = username + password + salt;

            for (int i = 0; i < iterations; i++) // run ahash a few times
            {
                int hash = 0;
                foreach (char c in plaintext)
                {
                    hash += ((int)c * (i + 1)) ^ (i + 7); // ASCII + postion + XOR
                }
                plaintext = hash.ToString();
            }
            return plaintext;

        }
        public static string GenerateSalt(int saltLength)
        {
            var rng = new Random();
            char[] chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789".ToCharArray();
            char[] salt = new char[saltLength];
            for (int i = 0; i < saltLength; i++)
                salt[i] = chars[rng.Next(chars.Length)];
            return new string(salt);
        }

        //public static 

    }
}
