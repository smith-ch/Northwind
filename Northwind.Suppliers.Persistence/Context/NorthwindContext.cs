using Microsoft.EntityFrameworkCore;
using Northwind.Suppliers.Domain.Entities;

namespace Northwind.Suppliers.Persistence.Context
{
    public class NorthwindDbContext: DbContext
    {
        #region "Constructor"

        public NorthwindDbContext(DbContextOptions<NorthwindDbContext> options) : base(options)
        {
        }
        #endregion

        #region "Db Sets"
        public DbSet<Domain.Entities.Suppliers> Suppliers { get; set; }
        #endregion

    }
}
