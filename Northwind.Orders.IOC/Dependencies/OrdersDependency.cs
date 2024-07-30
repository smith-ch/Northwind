
using Microsoft.Extensions.DependencyInjection;
using Northwind.Orders.Domain.Interfaces;
using Northwind.Orders.Persistence.Repositories;


namespace Northwind.Orders.IOC.Dependencies
{
    public static class OrdersDependency
    {
        public static void AddOrdersDependency(this IServiceCollection service)
        {
            #region"Repositorios"
            service.AddScoped<IOrdersRepository, OrdersRepository>();
            #endregion

            #region"Services"
            service.AddTransient<IOrdersRepository, OrdersRepository>();
            #endregion
        }
    }
}
