using Newtonsoft.Json;
using Northwind.web.Models;
using Northwind.web.Results.Supplier_Result;
using Northwind.web.Results;
using System.Text;
using Northwind.web.IService;

namespace Northwind.Web.Services
{
    public class SuppliersService : ISuppliersService
    {
        private readonly HttpClient _httpClient;

        public SuppliersService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<SuppliersGetListResult> GetSuppliersAsync()
        {
            var response = await _httpClient.GetAsync("http://localhost:5085/api/Suppliers/GetSuppliers");
            response.EnsureSuccessStatusCode();
            var apiResponse = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<SuppliersGetListResult>(apiResponse);
        }

        public async Task<SuppliersGetResult> GetSupplierByIdAsync(int id)
        {
            var response = await _httpClient.GetAsync($"http://localhost:5085/api/Suppliers/GetSuppliersByid/{id}");
            response.EnsureSuccessStatusCode();
            var apiResponse = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<SuppliersGetResult>(apiResponse);
        }

        public async Task<BaseResult> CreateSupplierAsync(SuppliersBaseModel supplier)
        {
            var jsonContent = JsonConvert.SerializeObject(supplier);
            var contentString = new StringContent(jsonContent, Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync("http://localhost:5085/api/Suppliers/SaveSuppliers", contentString);
            response.EnsureSuccessStatusCode();
            var apiResponse = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<BaseResult>(apiResponse);
        }

        public async Task<BaseResult> UpdateSupplierAsync(int id, SuppliersBaseModel supplier)
        {
            var jsonContent = JsonConvert.SerializeObject(supplier);
            var contentString = new StringContent(jsonContent, Encoding.UTF8, "application/json");
            var response = await _httpClient.PutAsync($"http://localhost:5085/api/Suppliers/UpdateSuppliers?id={id}", contentString);
            response.EnsureSuccessStatusCode();
            var apiResponse = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<BaseResult>(apiResponse);
        }

        public async Task<BaseResult> DeleteSupplierAsync(int id)
        {
            var response = await _httpClient.DeleteAsync($"http://localhost:5085/api/Suppliers/RemoveSuppliers?id={id}");
            response.EnsureSuccessStatusCode();
            var apiResponse = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<BaseResult>(apiResponse);
        }
    }
}
