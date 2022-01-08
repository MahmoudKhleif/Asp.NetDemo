using Microsoft.EntityFrameworkCore;

namespace Asp.netDemo.Models
{
    public class UserContext:DbContext
    {
        public UserContext(DbContextOptions<UserContext> options)
              : base(options)
        {
        }

        public DbSet<USER> uSERs { get; set; } = null!;
    }
}
