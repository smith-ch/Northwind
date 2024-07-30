using Northwind.Orders.Application.Dtos;
using Northwind.Orders.Application.Base;

namespace Northwind.Orders.Application.Extentions
{
    public static class ValidOrders
    {
        public static ServiceResult IsValidOrder(this OrdersDtoBase baseOrder)
        {
            ServiceResult result = new ServiceResult();

            if (baseOrder is null)
            {
                result.Success = false;
                result.Message = $"El objeto {nameof(baseOrder)} es requerido.";
                return result;
            }

            if (string.IsNullOrEmpty(baseOrder.CustomerId))
            {
                result.Success = false;
                result.Message = "El ID del cliente es requerido.";
                return result;
            }

            if (baseOrder.OrderDate == null)
            {
                result.Success = false;
                result.Message = "La fecha del pedido es requerida.";
                return result;
            }

            if (string.IsNullOrEmpty(baseOrder.ShipName))
            {
                result.Success = false;
                result.Message = "El nombre del destinatario es requerido.";
                return result;
            }

            if (string.IsNullOrEmpty(baseOrder.ShipAddress))
            {
                result.Success = false;
                result.Message = "La dirección de envío es requerida.";
                return result;
            }

            if (string.IsNullOrEmpty(baseOrder.ShipCity))
            {
                result.Success = false;
                result.Message = "La ciudad de envío es requerida.";
                return result;
            }

            if (string.IsNullOrEmpty(baseOrder.ShipCountry))
            {
                result.Success = false;
                result.Message = "El país de envío es requerido.";
                return result;
            }

            return result;
        }
    }
}
