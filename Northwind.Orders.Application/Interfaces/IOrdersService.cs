using Northwind.Orders.Application.Base;
using Northwind.Orders.Application.Dtos;
namespace InstNwnd.Web.BL.Interfaces
{
    public interface IOrdersService
    {
        ServiceResult GetOrders();
        ServiceResult GetOrderById(int id);
        ServiceResult RemoveOrder(OrdersDtoRemove orderDtoRemove);
        ServiceResult SaveOrder(OrdersDtoSave orderDtoSave);
        ServiceResult UpdateOrder(OrdersDtoUpdate orderDtoUpdate);
    }
}
