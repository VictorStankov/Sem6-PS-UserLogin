using System.Collections.Generic;

namespace StudentInfoName
{
    class StudentData
    {
        public List<Student> TestStudents
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
            
            _testStudents.Add(new Student("Ivan", "Ivanov", "Ivanov", "FCST", "CSE", "bachelor", 1, 1, 1, 1));
        }
    }
}
