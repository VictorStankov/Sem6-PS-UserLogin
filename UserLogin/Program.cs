using System;
using System.Text;

namespace UserLogin
{
    class Program
    {
        static void Main(string[] args)
        {
            if (UserData.TestUsersIfEmpty())
                UserData.CopyTestUsers();

            Console.Write("Enter username: ");
            string username = Console.ReadLine();
            Console.Write("Enter password: ");
            string password = Console.ReadLine();

            var val = new LoginValidation(username, password, PrintError);

            User user = null;

            val.ValidateUserInput(ref user);

            switch (LoginValidation.CurrentUserRole)
            {
                case UserRoles.ADMIN:
                    AdminPanel(user);
                    break;
                case UserRoles.INSPECTOR:
                    Console.WriteLine($"Welcome, {user.Username}! Here is a list of your tasks:");
                    break;
                case UserRoles.PROFESSOR:
                    Console.WriteLine($"Welcome, {user.Username}! These are your most recent emails:");
                    break;
                case UserRoles.STUDENT:
                    Console.WriteLine($"Welcome, student {user.Username}! These are your upcoming deadlines:");
                    break;
                case UserRoles.ANONYMOUS:
                    Console.WriteLine($"Welcome! A user with your credentials was not found. Proceeding as guest...");
                    break;
            }
        }

        private static void PrintError(string errorMsg)
        {
            Console.WriteLine($"!!! {errorMsg} !!!");
        }

        private static void AdminPanel(User user)
        {
            while (true)
            {

                Console.WriteLine($"Welcome, {user.Username}! Here is the admin panel:\n0: Exit\n1: Change user's role" +
                            "\n2: Change user's expiry date\n3: List registered users\n4: Show activity log" +
                            "\n5: Show current session log");

                string username;
                UserRoles role;
            
                string choice = Console.ReadLine();
                if (string.IsNullOrEmpty(choice) || choice.Length > 1)
                {
                    Console.WriteLine("Invalid Choice!");
                    continue;
                }
                
                var sb = new StringBuilder();

                switch (choice[0])
                {
                    case '0':
                        return;
                    case '1':
                        Console.Write("Enter user's username: ");
                        username = Console.ReadLine();
                        if (!UserData.UserExists(username))
                        {
                            Console.WriteLine("User does not exist!");
                            break;
                        }

                        Console.WriteLine("\nAvailable Roles:");
                        foreach (UserRoles a in Enum.GetValues(typeof(UserRoles)))
                            Console.Write($"{a}  ");

                        Console.Write("\nEnter new role's name: ");
                        string roleStr = Console.ReadLine();
                        if (string.IsNullOrEmpty(roleStr) || !Enum.TryParse(roleStr.ToUpper(), out role))
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
                        Console.WriteLine();

                        break;
                    case '3':
                        Console.WriteLine("Registered users:");
                        foreach (User temp in new UserContext().Users)
                            Console.WriteLine(temp.Username);
                        Console.WriteLine();

                        break;
                    case '4':
                        sb.Clear();
                        foreach (string line in Logger.GetLogFileActivities())
                            sb.AppendLine(line);
                        
                        Console.WriteLine(sb.ToString());
                        break;
                    case '5':
                        Console.Write("Enter filter: ");
                        string filter = Console.ReadLine();

                        sb.Clear();
                        foreach (string line in Logger.GetCurrentSessionActivities(filter))
                            sb.Append(line);
                        
                        Console.WriteLine(sb.ToString());
                        break;
                }
            }
        }
    }
}
