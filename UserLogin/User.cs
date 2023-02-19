using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        public Int32 faculty_num
        {
            get; set;
        }
        public Int32 role
        {
            get; set;
        }

        public User() { }
        public User(String username, String password, Int32 faculty_num, Int32 role)
        {
            this.username = username;
            this.password = password;
            this.faculty_num = faculty_num;
            this.role = role;
        }
    }

    
}
