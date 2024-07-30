using Northwind.web.IService;
using Northwind.Web.Services;

namespace Northwind.web.Dependency
{
    public static class EmployeeDependency
    {
        public static void AddEmployeesDependency(this IServiceCollection services) 
        {
            services.AddHttpClient<IEmployeeServices, EmployeeService>();
        }
    }
}
