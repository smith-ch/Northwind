using Northwind.web.Models;

namespace Northwind.web.Results.Orders_Result
{
    public class OrdersGetListResult : BaseResult
    {
        public List<OrdersBaseModel> result { get; set; }
    }
}
