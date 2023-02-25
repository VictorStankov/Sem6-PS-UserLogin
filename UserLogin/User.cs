using System;

namespace UserLogin
{
    class User
    {
        public String username
        {
            get; set;
        }
        public String password
        {
            get; set;
        }
        public Int32 facultyNum
        {
            get; set;
        }
        public Int32 role
        {
            get; set;
        }
        public DateTime created
        {
            get; set;
        }
        public DateTime validUntil
        {
            get; set;
        }

        public User() { }
        public User(String username, String password, Int32 facultyNum, Int32 role, DateTime created, DateTime validUntil)
        {
            this.username = username;
            this.password = password;
            this.facultyNum = facultyNum;
            this.role = role;
            this.created = created;
            this.validUntil = validUntil;
        }
    }

    
}
