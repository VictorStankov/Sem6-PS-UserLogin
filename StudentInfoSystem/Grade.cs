namespace StudentInfoSystem
{
    class Grade
    {
        public int GradeId { get; set; }
        public Student Student { get; set; }
        public string ClassName { get; set; }
        public int GradeNum { get; set; }

        public Grade() { }
        public Grade(Student student, string className, int gradeNum)
        {
            Student = student;
            ClassName = className;
            GradeNum = gradeNum;
        }
    }

    struct GradeShort
    {
        public int Grade { get; set; }
        public string ClassName { get; set; }

        public GradeShort(int grade, string className)
        {
            Grade = grade;
            ClassName = className;
        }

        public override string ToString()
        {
            return $"{ClassName} - {Grade}";
        }
    }
}
