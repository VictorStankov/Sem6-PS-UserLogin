using System;

namespace UserLogin
{
    class LogEvent
    {
        public int LogId { get; set; }
        public string Username { get; set; }
        public string Action { get; set; }
        public string TargetUser { get; set; }
        public DateTime Timestamp { get; set; }

        public LogEvent() { }
        public LogEvent(string username, string action, string targetUser, DateTime time)
        {
            Username = username;
            Action = action;
            TargetUser = targetUser;
            Timestamp = time;
        }
    }
}
