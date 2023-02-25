using System;
using System.Collections.Generic;

namespace UserLogin
{
    static class Logger
    {
        private static List<string> currentSessionActivities = new List<string>();

        public static void LogActivity(string activity)
        {
            string activityLine = $"{DateTime.Now};{LoginValidation.currentUserUsername};" +
                $"{LoginValidation.currentUserRole};{activity}";

            currentSessionActivities.Add(activityLine);
        }
    }
}
