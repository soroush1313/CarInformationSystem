﻿using CarInformation.API.Features.Car.Models;
using CarInformation.API.Features.Company.Models;
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
                .HasForeignKey(c => c.CompanyId)
                .OnDelete(DeleteBehavior.Cascade);

            base.OnModelCreating(modelBuilder);
        }
    }
}
