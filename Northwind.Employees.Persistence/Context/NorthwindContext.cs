using Microsoft.EntityFrameworkCore;
using DomainEntities = Northwind.Employees.Domain.Entities;

namespace Northwind.Data.Context
{
    public class NorthwindDbContext : DbContext
    {
        public NorthwindDbContext(DbContextOptions<NorthwindDbContext> options) : base(options)
        {
        }

        public DbSet<DomainEntities.Employees> Employees { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DomainEntities.Employees>(entity =>
            {
                entity.HasKey(e => e.EmployeeID);

                entity.Property(e => e.EmployeeID).HasColumnName("EmployeeID");
                entity.Property(e => e.LastName).IsRequired().HasColumnName("LastName").HasMaxLength(20);
                entity.Property(e => e.FirstName).IsRequired().HasColumnName("FirstName").HasMaxLength(10);
                entity.Property(e => e.Title).HasColumnName("Title").HasMaxLength(30);
                entity.Property(e => e.TitleOfCourtesy).HasColumnName("TitleOfCourtesy").HasMaxLength(25);
                entity.Property(e => e.BirthDate).HasColumnName("BirthDate");
                entity.Property(e => e.HireDate).HasColumnName("HireDate");
                entity.Property(e => e.Address).HasColumnName("Address").HasMaxLength(60);
                entity.Property(e => e.City).HasColumnName("City").HasMaxLength(15);
                entity.Property(e => e.Region).HasColumnName("Region").HasMaxLength(15);
                entity.Property(e => e.PostalCode).HasColumnName("PostalCode").HasMaxLength(10);
                entity.Property(e => e.Country).HasColumnName("Country").HasMaxLength(15);
                entity.Property(e => e.HomePhone).HasColumnName("HomePhone").HasMaxLength(24);
                entity.Property(e => e.Extension).HasColumnName("Extension").HasMaxLength(4);
                entity.Property(e => e.Photo).HasColumnName("Photo");
                entity.Property(e => e.Notes).HasColumnName("Notes");
                entity.Property(e => e.ReportsTo).HasColumnName("ReportsTo");
                entity.Property(e => e.PhotoPath).HasColumnName("PhotoPath").HasMaxLength(255);
            });
        }
    }
}
