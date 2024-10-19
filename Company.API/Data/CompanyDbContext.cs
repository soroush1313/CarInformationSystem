using CarInformation.API.Models;
using Microsoft.EntityFrameworkCore;

namespace CarInformation.API.Data
{
    public class CompanyDbContext : DbContext
    {
        public CompanyDbContext(DbContextOptions<CompanyDbContext> options) : base(options) { }

        public DbSet<Car> Cars { get; set; }
        public DbSet<CarsCompany> Companies { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CarsCompany>()
                .HasMany(c => c.Cars)
                .WithOne(c => c.Company)
                .HasForeignKey(c => c.CompanyId);

            base.OnModelCreating(modelBuilder);
        }
    }
}
