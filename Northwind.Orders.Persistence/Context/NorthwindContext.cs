using Microsoft.EntityFrameworkCore;
using DomainEntities = Northwind.Orders.Domain.Entities;

namespace Northwind.Data.Context
{
    public class MyNorthwindContext : DbContext
    {
        #region "Constructor"
        public MyNorthwindContext(DbContextOptions<MyNorthwindContext> options) : base(options)
        {
        }
        #endregion

        #region "Orders DbSet"
        public DbSet<DomainEntities.Orders> Orders { get; set; }
        #endregion

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DomainEntities.Orders>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.Property(e => e.Id).HasColumnName("OrderID");
                entity.Property(e => e.CustomerId).HasColumnName("CustomerID").IsRequired();
                entity.Property(e => e.EmployeeID).HasColumnName("EmployeeID");
                entity.Property(e => e.OrderDate).HasColumnName("OrderDate");
                entity.Property(e => e.RequiredDate).HasColumnName("RequiredDate");
                entity.Property(e => e.ShippedDate).HasColumnName("ShippedDate");
                entity.Property(e => e.ShipVia).HasColumnName("ShipVia");
                entity.Property(e => e.Freight).HasColumnName("Freight").HasColumnType("money");
                entity.Property(e => e.ShipName).HasColumnName("ShipName").HasMaxLength(40);
                entity.Property(e => e.ShipAddress).HasColumnName("ShipAddress").HasMaxLength(60);
                entity.Property(e => e.ShipCity).HasColumnName("ShipCity").HasMaxLength(15);
                entity.Property(e => e.ShipRegion).HasColumnName("ShipRegion").HasMaxLength(15);
                entity.Property(e => e.ShipPostalCode).HasColumnName("ShipPostalCode").HasMaxLength(10);
                entity.Property(e => e.ShipCountry).HasColumnName("ShipCountry").HasMaxLength(15);
            });
        }
    }
}
