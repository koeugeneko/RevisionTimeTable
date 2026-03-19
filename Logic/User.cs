using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeTable.Data;

namespace TimeTable.Logic
{
    public class User
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public int UserId { get; }
        public DateTime CreatedAt { get; set; }
        public DateTime lastLogin { get; set; }
        public int userAccessLevel { get; set; }


    }
}
