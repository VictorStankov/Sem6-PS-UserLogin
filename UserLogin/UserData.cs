using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserLogin
{
    static class UserData
    {
        static public User[] TestUsers
        {
            get
            {
                ResetTestUserData();
                return _testUsers;
            }
            set { }
        }
        static private User[] _testUsers;

        static private void ResetTestUserData()
        {
            if (_testUsers == null)
                _testUsers = new User[3];

            _testUsers[0] = new User("admin", "admin", 1, (int)UserRoles.ADMIN, DateTime.UtcNow, DateTime.MaxValue);
            _testUsers[1] = new User("student_1", "asddsa", 2, (int)UserRoles.STUDENT, DateTime.UtcNow, DateTime.MaxValue);
            _testUsers[2] = new User("student_2", "asddsa", 3, (int)UserRoles.STUDENT, DateTime.UtcNow, DateTime.MaxValue);
        }

        static public User IsUserPassCorrect(String username, String password)
        {
            ResetTestUserData();

            foreach (User user in _testUsers)
                if (username == user.username && password == user.password)
                    return user;

            return null;
        }
    }
}
