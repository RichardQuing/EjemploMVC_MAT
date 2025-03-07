using EjemploMVC_MAT.Models;
using Newtonsoft.Json;
using System.Net.Http;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace EjemploMVC_MAT.Services
{
    public class ProductService
    {
        private readonly HttpClient _httpClient;
        private readonly string apiURL = "https://f1api.dev/api/drivers";

        public ProductService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<Product>> GetProductsAsync(int limit = 5, int page = 1)
        {
            int offset = (page - 1) * limit;
            var response = await _httpClient.GetStringAsync($"{apiURL}?limit={limit}&offset={offset}");
            var jsonResponse = JsonConvert.DeserializeObject<dynamic>(response);
            var products = new List<Product>();

            foreach (var driver in jsonResponse.drivers)
            {
                products.Add(new Product
                {
                    driverId = driver.driverId,
                    name = driver.name,
                    surname = driver.surname,
                    nationality = driver.nationality,
                    birthday = driver.birthday,
                    url = driver.url
                });
            }

            return products;
        }
        public async Task<Product> GetProductAsync(string driverId)
        {
            var response = await _httpClient.GetStringAsync($"{apiURL}/{driverId}");
            var driver = JsonConvert.DeserializeObject<dynamic>(response);

            return new Product
            {
                driverId = driver.driverId,
                name = driver.name,
                surname = driver.surname,
                nationality = driver.nationality ?? "No disponible",
                birthday = driver.birthday != null ? DateTime.Parse(driver.birthday.ToString()) : (DateTime?)null,
                url = driver.url
            };
        }


    }
}