using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace SecureDevelopment
{
    public sealed class ApplicationContext : DbContext
    {
        public DbSet<DebitCard> DebitCards { get; set; }

        public ApplicationContext()
        {
            Database.EnsureCreated();
        }
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySQL(Connect.GetConnectionString());
        }

    }
}