using Northwind.Employees.Domain.Entities;
using Northwind.Employees.Application.Base;

public static class ValidEmployees
{
    public static ServiceResult IsValidEmployee(this EmployeesDtoBase baseEmployee)
    {
        ServiceResult result = new ServiceResult();

        if (baseEmployee == null)
        {
            result.Success = false;
            result.Message = $"El objeto {nameof(baseEmployee)} es requerido.";
            return result;
        }

        if (baseEmployee.BirthDate == null)
        {
            result.Success = false;
            result.Message = "La fecha de nacimiento del empleado es requerida.";
            return result;
        }

        if (baseEmployee.HireDate == null)
        {
            result.Success = false;
            result.Message = "La fecha de contratación del empleado es requerida.";
            return result;
        }

        result.Success = true;
        return result;
    }
}
