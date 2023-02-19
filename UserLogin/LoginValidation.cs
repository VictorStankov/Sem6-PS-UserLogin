using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserLogin
{
    class LoginValidation
    {
        private String username, password, errorMessage;
        public static UserRoles currentUserRole
        {
            get; private set;
        }

        public LoginValidation(String username, String password)
        {
            this.username = username;
            this.password = password;
        }

        public bool ValidateUserInput(ref User user)
        {
            user = UserData.TestUser;

            currentUserRole = (UserRoles)user.role;
            return true;
        }
    }
}
