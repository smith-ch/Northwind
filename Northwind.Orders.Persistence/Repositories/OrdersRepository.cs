using Northwind.Data.Context; // Alias for the namespace
using Northwind.Orders.Domain.Interfaces;
using System.Linq.Expressions;
using DomainEntities = Northwind.Orders.Domain.Entities;

namespace Northwind.Orders.Persistence.Repositories
{
    public class OrdersRepository : IOrdersRepository
    {
        private readonly MyNorthwindContext _context; // Use alias to refer to the class

        public OrdersRepository(MyNorthwindContext context) // Use alias to refer to the class
        {
            _context = context;
        }

        public bool Exists(Expression<Func<DomainEntities.Orders, bool>> filter)
        {
            return _context.Orders.Any(filter);
        }

        public List<DomainEntities.Orders> GetAll()
        {
            return _context.Orders.ToList();
        }

        public DomainEntities.Orders GetEntityBy(int Id)
        {
            return _context.Orders.Find(Id);
        }

        public List<DomainEntities.Orders> GetOrdersByOrderID(int OrderID)
        {
            return _context.Orders.Where(order => order.OrderID == OrderID).ToList();
        }

        public void Remove(DomainEntities.Orders entity)
        {
            _context.Orders.Remove(entity);
            _context.SaveChanges();
        }

        public void Save(DomainEntities.Orders entity)
        {
            _context.Orders.Add(entity);
            _context.SaveChanges();
        }

        public void Update(DomainEntities.Orders entity)
        {
            _context.Orders.Update(entity);
            _context.SaveChanges();
        }
    }
}
