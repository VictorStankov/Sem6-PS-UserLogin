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
            else
                _testUsers.Clear();

            _testUsers.Add(new User("admin", "admin", 1, (int)UserRoles.ADMIN, DateTime.UtcNow, DateTime.MaxValue));
            _testUsers.Add(new User("student_1", "asddsa", 2, (int)UserRoles.STUDENT, DateTime.UtcNow, DateTime.MaxValue));
            _testUsers.Add(new User("student_2", "asddsa", 3, (int)UserRoles.STUDENT, DateTime.UtcNow, DateTime.MaxValue));
        }

        public static User IsUserPassCorrect(string username, string password)
        {
            ResetTestUserData();

            foreach (User user in _testUsers)
                if (username == user.Username && password == user.Password)
                    return user;

            return null;
        }

        public static bool UserExists(string username)
        {
            foreach (User user in _testUsers)
                if (username == user.Username)
                    return true;
            return false;
        }

        public static void SetUserActiveTo(string username, DateTime date)
        {
            Logger.LogActivity($"Change expiry date of user '{username}'");
            foreach (User user in _testUsers)
                if (user.Username == username)
                {
                    user.ValidUntil = date;
                    break;
                }
        }

        public static void AssignUserRole(string username, UserRoles role)
        {
            Logger.LogActivity($"Change role of user '{username}'");
            foreach (User user in _testUsers)
                if (user.Username == username)
                {
                    user.Role = (int)role;
                    break;
                }
        }
    }
}
