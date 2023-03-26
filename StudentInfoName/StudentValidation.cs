using UserLogin;
using System.Linq;

namespace StudentInfoSystem
{
    class StudentValidation
    {
        public Student GetStudentDataByUser(User user)
        {
            return (from student in StudentData.TestStudents where student.FacultyNum == user.FacultyNum select student).FirstOrDefault();
        }
    }
}
