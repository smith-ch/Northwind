using InstNwnd.Web.BL.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Northwind.Orders.Application.Dtos;

namespace NorthwindContext.Employees.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IOrdersService ordersService;

        public OrdersController(IOrdersService ordersService)
        {
            this.ordersService = ordersService;
        }

        [HttpGet("GetOrders")]
        public IActionResult GetOrders()
        {
            var result = this.ordersService.GetOrders();

            if (!result.Success)
                return BadRequest(result);
            else
                return Ok(result);
        }

        [HttpGet("GetOrderById/{id}")]
        public IActionResult GetOrderById(int id)
        {
            var result = this.ordersService.GetOrderById(id);

            if (!result.Success)
                return BadRequest(result);
            else
                return Ok(result);
        }

        [HttpPut("CreateOrder")]
        public IActionResult SaveOrder([FromBody] OrdersDtoSave dtoSave)
        {
            var result = this.ordersService.SaveOrder(dtoSave);

            if (!result.Success)
                return BadRequest(result);
            else
                return Ok(result);
        }

        [HttpPost("UpdateOrder")]
        public IActionResult UpdateOrder([FromBody] OrdersDtoUpdate dtoUpdate)
        {
            var result = this.ordersService.UpdateOrder(dtoUpdate);

            if (!result.Success)
                return BadRequest(result);
            else
                return Ok(result);
        }

        [HttpDelete("RemoveOrder")]
        public IActionResult RemoveOrder([FromBody] OrdersDtoRemove dtoRemove)
        {
            var result = this.ordersService.RemoveOrder(dtoRemove);

            if (!result.Success)
                return BadRequest(result);
            else
                return Ok(result);
        }
    }
}
