using First_Project.Model;
using Microsoft.EntityFrameworkCore;

namespace First_Project.Data
{
    public class UserDbContext:DbContext
    {
        public UserDbContext(DbContextOptions options):base(options)
        {

        }
        public DbSet<User> Users { get; set; }

    }
}
