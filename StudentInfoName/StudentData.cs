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

        public static Student IsThereStudent(int facNum)
        {
            StudentInfoContext context = new StudentInfoContext();

            return context.Students.Where(st => st.FacultyNum == facNum).FirstOrDefault();
        }

        private static List<Student> GetStudents()
        {
            StudentInfoContext context = new StudentInfoContext();
            return context.Students.ToList();
        }


        public static bool TestStudentsIfEmpty()
        {
            StudentInfoContext context = new StudentInfoContext();

            return !context.Students.Any();
        }

        public static void CopyTestStudents()
        {
            StudentInfoContext context = new StudentInfoContext();

            foreach (Student st in TestStudents)
                context.Students.Add(st);

            context.SaveChanges();
        }
    }
}
