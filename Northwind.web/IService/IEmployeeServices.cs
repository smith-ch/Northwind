using Northwind.web.Models;
using Northwind.web.Results;
using Northwind.web.Results.Employee_Result;

namespace Northwind.web.IService
{
    public interface IEmployeeServices
    {

        Task<EmployeeGetlistResult> GetEmployeesAsync();
        Task<EmployeeGetResult> GetEmployeeByIdAsync(int id);
        Task<BaseResult> CreateEmployeeAsync(EmployeeBaseModel customer);
        Task<BaseResult> UpdateEmployeeAsync(int id, EmployeeBaseModel customer);
        Task<BaseResult> DeleteEmployeeAsync(int id);
    }
}
