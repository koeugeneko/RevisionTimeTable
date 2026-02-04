using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeTable.Logic
{
    internal class SubjectService
    {
        public void AddNewTask(string name)
        {
            Subject subject = new Subject();
            subject.Name = name;


        }

        public void DeleteTask(string name) { }
    }
}
