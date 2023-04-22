using System;

namespace UserLogin
{
    public class User
    {
        public int UserId { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public int FacultyNum { get; set; }
        public int Role { get; set; }
        public DateTime Created { get; set; }
        public DateTime ValidUntil { get; set; }

        public User() { }
        public User(int userId, string username, string password, int facultyNum, int role, DateTime created, DateTime validUntil)
        {
            UserId = userId;
            Username = username;
            Password = password;
            FacultyNum = facultyNum;
            Role = role;
            Created = created;
            ValidUntil = validUntil;
        }

        public static implicit operator User(bool v)
        {
            throw new NotImplementedException();
        }
    }

    
}
