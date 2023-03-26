using System.Data.Entity;
using System.Configuration;

namespace UserLogin
{
    class UserContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public UserContext() : base(ConfigurationManager.ConnectionStrings["DbConnection"].ToString())
        {

        }
    }
}
