using Northwind.web.IService;
using Northwind.Web.Services;

namespace Northwind.web.Dependency
{
    public static class SuppliersDependency
    {
        public static void AddSuppliersDependency(this IServiceCollection services)
        {
            services.AddHttpClient<ISuppliersService, SuppliersService>();
        }
    }
}
