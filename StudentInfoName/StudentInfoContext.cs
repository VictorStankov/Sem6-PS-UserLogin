using System.Data.Entity;
using System.Configuration;
using UserLogin;

namespace StudentInfoSystem
{
    class StudentInfoContext : DbContext
    {
        public DbSet<Student> Studets { get; set; }
        public DbSet<User> Users { get; set; }

        public StudentInfoContext() : base(ConfigurationManager.ConnectionStrings["DbConnection"].ToString())
        {
            
        }
    }
}
