using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserLogin
{
    class LoginValidation
    {
        public static UserRoles currentUserRole
        {
            get; private set;
        }

        public bool ValidateUserInput(User user)
        {
            currentUserRole = UserRoles.ADMIN;
            return true;
        }
    }
}
