using Northwind.web.Models;

namespace Northwind.web.Results.Employee_Result
{
    public class EmployeeGetlistResult : BaseResult
    {
        public List<EmployeeBaseModel> result { get; set; }
    }
}
