using System.Collections.Generic;

namespace StudentInfoName
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
            
            _testStudents.Add(new Student("Ivan", "Ivanov", "Ivanov", "FCST", "CSE", "bachelor", 1, 1, 1, 1, true));
            _testStudents.Add(new Student("Georgi", "Georgiev", "Georgiev", "FPMI", "PF", "bachelor", 2, 2, 2, 2, true));
        }
    }
}
