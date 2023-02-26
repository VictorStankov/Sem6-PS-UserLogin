using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace UserLogin
{
    static class Logger
    {
        private static List<string> _currentSessionActivities = new List<string>();

        public static void LogActivity(string activity)
        {
            string activityLine = $"{DateTime.Now};{LoginValidation.CurrentUserUsername};" +
                $"{LoginValidation.CurrentUserRole};{activity}\n";

            _currentSessionActivities.Add(activityLine);
            File.AppendAllText("Log.txt", activityLine);
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
