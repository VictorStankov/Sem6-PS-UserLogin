using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserLogin
{
    class Program
    {
        static void Main(string[] args)
        {
            LoginValidation val = new LoginValidation();

            if (val.ValidateUserInput(UserData.TestUser))
                Console.WriteLine($"{UserData.TestUser.username} {UserData.TestUser.password} " +
                    $"{UserData.TestUser.faculty_num} {UserData.TestUser.role} \n{LoginValidation.currentUserRole}");
        }
    }
}
