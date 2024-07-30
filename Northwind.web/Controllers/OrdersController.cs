using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Northwind.web.Models;
using Northwind.web.Results;
using Northwind.web.Results.Orders_Result;

namespace Northwind.Web.Controllers
{
    public class OrdersController : Controller
    {
        HttpClientHandler httpClientHandler = new HttpClientHandler();

        public OrdersController()
        {
            this.httpClientHandler = new HttpClientHandler();
            this.httpClientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyError) => { return true; };
        }

        // GET: OrdersController
        public async Task<ActionResult> Index()
        {
            OrdersGetListResult ordersGetResult = new OrdersGetListResult();

            using (var httpClient = new HttpClient(this.httpClientHandler))
            {
                var url = "http://localhost:5266/api/Orders/GetOrders";

                using (var response = await httpClient.GetAsync(url))
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();
                        ordersGetResult = JsonConvert.DeserializeObject<OrdersGetListResult>(apiResponse);

                        if (!ordersGetResult.success)
                        {
                            ViewBag.Message = ordersGetResult.message;
                            return View();
                        }
                    }
                }
            }

            return View(ordersGetResult.result);
        }

        // GET: OrdersController/Details/5
        public async Task<ActionResult> Details(int id)
        {
            OrdersGetResult ordersGetResult = new OrdersGetResult();

            using (var httpClient = new HttpClient(this.httpClientHandler))
            {
                var url = $"http://localhost:5266/api/Orders/GetOrderById/{id}";

                using (var response = await httpClient.GetAsync(url))
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();
                        ordersGetResult = JsonConvert.DeserializeObject<OrdersGetResult>(apiResponse);

                        if (!ordersGetResult.success)
                        {
                            ViewBag.Message = ordersGetResult.message;
                            return View();
                        }
                    }
                }
            }

            return View(ordersGetResult.result);
        }

        // GET: OrdersController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: OrdersController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(OrdersBaseModel ordersBaseModel)
        {
            using (var httpClient = new HttpClient(this.httpClientHandler))
            {
                try
                {
                    var jsonContent = JsonConvert.SerializeObject(ordersBaseModel);
                    var contentString = new StringContent(jsonContent, System.Text.Encoding.UTF8, "application/json");
                    var response = await httpClient.PostAsync("http://localhost:5266/api/Orders/CreateOrder", contentString);
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
                        return View(ordersBaseModel);
                    }
                }
                catch (HttpRequestException ex)
                {
                    ViewBag.Message = $"Error en la solicitud HTTP: {ex.Message}";
                    return View(ordersBaseModel);
                }
            }
        }

        // GET: OrdersController/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            OrdersGetResult ordersGetResult = new OrdersGetResult();

            using (var httpClient = new HttpClient(this.httpClientHandler))
            {
                var url = $"http://localhost:5266/api/Orders/GetOrderById/{id}";

                using (var response = await httpClient.GetAsync(url))
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();
                        ordersGetResult = JsonConvert.DeserializeObject<OrdersGetResult>(apiResponse);

                        if (!ordersGetResult.success)
                        {
                            ViewBag.Message = ordersGetResult.message;
                            return View();
                        }
                    }
                }
            }

            return View(ordersGetResult.result);
        }

        // POST: OrdersController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, OrdersBaseModel ordersBaseModel)
        {
            using (var httpClient = new HttpClient(this.httpClientHandler))
            {
                try
                {
                    var jsonContent = JsonConvert.SerializeObject(ordersBaseModel);
                    var contentString = new StringContent(jsonContent, System.Text.Encoding.UTF8, "application/json");
                    var response = await httpClient.PutAsync($"http://localhost:5266/api/Orders/UpdateOrder/{id}", contentString);
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
                        return View(ordersBaseModel);
                    }
                }
                catch (HttpRequestException ex)
                {
                    ViewBag.Message = $"Error en la solicitud HTTP: {ex.Message}";
                    return View(ordersBaseModel);
                }
            }
        }

        // GET: OrdersController/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            OrdersGetResult ordersGetResult = new OrdersGetResult();

            using (var httpClient = new HttpClient(this.httpClientHandler))
            {
                var url = $"http://localhost:5266/api/Orders/GetOrderById/{id}";

                using (var response = await httpClient.GetAsync(url))
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();
                        ordersGetResult = JsonConvert.DeserializeObject<OrdersGetResult>(apiResponse);

                        if (!ordersGetResult.success)
                        {
                            ViewBag.Message = ordersGetResult.message;
                            return View();
                        }
                    }
                }
            }

            return View(ordersGetResult.result);
        }

        // POST: OrdersController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            using (var httpClient = new HttpClient(this.httpClientHandler))
            {
                try
                {
                    var response = await httpClient.DeleteAsync($"http://localhost:5266/api/Orders/RemoveOrder/{id}");
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
