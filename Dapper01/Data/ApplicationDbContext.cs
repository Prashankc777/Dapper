using Dapper01.Models;
using Microsoft.EntityFrameworkCore;

namespace Dapper01.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            
        }

        public DbSet<Company> Companies { get; set; }
    }
}
