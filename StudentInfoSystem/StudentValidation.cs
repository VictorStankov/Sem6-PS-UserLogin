using UserLogin;
using System.Linq;

namespace StudentInfoSystem
{
    static class StudentValidation
    {
        public static Student GetStudentDataByUser(User user)
        {
            return (from student in StudentData.TestStudents where student.FacultyNum == user.FacultyNum select student).FirstOrDefault();
        }
    }
}
