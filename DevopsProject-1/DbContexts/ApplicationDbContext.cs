
using DevopsProject_1.Models;
using Microsoft.EntityFrameworkCore;


namespace DevopsProject_1.DbContexts
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
                 

        }
        public DbSet<Movie> Movies { get; set; }
    }
}
