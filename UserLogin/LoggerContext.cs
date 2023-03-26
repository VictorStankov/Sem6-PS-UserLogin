using System.Data.Entity;
using System.Configuration;

namespace UserLogin
{
    class LoggerContext : DbContext
    {
        public DbSet<LogEvent> Logs { get; set; }

        public LoggerContext() : base(ConfigurationManager.ConnectionStrings["DbConnection"].ToString())
        {

        }
    }
}
