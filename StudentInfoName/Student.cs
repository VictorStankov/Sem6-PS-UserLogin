namespace StudentInfoSystem
{
    public class Student
    {
        public string FirstName, MiddleName, Surname, Faculty, Specialty, Degree;
        public int FacultyNum, Year, Stream, Group;
        public bool Status;

        public Student(string firstName, string middleName, string surname, string faculty, string specialty,
            string degree, int facultyNum, int year, int stream, int group, bool status)
        {
            FirstName = firstName;
            MiddleName = middleName;
            Surname = surname;
            Faculty = faculty;
            Specialty = specialty;
            Degree = degree;
            FacultyNum = facultyNum;
            Year = year;
            Stream = stream;
            Group = group;
            Status = status;
        }
    }
}
