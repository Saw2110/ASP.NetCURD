using Microsoft.EntityFrameworkCore;
using PracticeAPI.Model;

namespace PracticeAPI.DBHelper
{
    public class UserDbContext : DbContext
    {
        public UserDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<UserDetailModel> UserDetails { get; set; }
    }
}
