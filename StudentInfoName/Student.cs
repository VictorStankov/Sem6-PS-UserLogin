namespace StudentInfoName
{
    class Student
    {
        public string FirstName, MiddleName, Surname, Faculty, Specialty, Degree;
        public int FacultyNum, Year, Stream, Group;

        public Student(string firstName, string middleName, string surname, string faculty, string specialty,
            string degree, int facultyNum, int year, int stream, int group)
        {
            this.FirstName = firstName;
            this.MiddleName = middleName;
            this.Surname = surname;
            this.Faculty = faculty;
            this.Specialty = specialty;
            this.Degree = degree;
            this.FacultyNum = facultyNum;
            this.Year = year;
            this.Stream = stream;
            this.Group = group;
        }
    }
}
