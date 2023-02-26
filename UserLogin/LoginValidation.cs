﻿using System;

namespace UserLogin
{
    class LoginValidation
    {
        public delegate void ActionOnError(string errorMsg);

        private String username, password;
        public static string currentUserUsername;
        public static UserRoles currentUserRole
        {
            get; private set;
        }

        private ActionOnError _errorfunc;

        public LoginValidation(String username, String password, ActionOnError _errorfunc)
        {
            this.username = username;
            this.password = password;
            this._errorfunc = _errorfunc;
        }
        
        public bool ValidateUserInput(ref User user)
        {
            if (username.Length < 5)
            {
                _errorfunc("Please enter a username longer than 5 characters!");
                return false;
            }

            if (password.Length < 5)
            {
                _errorfunc("Please enter a password longer than 5 characters!");
                return false;
            }

            user = UserData.IsUserPassCorrect(username, password);

            if (user == null)
            {
                _errorfunc("User not found!");
                currentUserUsername = null;
                currentUserRole = UserRoles.ANONYMOUS;
                return false;
            }

            currentUserUsername = user.username;
            currentUserRole = (UserRoles)user.role;

            Logger.LogActivity("Login successful");
            return true;
        }
    }
}
