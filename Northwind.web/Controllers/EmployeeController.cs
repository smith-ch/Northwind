using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Northwind.web.Models;
using Northwind.web.Results;
using Northwind.web.Results.Employee_Result;

namespace Northwind.Web.Controllers
{
    public class EmployeeController : Controller
    {
        HttpClientHandler httpClientHandler = new HttpClientHandler();

        public EmployeeController()
        {
            this.httpClientHandler = new HttpClientHandler();
            this.httpClientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyError) => { return true; };
        }

        // GET: EmployeeController
        public async Task<ActionResult> Index()
        {
            EmployeeGetlistResult employeesGetResult = new EmployeeGetlistResult();

            using (var httpClient = new HttpClient(this.httpClientHandler))
            {
                var url = "http://localhost:5057/api/Employees/GetEmployees";

                using (var response = await httpClient.GetAsync(url))
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();
                        employeesGetResult = JsonConvert.DeserializeObject<EmployeeGetlistResult>(apiResponse);

                        if (!employeesGetResult.success)
                        {
                            ViewBag.Message = employeesGetResult.message;
                            return View();
                        }
                    }
                }
            }

            return View(employeesGetResult.result);
        }

        // GET: EmployeeController/Details/5
        public async Task<ActionResult> Details(int id)
        {
            EmployeeGetResult employeeGetResult = new EmployeeGetResult();

            using (var httpClient = new HttpClient(this.httpClientHandler))
            {
                var url = $"http://localhost:5057/api/Employees/GetEmployeeById/{id}";

                using (var response = await httpClient.GetAsync(url))
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();
                        employeeGetResult = JsonConvert.DeserializeObject<EmployeeGetResult>(apiResponse);

                        if (!employeeGetResult.success)
                        {
                            ViewBag.Message = employeeGetResult.message;
                            return View();
                        }
                    }
                }
            }

            return View(employeeGetResult.result);
        }

        // GET: EmployeeController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: EmployeeController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(EmployeeBaseModel employeeBaseModel)
        {
            using (var httpClient = new HttpClient(this.httpClientHandler))
            {
                try
                {
                    var jsonContent = JsonConvert.SerializeObject(employeeBaseModel);
                    var contentString = new StringContent(jsonContent, System.Text.Encoding.UTF8, "application/json");
                    var response = await httpClient.PostAsync("http://localhost:5057/api/Employees/CreateEmployee", contentString);
                    response.EnsureSuccessStatusCode();
                    var apiResponse = await response.Content.ReadAsStringAsync();
                    var result = JsonConvert.DeserializeObject<BaseResult>(apiResponse);

                    if (result != null && result.success)
                    {
                        return RedirectToAction(nameof(Index));
                    }
                    else
                    {
                        ViewBag.Message = result?.message ?? "Error desconocido";
                        return View(employeeBaseModel);
                    }
                }
                catch (HttpRequestException ex)
                {
                    ViewBag.Message = $"Error en la solicitud HTTP: {ex.Message}";
                    return View(employeeBaseModel);
                }
            }
        }

        // GET: EmployeeController/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            EmployeeGetResult employeeGetResult = new EmployeeGetResult();

            using (var httpClient = new HttpClient(this.httpClientHandler))
            {
                var url = $"http://localhost:5057/api/Employees/GetEmployeeById/{id}";

                using (var response = await httpClient.GetAsync(url))
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();
                        employeeGetResult = JsonConvert.DeserializeObject<EmployeeGetResult>(apiResponse);

                        if (!employeeGetResult.success)
                        {
                            ViewBag.Message = employeeGetResult.message;
                            return View();
                        }
                    }
                }
            }

            return View(employeeGetResult.result);
        }

        // POST: EmployeeController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, EmployeeBaseModel employeeBaseModel)
        {
            using (var httpClient = new HttpClient(this.httpClientHandler))
            {
                try
                {
                    var jsonContent = JsonConvert.SerializeObject(employeeBaseModel);
                    var contentString = new StringContent(jsonContent, System.Text.Encoding.UTF8, "application/json");
                    var response = await httpClient.PutAsync($"http://localhost:5057/api/Employees/UpdateEmployee/{id}", contentString);
                    response.EnsureSuccessStatusCode();
                    var apiResponse = await response.Content.ReadAsStringAsync();
                    var result = JsonConvert.DeserializeObject<BaseResult>(apiResponse);

                    if (result != null && result.success)
                    {
                        return RedirectToAction(nameof(Index));
                    }
                    else
                    {
                        ViewBag.Message = result?.message ?? "Error desconocido";
                        return View(employeeBaseModel);
                    }
                }
                catch (HttpRequestException ex)
                {
                    ViewBag.Message = $"Error en la solicitud HTTP: {ex.Message}";
                    return View(employeeBaseModel);
                }
            }
        }

        // GET: EmployeeController/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            EmployeeGetResult employeeGetResult = new EmployeeGetResult();

            using (var httpClient = new HttpClient(this.httpClientHandler))
            {
                var url = $"http://localhost:5057/api/Employees/GetEmployeeById/{id}";

                using (var response = await httpClient.GetAsync(url))
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();
                        employeeGetResult = JsonConvert.DeserializeObject<EmployeeGetResult>(apiResponse);

                        if (!employeeGetResult.success)
                        {
                            ViewBag.Message = employeeGetResult.message;
                            return View();
                        }
                    }
                }
            }

            return View(employeeGetResult.result);
        }

        // POST: EmployeeController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            using (var httpClient = new HttpClient(this.httpClientHandler))
            {
                try
                {
                    var response = await httpClient.DeleteAsync($"http://localhost:5057/api/Employees/RemoveEmployee/{id}");
                    response.EnsureSuccessStatusCode();
                    var apiResponse = await response.Content.ReadAsStringAsync();
                    var result = JsonConvert.DeserializeObject<BaseResult>(apiResponse);

                    if (result != null && result.success)
                    {
                        return RedirectToAction(nameof(Index));
                    }
                    else
                    {
                        ViewBag.Message = result?.message ?? "Error desconocido";
                        return RedirectToAction(nameof(Delete), new { id });
                    }
                }
                catch (HttpRequestException ex)
                {
                    ViewBag.Message = $"Error en la solicitud HTTP: {ex.Message}";
                    return RedirectToAction(nameof(Delete), new { id });
                }
            }
        }
    }
}
