using Microsoft.EntityFrameworkCore;

namespace KidHub.API.Data
{
    public class ApplicationDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=db17833.public.databaseasp.net; Database=db17833; User Id=db17833; Password=C!i3=m6FD2@c; Encrypt=False; MultipleActiveResultSets=True;");
            }
        }

        // Example DbSet
        // public DbSet<User> Users { get; set; }
    }
}
