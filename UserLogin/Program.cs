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
            String username, password;

            Console.Write("Enter username: ");
            username = Console.ReadLine();
            Console.Write("Enter password: ");
            password = Console.ReadLine();

            LoginValidation val = new LoginValidation(username, password);

            User user = null;

            if (val.ValidateUserInput(ref user))
                Console.WriteLine($"{user.username} {user.password} {user.faculty_num} {user.role}\n{LoginValidation.currentUserRole}");
        }
    }
}
