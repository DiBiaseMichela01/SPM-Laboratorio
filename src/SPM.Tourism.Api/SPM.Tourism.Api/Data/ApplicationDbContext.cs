using Microsoft.EntityFrameworkCore;
using SPM.Tourism.Api.Models;
namespace SPM.Tourism.Api.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(
            DbContextOptions<ApplicationDbContext> options) : base(options) 
        { }

    public DbSet<User> Users { get; set; }
        public DbSet<TourismContent> TourismContents { get; set; }
    }
}
