using Microsoft.EntityFrameworkCore;
using Entity.Models;

namespace WebAPICrud.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }

        public DbSet<PersonalInfo> PersonalInfo { get; set; }
    }
}
