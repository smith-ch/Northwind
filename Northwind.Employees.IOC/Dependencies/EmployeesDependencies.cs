using Microsoft.Extensions.DependencyInjection;
using Northwind.Employees.Domain.Interfaces;
using Northwind.Employees.Persistence.Repository;

namespace Northwind.Employees.IOC.Dependencies
{
    public static class EmployeesDependency
    {
        public static void AddEmployeesDependency(this IServiceCollection service)
        {
            #region"Repositorios"
            service.AddScoped<IEmployeesRepository, EmployeesRepository>();
            #endregion

            #region"Services"
            service.AddTransient<IEmployeesRepository, EmployeesRepository>();
            #endregion
        }
    }
}
