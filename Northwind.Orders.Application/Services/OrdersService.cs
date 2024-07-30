using Northwind.Orders.Application.Dtos;
using Northwind.Orders.Application.Extentions;
using InstNwnd.Web.BL.Interfaces;
using Microsoft.Extensions.Logging;
using Northwind.Orders.Application.Base;
using Northwind.Orders.Domain.Interfaces;
using DomainEntities = Northwind.Orders.Domain.Entities;
using System.Linq;
using System;
using System.Collections.Generic;

namespace NorthwindContext.Web.BL.Services
{
    public class OrdersService : IOrdersService
    {
        private readonly IOrdersRepository ordersRepository;
        private readonly ILogger<OrdersService> logger;

        public OrdersService(IOrdersRepository ordersRepository, ILogger<OrdersService> logger)
        {
            this.ordersRepository = ordersRepository;
            this.logger = logger;
        }

        public ServiceResult GetOrders()
        {
            ServiceResult result = new ServiceResult();
            try
            {
                result.Result = ordersRepository.GetAll()
                    .Select(order => new OrdersDtoGetAll
                    {
                        Id = order.Id,
                        CustomerId = order.CustomerId,
                        EmployeeID = order.EmployeeID,
                        OrderDate = order.OrderDate,
                        RequiredDate = order.RequiredDate,
                        ShippedDate = order.ShippedDate,
                        ShipVia = order.ShipVia,
                        Freight = order.Freight,
                        ShipName = order.ShipName,
                        ShipAddress = order.ShipAddress,
                        ShipCity = order.ShipCity,
                        ShipRegion = order.ShipRegion,
                        ShipPostalCode = order.ShipPostalCode,
                        ShipCountry = order.ShipCountry
                    }).OrderByDescending(o => o.Id).ToList(); // Ordering by Id
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Error obteniendo los pedidos.";
                this.logger.LogError(result.Message, ex.ToString());
            }
            return result;
        }

        public ServiceResult GetOrderById(int id)
        {
            ServiceResult result = new ServiceResult();
            try
            {
                result.Result = ordersRepository.GetAll()
                    .Where(order => order.Id == id)
                    .Select(order => new OrdersDtoGetAll
                    {
                        Id = order.Id,
                        CustomerId = order.CustomerId,
                        EmployeeID = order.EmployeeID,
                        OrderDate = order.OrderDate,
                        RequiredDate = order.RequiredDate,
                        ShippedDate = order.ShippedDate,
                        ShipVia = order.ShipVia,
                        Freight = order.Freight,
                        ShipName = order.ShipName,
                        ShipAddress = order.ShipAddress,
                        ShipCity = order.ShipCity,
                        ShipRegion = order.ShipRegion,
                        ShipPostalCode = order.ShipPostalCode,
                        ShipCountry = order.ShipCountry
                    }).FirstOrDefault();
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Error obteniendo el pedido.";
                this.logger.LogError(result.Message, ex.ToString());
            }
            return result;
        }

        public ServiceResult RemoveOrder(OrdersDtoRemove orderDtoRemove)
        {
            ServiceResult result = new ServiceResult();
            try
            {
                if (orderDtoRemove == null)
                {
                    result.Success = false;
                    result.Message = $"El objeto {nameof(orderDtoRemove)} es requerido.";
                    return result;
                }

                DomainEntities.Orders order = new DomainEntities.Orders
                {
                    Id = orderDtoRemove.Id,
                };

                ordersRepository.Remove(order);
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Error removiendo el pedido.";
                this.logger.LogError(result.Message, ex.ToString());
            }
            return result;
        }

        public ServiceResult SaveOrder(OrdersDtoSave orderDtoSave)
        {
            ServiceResult result = new ServiceResult();
            try
            {
                result = orderDtoSave.IsValidOrder();

                if (!result.Success)
                    return result;

                DomainEntities.Orders order = new DomainEntities.Orders
                {
                    Id = orderDtoSave.Id,
                    CustomerId = orderDtoSave.CustomerId,
                    EmployeeID = orderDtoSave.EmployeeID,
                    OrderDate = orderDtoSave.OrderDate,
                    RequiredDate = orderDtoSave.RequiredDate,
                    ShippedDate = orderDtoSave.ShippedDate,
                    ShipVia = orderDtoSave.ShipVia,
                    Freight = orderDtoSave.Freight,
                    ShipName = orderDtoSave.ShipName,
                    ShipAddress = orderDtoSave.ShipAddress,
                    ShipCity = orderDtoSave.ShipCity,
                    ShipRegion = orderDtoSave.ShipRegion,
                    ShipPostalCode = orderDtoSave.ShipPostalCode,
                    ShipCountry = orderDtoSave.ShipCountry
                };

                ordersRepository.Save(order);
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Error guardando el pedido.";
                this.logger.LogError(result.Message, ex.ToString());
            }
            return result;
        }

        public ServiceResult UpdateOrder(OrdersDtoUpdate orderDtoUpdate)
        {
            ServiceResult result = new ServiceResult();
            try
            {
                result = orderDtoUpdate.IsValidOrder();

                if (!result.Success)
                    return result;

                DomainEntities.Orders order = new DomainEntities.Orders
                {
                    Id = orderDtoUpdate.Id,
                    CustomerId = orderDtoUpdate.CustomerId,
                    EmployeeID = orderDtoUpdate.EmployeeID,
                    OrderDate = orderDtoUpdate.OrderDate,
                    RequiredDate = orderDtoUpdate.RequiredDate,
                    ShippedDate = orderDtoUpdate.ShippedDate,
                    ShipVia = orderDtoUpdate.ShipVia,
                    Freight = orderDtoUpdate.Freight,
                    ShipName = orderDtoUpdate.ShipName,
                    ShipAddress = orderDtoUpdate.ShipAddress,
                    ShipCity = orderDtoUpdate.ShipCity,
                    ShipRegion = orderDtoUpdate.ShipRegion,
                    ShipPostalCode = orderDtoUpdate.ShipPostalCode,
                    ShipCountry = orderDtoUpdate.ShipCountry
                };

                ordersRepository.Update(order);
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Error actualizando el pedido.";
                this.logger.LogError(result.Message, ex.ToString());
            }
            return result;
        }
    }
}
