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

            //if (val.ValidateUserInput(ref user))
            //    Console.WriteLine($"{user.username} {user.password} {user.faculty_num} {user.role} " +
            //        $"{user.created.ToLocalTime()} {user.validUntil.ToLocalTime()}");

            val.ValidateUserInput(ref user);

            switch (LoginValidation.currentUserRole)
            {
                case UserRoles.ADMIN:
                    AdminPanel(user);
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

        static private void AdminPanel(User user)
        {
            Console.WriteLine($"Welcome, {user.username}! Here is the admin panel:\n0: Exit\n1: Change user's role" +
                        $"\n2: Change user's expiry date");

            String username;
            UserRoles role;
            Char choice = Convert.ToChar(Console.ReadLine());
            switch (choice)
            {
                case '0':
                    break;
                case '1':
                    Console.Write("Enter user's username: ");
                    username = Console.ReadLine();
                    if (!UserData.UserExists(username))
                    {
                        Console.WriteLine("User does not exist!");
                        break;
                    }

                    Console.WriteLine($"\nAvailable Roles:");
                    foreach (UserRoles a in Enum.GetValues(typeof(UserRoles)))
                    {
                        Console.Write($"{a}  ");
                    }

                    Console.Write("\nEnter new role's name: ");
                    if (!Enum.TryParse(Console.ReadLine().ToUpper(), out role))
                    {
                        Console.WriteLine("Invalid Role Name!");
                        break;
                    }

                    UserData.AssignUserRole(username, role);
                    break;
                case '2':
                    Console.Write("Enter user's username: ");
                    username = Console.ReadLine();
                    if (!UserData.UserExists(username))
                    {
                        Console.WriteLine("User does not exist!");
                        break;
                    }

                    Console.WriteLine("Valid Date Format: 2020-12-31 13:00:00");
                    Console.Write("Enter an expiry date: ");

                    try
                    {
                        DateTime expiryDate = DateTime.Parse(Console.ReadLine());
                        UserData.SetUserActiveTo(username, expiryDate);
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine("Incorrect date format!");
                    }

                    break;
            }
        }
    }
}
