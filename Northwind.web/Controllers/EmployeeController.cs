using Microsoft.AspNetCore.Mvc;
using Northwind.web.IService;
using Northwind.web.Models;

namespace Northwind.web.Controllers
{
    public class EmployeesController : Controller
    {
        private readonly IEmployeeServices _employeeService;

        public EmployeesController(IEmployeeServices employeeService)
        {
            _employeeService = employeeService;
        }

        // GET: EmployeesController
        public async Task<ActionResult> Index()
        {
            var employeeGetListResult = await _employeeService.GetEmployeesAsync();
            if (employeeGetListResult != null && employeeGetListResult.success)
            {
                return View(employeeGetListResult.result);
            }

            ViewBag.Message = employeeGetListResult?.message ?? "Error desconocido";
            return View();
        }

        // GET: EmployeesController/Details/5
        public async Task<ActionResult> Details(int id)
        {
            var employeeGetResult = await _employeeService.GetEmployeeByIdAsync(id);
            if (employeeGetResult != null && employeeGetResult.success)
            {
                return View(employeeGetResult.result);
            }

            ViewBag.Message = employeeGetResult?.message ?? "Error desconocido";
            return View();
        }

        // GET: EmployeesController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: EmployeesController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(EmployeeBaseModel employee)
        {
            var result = await _employeeService.CreateEmployeeAsync(employee);
            if (result != null && result.success)
            {
                return RedirectToAction(nameof(Index));
            }

            ViewBag.Message = result?.message ?? "Error desconocido";
            return View(employee);
        }

        // GET: EmployeesController/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            var employeeGetResult = await _employeeService.GetEmployeeByIdAsync(id);
            if (employeeGetResult != null && employeeGetResult.success)
            {
                return View(employeeGetResult.result);
            }

            ViewBag.Message = employeeGetResult?.message ?? "Error desconocido";
            return View();
        }

        // POST: EmployeesController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, EmployeeBaseModel employee)
        {
            var result = await _employeeService.UpdateEmployeeAsync(id, employee);
            if (result != null && result.success)
            {
                return RedirectToAction(nameof(Index));
            }

            ViewBag.Message = result?.message ?? "Error desconocido";
            return View(employee);
        }

        // GET: EmployeesController/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            var employeeGetResult = await _employeeService.GetEmployeeByIdAsync(id);
            if (employeeGetResult != null && employeeGetResult.success)
            {
                return View(employeeGetResult.result);
            }

            ViewBag.Message = employeeGetResult?.message ?? "Error desconocido";
            return View();
        }

        // POST: EmployeesController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            var result = await _employeeService.DeleteEmployeeAsync(id);
            if (result != null && result.success)
            {
                return RedirectToAction(nameof(Index));
            }

            ViewBag.Message = result?.message ?? "Error desconocido";
            return RedirectToAction(nameof(Delete), new { id });
        }
    }
}
