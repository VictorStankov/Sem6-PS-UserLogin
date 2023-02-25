using System;

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
        private static User[] _testUsers;

        private static void ResetTestUserData()
        {
            if (_testUsers == null)
                _testUsers = new User[3];

            _testUsers[0] = new User("admin", "admin", 1, (int)UserRoles.ADMIN, DateTime.UtcNow, DateTime.MaxValue);
            _testUsers[1] = new User("student_1", "asddsa", 2, (int)UserRoles.STUDENT, DateTime.UtcNow, DateTime.MaxValue);
            _testUsers[2] = new User("student_2", "asddsa", 3, (int)UserRoles.STUDENT, DateTime.UtcNow, DateTime.MaxValue);
        }

        public static User IsUserPassCorrect(String username, String password)
        {
            ResetTestUserData();

            foreach (User user in _testUsers)
                if (username == user.username && password == user.password)
                    return user;

            return null;
        }

        public static bool UserExists(String username)
        {
            foreach (User user in _testUsers)
                if (username == user.username)
                    return true;
            return false;
        }

        public static void SetUserActiveTo(String username, DateTime date)
        {
            foreach (User user in _testUsers)
                if (user.username == username)
                {
                    user.validUntil = date;
                    break;
                }
        }

        public static void AssignUserRole(String username, UserRoles role)
        {
            foreach (User user in _testUsers)
                if (user.username == username)
                {
                    user.role = (Int32)role;
                    break;
                }
        }
    }
}
