using Northwind.Employees.Application.Contracts;
using Microsoft.AspNetCore.Mvc;
using Northwind.Employees.Application.Dtos;

namespace Northwind.Employees.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly IEmployeesService employeesService;

        public EmployeesController(IEmployeesService employeesService)
        {
            this.employeesService = employeesService;
        }

        [HttpGet("GetEmployees")]
        public IActionResult Get()
        {
            var result = this.employeesService.GetAll();
            if (!result.Success)
                return BadRequest(result);
            return Ok(result);
        }

        [HttpGet("GetEmployeeById/{id}")]
        public IActionResult Get(int id)
        {
            var result = this.employeesService.GetById(id);
            if (!result.Success)
                return BadRequest(result);
            return Ok(result);
        }

        [HttpPost("CreateEmployee")]
        public IActionResult Post(EmployeesDtoSave employeesDtoSave)
        {
            var result = this.employeesService.Add(employeesDtoSave);

            if (!result.Success)
                return BadRequest(result);
            else
                return Ok(result);
        }


        [HttpPut("UpdateEmployee")]
        public IActionResult Put(EmployeesDtoUpdate employeesDtoUpdate)
        {
            var result = this.employeesService.Update(employeesDtoUpdate);
            if (!result.Success)
                return BadRequest(result);
            return Ok(result);
        }

        [HttpDelete("RemoveEmployee/{id}")]
        public IActionResult Delete(int id )
        {
            var result = this.employeesService.Remove(new EmployeesDtoRemove { EmployeeID = id });
            if (!result.Success)
                return BadRequest(result);
            return Ok(result);
        }
    }
}
