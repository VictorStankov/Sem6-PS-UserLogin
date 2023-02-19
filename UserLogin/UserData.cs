using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserLogin
{
    static class UserData
    {
        public static User[] TestUsers
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

            _testUsers[0] = new User("admin", "admin", 1, (int)UserRoles.ADMIN);
            _testUsers[1] = new User("student_1", "asddsa", 2, (int)UserRoles.STUDENT);
            _testUsers[2] = new User("student_2", "asddsa", 3, (int)UserRoles.STUDENT);
        }
    }
}
