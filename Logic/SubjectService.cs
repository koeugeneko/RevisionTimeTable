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
        private int userId; 
        public SubjectService(int userId)
        {
            this.userId = userId;
        }

        public static void AddNewSubject(string subjectName)
        {   
            Subject subject = new Subject();
            subject.Name = subjectName;

            DataLayer.InsertSubjectIntoDatabase(subject.Name, userId);
        }

        public void DeleteTask(string name)
        {
        }
    }
}
