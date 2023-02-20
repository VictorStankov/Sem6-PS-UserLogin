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

            LoginValidation val = new LoginValidation(username, password, new LoginValidation.ActionOnError(PrintError));

            User user = null;

            if (val.ValidateUserInput(ref user))
                Console.WriteLine($"{user.username} {user.password} {user.faculty_num} {user.role} " +
                    $"{user.created.ToLocalTime()} {user.validUntil.ToLocalTime()}");

            switch (LoginValidation.currentUserRole)
            {
                case UserRoles.ADMIN:
                    Console.WriteLine($"Welcome, {user.username}! Here is the admin panel:");
                    break;
                case UserRoles.INSPECTOR:
                    Console.WriteLine($"Welcome, {user.username}! Here is a list of your tasks:");
                    break;
                case UserRoles.PROFESSOR:
                    Console.WriteLine($"Welcome, {user.username}! These are your most recent emails:");
                    break;
                case UserRoles.STUDENT:
                    Console.WriteLine($"Welcome, student {user.username}! These are your upcoming deadlines:");
                    break;
                case UserRoles.ANONYMOUS:
                    Console.WriteLine($"Welcome! A user with your credentials was not found. Proceeding as guest...");
                    break;
            }
        }

        static public void PrintError(string errorMsg)
        {
            Console.WriteLine($"!!! {errorMsg} !!!");
        }
    }
}
