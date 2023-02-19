using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserLogin
{
    static class UserData
    {
        public static User TestUser
        {
            get
            {
                ResetTestUserData();
                return _testUser;
            }
            set { }
        }
        static private User _testUser;

        static private void ResetTestUserData()
        {
            if (_testUser == null)
                _testUser = new User();

            _testUser.username = _testUser.password = "admin";
            _testUser.faculty_num = 123456;
            _testUser.role = (int)UserRoles.ADMIN;
        }
    }
}
