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

            UserContext context = new UserContext();

            return context.Users.Where(user => user.Username == username && user.Password == password).FirstOrDefault();
        }

        public static bool UserExists(string username)
        {
            return _testUsers.Where(user => user.Username == username).FirstOrDefault() != null;
        }

        public static void SetUserActiveTo(string username, DateTime date)
        {
            Logger.LogActivity(Activities.userActiveToChanged, username);

            _testUsers.Where(user => user.Username == username).FirstOrDefault().ValidUntil = date;
        }

        public static void AssignUserRole(string username, UserRoles role)
        {
            Logger.LogActivity(Activities.userChanged, username);

            _testUsers.Where(user => user.Username == username).FirstOrDefault().Role = (int)role;
        }

        public static bool TestUsersIfEmpty()
        {
            UserContext context = new UserContext();

            return !context.Users.Any();
        }

        public static void CopyTestUsers()
        {
            UserContext context = new UserContext();

            foreach (User user in TestUsers)
                context.Users.Add(user);

            context.SaveChanges();
        }
    }
}
