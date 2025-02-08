using Microsoft.EntityFrameworkCore;
using TeacheradminPortal.Models.Entities;

namespace TeacheradminPortal.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<Teacher> Teachers { get; set; }

    }
}
