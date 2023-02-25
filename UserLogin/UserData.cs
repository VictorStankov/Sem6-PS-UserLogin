using System;
using System.Collections.Generic;

namespace UserLogin
{
    static class UserData
    {
        public static List<User> TestUsers
        {
            get
            {
                ResetTestUserData();
                return _testUsers;
            }
            set { }
        }
        private static List<User> _testUsers;

        private static void ResetTestUserData()
        {
            if (_testUsers == null)
                _testUsers = new List<User>();

            _testUsers.Add(new User("admin", "admin", 1, (int)UserRoles.ADMIN, DateTime.UtcNow, DateTime.MaxValue));
            _testUsers.Add(new User("student_1", "asddsa", 2, (int)UserRoles.STUDENT, DateTime.UtcNow, DateTime.MaxValue));
            _testUsers.Add(new User("student_2", "asddsa", 3, (int)UserRoles.STUDENT, DateTime.UtcNow, DateTime.MaxValue));
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
            Logger.LogActivity($"Change expiry date of user '{username}'");
            foreach (User user in _testUsers)
                if (user.username == username)
                {
                    user.validUntil = date;
                    break;
                }
        }

        public static void AssignUserRole(String username, UserRoles role)
        {
            Logger.LogActivity($"Change role of user '{username}'");
            foreach (User user in _testUsers)
                if (user.username == username)
                {
                    user.role = (Int32)role;
                    break;
                }
        }
    }
}
