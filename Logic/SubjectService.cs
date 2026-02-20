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
        public static bool AddNewSubject(string subjectName)
        {   
            List<Subject> subjects= DataLayer.GetSubjectsFromDatabase(CurrentUser.UserId);

            foreach (Subject subject in subjects)
            {
                if (subject.Name.Equals(subjectName, StringComparison.OrdinalIgnoreCase))
                {
                    return false; // Subject already exists, do not add
                }
            }
            DataLayer.InsertSubjectIntoDatabase(subjectName, CurrentUser.UserId);
            return true;
        }

        public static List<Subject> GetSubjectsForCurrentUser()
        {
            return DataLayer.GetSubjectsFromDatabase(CurrentUser.UserId);
        }

        public static void DeleteSubject(string subjectName)
        {
            DataLayer.DeleteSubjectFromDatabase(subjectName, CurrentUser.UserId);   
        }
    }
}
