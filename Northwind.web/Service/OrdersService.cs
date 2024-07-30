using Newtonsoft.Json;
using Northwind.web.Models;
using Northwind.web.Results.Orders_Result;
using Northwind.web.Results;
using System.Text;
using Northwind.web.IService;

namespace Northwind.Web.Services
{
    public class OrdersService : IOrdersService
    {
        private readonly HttpClient _httpClient;

        public OrdersService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<OrdersGetListResult> GetOrdersAsync()
        {
            var response = await _httpClient.GetAsync("http://localhost:5266/api/Orders/GetOrders");
            response.EnsureSuccessStatusCode();
            var apiResponse = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<OrdersGetListResult>(apiResponse);
        }

        public async Task<OrdersGetResult> GetOrderByIdAsync(int id)
        {
            var response = await _httpClient.GetAsync($"http://localhost:5266/api/Orders/GetOrderById/{id}");
            response.EnsureSuccessStatusCode();
            var apiResponse = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<OrdersGetResult>(apiResponse);
        }

        public async Task<BaseResult> CreateOrderAsync(OrdersBaseModel order)
        {
            var jsonContent = JsonConvert.SerializeObject(order);
            var contentString = new StringContent(jsonContent, Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync("http://localhost:5266/api/Orders/CreateOrder", contentString);
            response.EnsureSuccessStatusCode();
            var apiResponse = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<BaseResult>(apiResponse);
        }

        public async Task<BaseResult> UpdateOrderAsync(int id, OrdersBaseModel order)
        {
            var jsonContent = JsonConvert.SerializeObject(order);
            var contentString = new StringContent(jsonContent, Encoding.UTF8, "application/json");
            var response = await _httpClient.PutAsync($"http://localhost:5266/api/Orders/UpdateOrder?id={id}", contentString);
            response.EnsureSuccessStatusCode();
            var apiResponse = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<BaseResult>(apiResponse);
        }

        public async Task<BaseResult> DeleteOrderAsync(int id)
        {
            var response = await _httpClient.DeleteAsync($"http://localhost:5266/api/Orders/RemoveOrder/{id}");
            response.EnsureSuccessStatusCode();
            var apiResponse = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<BaseResult>(apiResponse);
        }
    }
}
