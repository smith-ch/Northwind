using Northwind.Common.Data.Repository;
using System.Linq.Expressions;
using EmployeesDomainEntities = Northwind.Employees.Domain.Entities;

namespace Northwind.Employees.Domain.Interfaces
{
    public interface IEmployeesRepository 
    {
        List<EmployeesDomainEntities.Employees> GetEmployeesByEmployeeID(int EmployeeID);
        bool Exists(Expression<Func<EmployeesDomainEntities.Employees, bool>> filter);
        List<EmployeesDomainEntities.Employees> GetAll();
        EmployeesDomainEntities.Employees GetEntityBy(int id);
        void Remove(EmployeesDomainEntities.Employees entity);
        void Save(EmployeesDomainEntities.Employees entity);
        void Update(EmployeesDomainEntities.Employees entity);
    }
}
