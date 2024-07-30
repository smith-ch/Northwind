using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Northwind.web.Models;
using Northwind.web.Results;
using Northwind.web.Results.Supplier_Result;

namespace Northwind.Web.Controllers
{
    public class SuppliersController : Controller
    {
        HttpClientHandler httpClientHandler = new HttpClientHandler();

        public SuppliersController()
        {
            this.httpClientHandler = new HttpClientHandler();
            this.httpClientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyError) => { return true; };
        }

        public async Task<ActionResult> Index()
        {
            SuppliersGetListResult suppliersGetResult = new SuppliersGetListResult();

            using (var httpClient = new HttpClient(this.httpClientHandler))
            {
                var url = "http://localhost:5085/api/Suppliers/GetSuppliers";

                using (var response = await httpClient.GetAsync(url))
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();
                        suppliersGetResult = JsonConvert.DeserializeObject<SuppliersGetListResult>(apiResponse);

                        if (!suppliersGetResult.success)
                        {
                            ViewBag.Message = suppliersGetResult.message;
                            return View();
                        }
                    }
                }
            }

            return View(suppliersGetResult.result);
        }

        public async Task<ActionResult> Details(int id)
        {
            SuppliersGetResult suppliersGetResult = new SuppliersGetResult();

            using (var httpClient = new HttpClient(this.httpClientHandler))
            {
                var url = $"http://localhost:5085/api/Suppliers/GetSuppliersByid/{id}";

                using (var response = await httpClient.GetAsync(url))
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();
                        suppliersGetResult = JsonConvert.DeserializeObject<SuppliersGetResult>(apiResponse);

                        if (!suppliersGetResult.success)
                        {
                            ViewBag.Message = suppliersGetResult.message;
                            return View();
                        }
                    }
                }
            }

            return View(suppliersGetResult.result);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(SuppliersBaseModel suppliersBaseModel)
        {
            using (var httpClient = new HttpClient(this.httpClientHandler))
            {
                try
                {
                    var jsonContent = JsonConvert.SerializeObject(suppliersBaseModel);
                    var contentString = new StringContent(jsonContent, System.Text.Encoding.UTF8, "application/json");
                    var response = await httpClient.PostAsync("http://localhost:5085/api/Suppliers/SaveSuppliers", contentString);
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
                        return View(suppliersBaseModel);
                    }
                }
                catch (HttpRequestException ex)
                {
                    ViewBag.Message = $"Error en la solicitud HTTP: {ex.Message}";
                    return View(suppliersBaseModel);
                }
            }
        }

        public async Task<ActionResult> Edit(int id)
        {
            SuppliersGetResult suppliersGetResult = new SuppliersGetResult();

            using (var httpClient = new HttpClient(this.httpClientHandler))
            {
                var url = $"http://localhost:5085/api/Suppliers/GetSuppliersByid/{id}";

                using (var response = await httpClient.GetAsync(url))
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();
                        suppliersGetResult = JsonConvert.DeserializeObject<SuppliersGetResult>(apiResponse);

                        if (!suppliersGetResult.success)
                        {
                            ViewBag.Message = suppliersGetResult.message;
                            return View();
                        }
                    }
                }
            }

            return View(suppliersGetResult.result);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, SuppliersBaseModel suppliersBaseModel)
        {
            using (var httpClient = new HttpClient(this.httpClientHandler))
            {
                try
                {
                    var jsonContent = JsonConvert.SerializeObject(suppliersBaseModel);
                    var contentString = new StringContent(jsonContent, System.Text.Encoding.UTF8, "application/json");
                    var response = await httpClient.PutAsync($"http://localhost:5085/api/Suppliers/UpdateSuppliers/{id}", contentString);
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
                        return View(suppliersBaseModel);
                    }
                }
                catch (HttpRequestException ex)
                {
                    ViewBag.Message = $"Error en la solicitud HTTP: {ex.Message}";
                    return View(suppliersBaseModel);
                }
            }
        }

        public async Task<ActionResult> Delete(int id)
        {
            SuppliersGetResult suppliersGetResult = new SuppliersGetResult();

            using (var httpClient = new HttpClient(this.httpClientHandler))
            {
                var url = $"http://localhost:5085/api/Suppliers/GetSuppliersByid/{id}";

                using (var response = await httpClient.GetAsync(url))
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();
                        suppliersGetResult = JsonConvert.DeserializeObject<SuppliersGetResult>(apiResponse);

                        if (!suppliersGetResult.success)
                        {
                            ViewBag.Message = suppliersGetResult.message;
                            return View();
                        }
                    }
                }
            }

            return View(suppliersGetResult.result);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            using (var httpClient = new HttpClient(this.httpClientHandler))
            {
                try
                {
                    var response = await httpClient.DeleteAsync($"http://localhost:5085/api/Suppliers/RemoveSuppliers/{id}");
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
