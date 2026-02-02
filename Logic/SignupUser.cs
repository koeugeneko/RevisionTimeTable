using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeTable.Logic
{
    public class SignupUser : User
    {   
        public string HashedPassword { get; set; }
        public string Salt { get; set; }
    }
}
