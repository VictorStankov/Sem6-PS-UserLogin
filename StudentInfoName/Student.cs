namespace StudentInfoName
{
    class Student
    {
        public string FirstName, MiddleName, Surname, Faculty, Specialty, Degree;
        public int FacNum, Year, Stream, Group;

        public Student(string firstName, string middleName, string surname, string faculty, string specialty,
            string degree, int facNum, int year, int stream, int group)
        {
            this.FirstName = firstName;
            this.MiddleName = middleName;
            this.Surname = surname;
            this.Faculty = faculty;
            this.Specialty = specialty;
            this.Degree = degree;
            this.FacNum = facNum;
            this.Year = year;
            this.Stream = stream;
            this.Group = group;
        }
    }
}
