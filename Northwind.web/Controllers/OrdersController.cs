using Microsoft.AspNetCore.Mvc;
using Northwind.web.IService;
using Northwind.web.Models;

namespace Northwind.web.Controllers
{
    public class OrdersController : Controller
    {
        private readonly IOrdersService _ordersService;

        public OrdersController(IOrdersService ordersService)
        {
            _ordersService = ordersService;
        }

        // GET: OrdersController
        public async Task<ActionResult> Index()
        {
            var ordersGetListResult = await _ordersService.GetOrdersAsync();
            if (ordersGetListResult != null && ordersGetListResult.success)
            {
                return View(ordersGetListResult.result);
            }

            ViewBag.Message = ordersGetListResult?.message ?? "Error desconocido";
            return View();
        }

        // GET: OrdersController/Details/5
        public async Task<ActionResult> Details(int id)
        {
            var ordersGetResult = await _ordersService.GetOrderByIdAsync(id);
            if (ordersGetResult != null && ordersGetResult.success)
            {
                return View(ordersGetResult.result);
            }

            ViewBag.Message = ordersGetResult?.message ?? "Error desconocido";
            return View();
        }

        // GET: OrdersController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: OrdersController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(OrdersBaseModel order)
        {
            var result = await _ordersService.CreateOrderAsync(order);
            if (result != null && result.success)
            {
                return RedirectToAction(nameof(Index));
            }

            ViewBag.Message = result?.message ?? "Error desconocido";
            return View(order);
        }

        // GET: OrdersController/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            var ordersGetResult = await _ordersService.GetOrderByIdAsync(id);
            if (ordersGetResult != null && ordersGetResult.success)
            {
                return View(ordersGetResult.result);
            }

            ViewBag.Message = ordersGetResult?.message ?? "Error desconocido";
            return View();
        }

        // POST: OrdersController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, OrdersBaseModel order)
        {
            var result = await _ordersService.UpdateOrderAsync(id, order);
            if (result != null && result.success)
            {
                return RedirectToAction(nameof(Index));
            }

            ViewBag.Message = result?.message ?? "Error desconocido";
            return View(order);
        }

        // GET: OrdersController/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            var ordersGetResult = await _ordersService.GetOrderByIdAsync(id);
            if (ordersGetResult != null && ordersGetResult.success)
            {
                return View(ordersGetResult.result);
            }

            ViewBag.Message = ordersGetResult?.message ?? "Error desconocido";
            return View();
        }

        // POST: OrdersController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            var result = await _ordersService.DeleteOrderAsync(id);
            if (result != null && result.success)
            {
                return RedirectToAction(nameof(Index));
            }

            ViewBag.Message = result?.message ?? "Error desconocido";
            return RedirectToAction(nameof(Delete), new { id });
        }
    }
}
