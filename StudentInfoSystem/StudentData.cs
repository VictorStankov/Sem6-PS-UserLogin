using System.Collections.Generic;
using System.Linq;

namespace StudentInfoSystem
{
    static class StudentData
    {
        public static List<Student> TestStudents
        {
            get
            {
                ResetTestStudents();
                return _testStudents;
            }
            private set { }
        }

        private static List<Student> _testStudents;

        public static void ResetTestStudents()
        {
            if (_testStudents == null)
                _testStudents = new List<Student>();
            else
                _testStudents.Clear();

            _testStudents.Add(new Student(0, "Ivan", "Ivanov", "Ivanov", "FCST", "CSE", "bachelor", 1, 1, 1, 1, 1));
            _testStudents.Add(new Student(1, "Georgi", "Georgiev", "Georgiev", "FPMI", "PF", "bachelor", 2, 2, 2, 2, 2));
        }

        public static Student StudentExists(int facNum)
        {
            using (var context = new StudentInfoContext())
                return context.Students.FirstOrDefault(st => st.FacultyNum == facNum);
        }

        private static List<Student> GetStudents()
        {
            using(var context = new StudentInfoContext())
                return context.Students.ToList();
        }


        public static bool TestStudentsIfEmpty()
        {
            using(var context = new StudentInfoContext())
                return !context.Students.Any();
        }

        public static void CopyTestStudents()
        {
            using (var context = new StudentInfoContext())
            {
                foreach (Student st in TestStudents)
                    context.Students.Add(st);

                context.SaveChanges();
            }
        }

        public static void DeleteStudent(int facNum)
        {
            using (var context = new StudentInfoContext())
            {
                Student studentDel = context.Students.FirstOrDefault(student => student.FacultyNum == facNum);

                context.Students.Remove(studentDel);
                context.SaveChanges();
            }
        }
    }
}
