using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace UserLogin
{
    public static class Logger
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
        public static IEnumerable<string> GetLogFileActivities()
        {
            var logFile = new StreamReader("Log.txt");

            var logLines = logFile.ReadToEnd().Split('\n');
            logFile.Close();

            return logLines;
        }

        public static IEnumerable<string> GetCurrentSessionActivities(string filter)
        {
            List<string> filteredActivities = (
                from activity in _currentSessionActivities
                where activity.ToLower().Contains(filter)
                select activity
            ).ToList();
            return filteredActivities;
        }
    }
}
