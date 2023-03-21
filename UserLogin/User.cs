using System;

namespace UserLogin
{
    public class User
    {
        public string Username
        {
            get; set;
        }
        public string Password
        {
            get; set;
        }
        public int FacultyNum
        {
            get; set;
        }
        public int Role
        {
            get; set;
        }
        public DateTime Created
        {
            get; set;
        }
        public DateTime ValidUntil
        {
            get; set;
        }

        public User() { }
        public User(string username, string password, int facultyNum, int role, DateTime created, DateTime validUntil)
        {
            this.Username = username;
            this.Password = password;
            this.FacultyNum = facultyNum;
            this.Role = role;
            this.Created = created;
            this.ValidUntil = validUntil;
        }
    }

    
}
