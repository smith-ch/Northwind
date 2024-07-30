using Northwind.Orders.Application.Base;
using Northwind.Orders.Application.Dtos;

namespace Northwind.Orders.Application.Contracts
{
    public interface IOrdersService
    {

        ServiceResult GetOrders();
        ServiceResult GetOrdersById(int id);
        ServiceResult UpdateOrders(OrdersDtoUpdate OrdersDtoUpdate);
        ServiceResult RemoveOrders(OrdersDtoRemove OrdersDtoRemove);
        ServiceResult SaveOrders(OrdersDtoSave OrdersDtoSave);
    }
}
