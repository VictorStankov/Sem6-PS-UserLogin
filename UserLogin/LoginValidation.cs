using System;

namespace UserLogin
{
    class LoginValidation
    {
        public delegate void ActionOnError(string errorMsg);

        private string _username, _password;
        public static string CurrentUserUsername;
        public static UserRoles CurrentUserRole
        {
            get; private set;
        }

        private ActionOnError _errorfunc;

        public LoginValidation(string username, string password, ActionOnError errorfunc)
        {
            this._username = username;
            this._password = password;
            this._errorfunc = errorfunc;
        }
        
        public bool ValidateUserInput(ref User user)
        {
            if (_username.Length < 5)
            {
                _errorfunc("Please enter a username longer than 5 characters!");
                return false;
            }

            if (_password.Length < 5)
            {
                _errorfunc("Please enter a password longer than 5 characters!");
                return false;
            }

            user = UserData.IsUserPassCorrect(_username, _password);

            if (user == null)
            {
                _errorfunc("User not found!");
                CurrentUserUsername = null;
                CurrentUserRole = UserRoles.ANONYMOUS;
                return false;
            }

            CurrentUserUsername = user.Username;
            CurrentUserRole = (UserRoles)user.Role;

            Logger.LogActivity(Activities.userLogin);
            return true;
        }
    }
}
