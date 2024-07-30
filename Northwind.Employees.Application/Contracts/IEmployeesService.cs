using Northwind.Employees.Application.Base; 
using Northwind.Employees.Application.Dtos;

namespace Northwind.Employees.Application.Contracts
{
    public interface IEmployeesService
    {
        ServiceResult GetAll();
        ServiceResult GetById(int id);
        ServiceResult Add(EmployeesDtoSave employeesDtoSave);
        ServiceResult Update(EmployeesDtoUpdate employeesDtoUpdate);
        ServiceResult Remove(EmployeesDtoRemove courseDtoRemove);
        
    }
}
