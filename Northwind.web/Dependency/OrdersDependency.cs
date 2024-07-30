using Northwind.web.IService;
using Northwind.Web.Services;

namespace Northwind.web.Dependency
{
    public static class OrdersDependency
    {
        public static void AddOrdersDependendy(this IServiceCollection services) 
        {
            services.AddHttpClient<IOrdersService, OrdersService>();
        }
    }
}
