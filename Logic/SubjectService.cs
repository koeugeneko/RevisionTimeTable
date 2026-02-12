using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeTable.Data;

namespace TimeTable.Logic
{
    public static class SubjectService
    {  
        public static void AddNewSubject(string subjectName)
        {   
            DataLayer.InsertSubjectIntoDatabase(subjectName, CurrentUser.UserId);
        }

        public static List<Subject> GetSubjectsForCurrentUser()
        {
            return DataLayer.GetSubjectsFromDatabase(CurrentUser.UserId);
        }

        public static void DeleteTask(string subjectName)
        {
            DataLayer.DeleteSubjectFromDatabase(subjectName, CurrentUser.UserId);   
        }
    }
}
