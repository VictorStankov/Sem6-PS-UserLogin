using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace UserLogin
{
    static class Logger
    {
        private static List<string> _currentSessionActivities = new List<string>();

        // The parameter "username" is not the logged in user. 
        // Rather it is used to log the name of the user whose information has been changed.
        public static void LogActivity(Activities activity, string username="")
        {
            string activityLine = $"{DateTime.Now};{LoginValidation.CurrentUserUsername};" +
                $"{LoginValidation.CurrentUserRole};{GetActivityDescription(activity)};{username}\n";

            _currentSessionActivities.Add(activityLine);
            File.AppendAllText("Log.txt", activityLine);
        }

        private static string GetActivityDescription(Activities activity)
        {
            switch (activity)
            {
                case Activities.userLogin:
                    return "Logged in successfully";
                case Activities.userChanged:
                    return "Changed user's information";
                case Activities.userActiveToChanged:
                    return "Changed user's expiry date";
                default:
                    return "Unrecognised activity";
            }
        }

        public static string GetCurrentSessionActivities()
        {
            StringBuilder output = new StringBuilder();

            foreach (string line in _currentSessionActivities)
                output.Append(line);

            return output.ToString();
        }
    }
}
