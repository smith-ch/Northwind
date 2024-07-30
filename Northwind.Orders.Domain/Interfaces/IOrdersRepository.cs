using Northwind.Common.Data.Repository;
using Northwind.Orders.Domain.Entities;

namespace Northwind.Orders.Domain.Interfaces
{
    public interface IOrdersRepository : IBaseRepository<Orders.Domain.Entities.Orders, int>
    {
        List<Orders.Domain.Entities.Orders> GetOrdersByOrderID(int OrderID);
    }
}
