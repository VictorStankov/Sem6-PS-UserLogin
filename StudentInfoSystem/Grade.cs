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
}
