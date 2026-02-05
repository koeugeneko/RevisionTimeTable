using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeTable.Data;

namespace TimeTable.Logic
{
    public class SubjectService
    {
        public static void AddNewTask(string subjectName)
        {   
            Subject subject = new Subject();
            subject.Name = subjectName;

            DataLayer.InsertSubjectIntoDatabase(subject, user);
        }

        public void DeleteTask(string name)
        {
        }
    }
}
