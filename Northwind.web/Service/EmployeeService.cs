using Newtonsoft.Json;
using Northwind.web.IService;
using Northwind.web.Models;
using Northwind.web.Results.Employee_Result;
using Northwind.web.Results;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.Web.Services
{
    public class EmployeeService : IEmployeeServices
    {
        private readonly HttpClient _httpClient;

        public EmployeeService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<EmployeeGetlistResult> GetEmployeesAsync()
        {
            var response = await _httpClient.GetAsync("http://localhost:5057/api/Employees/GetEmployees");
            response.EnsureSuccessStatusCode();
            var apiResponse = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<EmployeeGetlistResult>(apiResponse);
        }

        public async Task<EmployeeGetResult> GetEmployeeByIdAsync(int id)
        {
            var response = await _httpClient.GetAsync($"http://localhost:5057/api/Employees/GetEmployeeById/{id}");
            response.EnsureSuccessStatusCode();
            var apiResponse = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<EmployeeGetResult>(apiResponse);
        }

        public async Task<BaseResult> CreateEmployeeAsync(EmployeeBaseModel employee)
        {
            var jsonContent = JsonConvert.SerializeObject(employee);
            var contentString = new StringContent(jsonContent, Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync("http://localhost:5057/api/Employees/CreateEmployee", contentString);
            response.EnsureSuccessStatusCode();
            var apiResponse = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<BaseResult>(apiResponse);
        }

        public async Task<BaseResult> UpdateEmployeeAsync(int id, EmployeeBaseModel employee)
        {
            var jsonContent = JsonConvert.SerializeObject(employee);
            var contentString = new StringContent(jsonContent, Encoding.UTF8, "application/json");
            var response = await _httpClient.PutAsync($"http://localhost:5057/api/Employees/UpdateEmployee?id={id}", contentString);
            response.EnsureSuccessStatusCode();
            var apiResponse = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<BaseResult>(apiResponse);
        }

        public async Task<BaseResult> DeleteEmployeeAsync(int id)
        {
            var response = await _httpClient.DeleteAsync($"http://localhost:5057/api/Employees/RemoveEmployee/{id}");
            response.EnsureSuccessStatusCode();
            var apiResponse = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<BaseResult>(apiResponse);
        }
    }
}
