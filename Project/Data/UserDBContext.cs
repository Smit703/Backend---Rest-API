using Microsoft.EntityFrameworkCore;

namespace Project.Data
{
    public class UserDBContext : DbContext
    {
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        public UserDBContext(DbContextOptions<UserDBContext> request) : base(request)
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        {

        }

        public DbSet<Users> Users { get; set; } 
        public DbSet<Friend> Friends { get; set; }  

    }
}
