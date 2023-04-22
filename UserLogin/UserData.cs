using System;
using System.Collections.Generic;
using System.Linq;

namespace UserLogin
{
    public static class UserData
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

            _testUsers.Add(new User(0, "admin", "admin", 1, (int)UserRoles.ADMIN, DateTime.UtcNow, DateTime.MaxValue));
            _testUsers.Add(new User(1, "student_1", "asddsa", 2, (int)UserRoles.STUDENT, DateTime.UtcNow, DateTime.MaxValue));
            _testUsers.Add(new User(2, "student_2", "asddsa", 3, (int)UserRoles.STUDENT, DateTime.UtcNow, DateTime.MaxValue));
        }

        public static User IsUserPassCorrect(string username, string password)
        {
            ResetTestUserData();

            using (var context = new UserContext())
                return context.Users.FirstOrDefault(user => user.Username == username && user.Password == password);
        }

        public static bool UserExists(string username)
        {
            using (var context = new UserContext())
                return context.Users.FirstOrDefault(user => user.Username == username) != null;
        }

        public static void SetUserActiveTo(string username, DateTime date)
        {
            using (var context = new UserContext())
            {
                Logger.LogActivity(Activities.userActiveToChanged, username);

                context.Users.FirstOrDefault(user => user.Username == username).ValidUntil = date;
                context.SaveChanges();
            }
        }

        public static void AssignUserRole(string username, UserRoles role)
        {
            using (var context = new UserContext())
            {
                Logger.LogActivity(Activities.userChanged, username);

                context.Users.FirstOrDefault(user => user.Username == username).Role = (int)role;
                context.SaveChanges();
            }
        }

        public static bool TestUsersIfEmpty()
        {
            using (var context = new UserContext())
            {
                return !context.Users.Any();
            }
        }

        public static void CopyTestUsers()
        {
            using (var context = new UserContext())
            {
                foreach (var user in TestUsers)
                    context.Users.Add(user);

                context.SaveChanges();
            }
        }
    }
}
