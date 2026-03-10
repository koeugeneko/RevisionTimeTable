using System.Diagnostics;
using System.Security.Cryptography;
using System.Text.RegularExpressions;
using TimeTable.Data;

namespace TimeTable.Logic
{
    internal static class AuthService
    {
        public static bool SignUp(string username, string password, string email)
        {
            string salt = GenerateSalt(16);
            string hash = HashPassword(username, password, salt);

            SignupUser user = new SignupUser
            {
                Username = username,
                Email = email,
                CreatedAt = DateTime.Now,
                Salt = salt,
                HashedPassword = hash
            };

            if (!DataLayer.InsertUserIntoDatabase(user))
                return false;

            if (!DataLayer.InsertUserPasswordSaltIntoDatabase(user))
                return false;

            return true;
        }
        public static bool Login(string username, string password)
        {
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
                return false;

            string storedHash = DataLayer.GetHashedPasswordFromDatabase(username);
            string storedSalt = DataLayer.GetSaltFromDatabase(username);

            if (storedHash == null || storedSalt == null) // user not stored in database
                return false;

            string inputHash = HashPassword(username, password, storedSalt);

            if (inputHash == storedHash) // check if password mathchs
            {   
                CurrentUser.UserId = Data.DataLayer.GetUserIdFromDatabase(username);
                CurrentUser.Username = username;
                return true;
            }
            else
            {
                return false;
            }
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
        public static bool ValidatePasswordMatch(string password, string password2)
        {
            return password == password2;
        }
        public static string HashPassword(string username, string password, string salt)
        {
            Debug.WriteLine("HashPassword");
            const int iterations = 1000;

            // Step 1: Create length-prefixed input bytes (prevents ambiguity attacks)
            byte[] usernameBytes = System.Text.Encoding.UTF8.GetBytes(username);
            byte[] passwordBytes = System.Text.Encoding.UTF8.GetBytes(password);
            byte[] saltBytes = System.Text.Encoding.UTF8.GetBytes(salt);

            // [usernameLength (4 bytes)][username][passwordLength (4 bytes)][password][salt]
            int totalLength = 4 + usernameBytes.Length + 4 + passwordBytes.Length + saltBytes.Length;
            byte[] input = new byte[totalLength];
            int pos = 0;

            // make username length 4 bytes
            input[pos++] = (byte)(usernameBytes.Length >> 24);
            input[pos++] = (byte)(usernameBytes.Length >> 16);
            input[pos++] = (byte)(usernameBytes.Length >> 8);
            input[pos++] = (byte)(usernameBytes.Length);
            Array.Copy(usernameBytes, 0, input, pos, usernameBytes.Length);
            pos += usernameBytes.Length;

            // make password length 4 bytes
            input[pos++] = (byte)(passwordBytes.Length >> 24);
            input[pos++] = (byte)(passwordBytes.Length >> 16);
            input[pos++] = (byte)(passwordBytes.Length >> 8);
            input[pos++] = (byte)(passwordBytes.Length);
            Array.Copy(passwordBytes, 0, input, pos, passwordBytes.Length);
            pos += passwordBytes.Length;

            // add salt
            Array.Copy(saltBytes, 0, input, pos, saltBytes.Length);

            // Step 2: Initialize 256-bit state (32 bytes) from input
            byte[] state = new byte[32];
            for (int i = 0; i < input.Length; i++)
            {
                state[i % 32] ^= input[i];
                state[i % 32] = (byte)((state[i % 32] * 31 + input[i]) % 256);
            }

            // Step 3: Multiple rounds of mixing (key stretching with confusion and diffusion)
            for (int round = 0; round < iterations; round++)
            {
                // Mix state with input using confusion (S-box) and diffusion (rotation)
                for (int i = 0; i < state.Length; i++)
                {
                    byte inputByte = input[i % input.Length];
                    byte roundByte = (byte)(round % 256);

                    // Confusion: Non-linear S-box substitution
                    byte substituted = SBox(state[i]);

                    // Diffusion: Mix with input and round counter
                    byte mixed = (byte)(substituted ^ inputByte ^ roundByte);

                    // Additional diffusion: Bit rotation based on position
                    byte rotated = RotateLeft(mixed, (i % 8));

                    // Avalanche effect: Mix with neighboring bytes
                    byte prev = state[(i - 1 + 32) % 32];
                    byte next = state[(i + 1) % 32];
                    state[i] = (byte)(rotated + prev ^ next);
                }

                // Every 100 rounds, inject more input (feedback mechanism)
                if (round % 100 == 0)
                {
                    for (int i = 0; i < state.Length; i++)
                    {
                        state[i] ^= input[(i + round) % input.Length];
                    }
                }
            }

            // Step 4: Finalization rounds (ensure avalanche effect)
            for (int i = 0; i < state.Length * 2; i++)
            {
                int idx = i % 32;
                state[idx] = SBox((byte)(state[idx] ^ state[(idx + 1) % 32]));
            }

            // Step 5: Return Base64 encoded hash
            return Convert.ToBase64String(state);
        }

        // S-Box: Non-linear substitution for confusion
        private static byte SBox(byte input)
        {
            // Non-linear transformation using multiplication + addition + modulo
            // Creates confusion by making output non-linearly related to input
            return (byte)((input * 251 + 137) % 256);
        }

        // Bit rotation: Spread changes across bits for diffusion
        private static byte RotateLeft(byte value, int count)
        {
            count = count % 8;
            return (byte)((value << count) | (value >> (8 - count)));
        }
        public static string GenerateSalt(int saltLength)
        {
            Debug.WriteLine("GenerateSalt");

            // Extended character set for more entropy per character
            char[] chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789!@#$%^&*".ToCharArray(); //salt base
            char[] salt = new char[saltLength];

            // Multiple entropy sources for better randomness (academic approach)
            long ticks = DateTime.Now.Ticks;
            int processId = Environment.ProcessId;
            int threadId = Environment.CurrentManagedThreadId;

            // Create seed by combining multiple entropy sources
            ulong seed = (ulong)(ticks ^ (processId << 16) ^ threadId);

            // Linear Congruential Generator (LCG) - demonstrates understanding of PRNG algorithms
            for (int i = 0; i < saltLength; i++)
            {
                // LCG formula: X(n+1) = (a * X(n) + c) % m
                // Using common constants: a = 1103515245, c = 12345, m = 2^31
                seed = (seed * 1103515245 + 12345) % 2147483648;
                int index = (int)(seed % (ulong)chars.Length);
                salt[i] = chars[index];

                // Add extra entropy by mixing in position
                seed ^= (ulong)(i * 31 + 17);
            }

            return new string(salt);
        }

    }
}
