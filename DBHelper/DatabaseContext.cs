using Microsoft.EntityFrameworkCore;
using PracticeAPI.Model;

namespace PracticeAPI.DBHelper
{
    public class DatabaseContext : DbContext
    {
            protected readonly IConfiguration Configuration;

        public DatabaseContext(IConfiguration configuration) => Configuration = configuration;

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            // connect to mysql with connection string from app settings
            var connectionString = Configuration.GetConnectionString("DefaultConnection");
            options.UseSqlServer(connectionString);
        }

        // public DbSet<UserDetailModel> Users { get; set; }
    }
}
