using Microsoft.AspNetCore.Mvc;
using Northwind.web.IService;
using Northwind.web.Models;

namespace Northwind.web.Controllers
{
    public class SuppliersController : Controller
    {
        private readonly ISuppliersService _suppliersService;

        public SuppliersController(ISuppliersService suppliersService)
        {
            _suppliersService = suppliersService;
        }

        // GET: SuppliersController
        public async Task<ActionResult> Index()
        {
            var suppliersGetListResult = await _suppliersService.GetSuppliersAsync();
            if (suppliersGetListResult != null && suppliersGetListResult.success)
            {
                return View(suppliersGetListResult.result);
            }

            ViewBag.Message = suppliersGetListResult?.message ?? "Error desconocido";
            return View();
        }

        // GET: SuppliersController/Details/5
        public async Task<ActionResult> Details(int id)
        {
            var suppliersGetResult = await _suppliersService.GetSupplierByIdAsync(id);
            if (suppliersGetResult != null && suppliersGetResult.success)
            {
                return View(suppliersGetResult.result);
            }

            ViewBag.Message = suppliersGetResult?.message ?? "Error desconocido";
            return View();
        }

        // GET: SuppliersController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SuppliersController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(SuppliersBaseModel supplier)
        {
            var result = await _suppliersService.CreateSupplierAsync(supplier);
            if (result != null && result.success)
            {
                return RedirectToAction(nameof(Index));
            }

            ViewBag.Message = result?.message ?? "Error desconocido";
            return View(supplier);
        }

        // GET: SuppliersController/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            var suppliersGetResult = await _suppliersService.GetSupplierByIdAsync(id);
            if (suppliersGetResult != null && suppliersGetResult.success)
            {
                return View(suppliersGetResult.result);
            }

            ViewBag.Message = suppliersGetResult?.message ?? "Error desconocido";
            return View();
        }

        // POST: SuppliersController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, SuppliersBaseModel supplier)
        {
            var result = await _suppliersService.UpdateSupplierAsync(id, supplier);
            if (result != null && result.success)
            {
                return RedirectToAction(nameof(Index));
            }

            ViewBag.Message = result?.message ?? "Error desconocido";
            return View(supplier);
        }

        // GET: SuppliersController/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            var suppliersGetResult = await _suppliersService.GetSupplierByIdAsync(id);
            if (suppliersGetResult != null && suppliersGetResult.success)
            {
                return View(suppliersGetResult.result);
            }

            ViewBag.Message = suppliersGetResult?.message ?? "Error desconocido";
            return View();
        }

        // POST: SuppliersController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            var result = await _suppliersService.DeleteSupplierAsync(id);
            if (result != null && result.success)
            {
                return RedirectToAction(nameof(Index));
            }

            ViewBag.Message = result?.message ?? "Error desconocido";
            return RedirectToAction(nameof(Delete), new { id });
        }
    }
}
