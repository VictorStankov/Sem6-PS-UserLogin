namespace StudentInfoSystem
{
    public class Student
    {
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string Surname { get; set; }
        public string Faculty { get; set; }
        public string Specialty { get; set; }
        public string Degree { get; set; }
        public int FacultyNum { get; set; }
        public int Year { get; set; }
        public int Stream { get; set; }
        public int Group { get; set; }
        public int Status { get; set; }
        public int StudentId { get; set; }

        public Student(int studentId, string firstName, string middleName, string surname, string faculty, string specialty,
            string degree, int facultyNum, int year, int stream, int group, int status)
        {
            StudentId = studentId;
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
