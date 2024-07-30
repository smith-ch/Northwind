using Northwind.web.Models;
using Northwind.web.Results.Orders_Result;
using Northwind.web.Results;

namespace Northwind.web.IService
{
    public interface IOrdersService
    {
        Task<OrdersGetListResult> GetOrdersAsync();
        Task<OrdersGetResult> GetOrderByIdAsync(int id);
        Task<BaseResult> CreateOrderAsync(OrdersBaseModel order);
        Task<BaseResult> UpdateOrderAsync(int id, OrdersBaseModel order);
        Task<BaseResult> DeleteOrderAsync(int id);
    }
}
