using Microsoft.EntityFrameworkCore;

namespace WebApplication1.Models
{
    public class regDbContext : DbContext
    {
        public regDbContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<register> registers { get; set; }
        public DbSet<vendor> vendors { get; set; }
        public DbSet<CreateEvent> CreateEvents { get; set; }
        public DbSet<UserReg> UserRegs { get; set; }
        public DbSet<UserContact> UserContacts { get; set; }
        public DbSet<Review> Reviews { get; set; }

    }
}
