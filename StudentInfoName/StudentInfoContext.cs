using System.Data.Entity;
using System.Configuration;
using UserLogin;

namespace StudentInfoSystem
{
    class StudentInfoContext : DbContext
    {
        public DbSet<Student> Students { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Grade> Grades { get; set; }

        public StudentInfoContext() : base(ConfigurationManager.ConnectionStrings["DbConnection"].ToString())
        {
            
        }
    }
}
