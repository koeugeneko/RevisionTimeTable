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
            DataLayer.InsertSubjectIntoDatabase(subjectName, CurrentUser.UserId);

        }

        public static List<Subject> GetSubjectsForCurrentUser()
        {
            return DataLayer.GetSubjectsFromDatabase(CurrentUser.UserId);
        }

        public void DeleteTask(string subjectName)
        {
            DataLayer.DeleteSubjectFromDatabase(subjectName, CurrentUser.UserId);   
        }
    }
}
