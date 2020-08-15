using AsaNi.DomainClasses;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace AsaNi.DataAccess.Context
{
    public class AsaNiDBContext : DbContext
    {
        public AsaNiDBContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.EnableSensitiveDataLogging();
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Owner>().HasData(
              new Owner() { Id = 1, FirstName = "Mehrnoosh", LastName = "Developer", PhoneNumber = "09123333342" },
              new Owner() { Id = 2, FirstName = "Ali", LastName = "Developer", PhoneNumber = "09113331355" },
              new Owner() { Id = 3, FirstName = "Fateme", LastName = "Developer", PhoneNumber = "09125554478" });

            modelBuilder.Entity<House>().HasData(
             new House() { Id = 1, Name = "Ghasemi", Number = "02102", Address = "karaj", OwnerId = 1, CreatedDateTime = DateTime.Now, CreatedBy = Environment.UserName },
             new House() { Id = 2, Name = "Diba", Number = "01240", Address = "fardis", OwnerId = 2, CreatedDateTime = DateTime.Now, CreatedBy = Environment.UserName },
             new House() { Id = 3, Name = "Baran", Number = "23105", Address = "mehrshahr", OwnerId = 2, CreatedDateTime = DateTime.Now, CreatedBy = Environment.UserName });

        }

        public DbSet<House> Houses { get; set; }
        public DbSet<Owner> Owners { get; set; }
    }
}



