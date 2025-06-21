using FINAAPI.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using FINAAPI.Services.intefaces;

namespace FINAAPI.Services.implementation
{
    public class ProductService : IProductService
    {
        private readonly FinaApiClient _apiClient;

        public ProductService(FinaApiClient apiClient)
        {
            _apiClient = apiClient;
        }

        public async Task<IEnumerable<Product>> GetProductsAsync()
        {
            var response = await _apiClient.GetAsync<ProductsApiResponse<List<Product>>>("getProducts");
            return response?.products ?? new List<Product>();
        }

        public async Task<IEnumerable<ProductPrice>> GetProductPricesAsync()
        {
            var response = await _apiClient.GetAsync<ProductsApiResponse<List<ProductPrice>>>("getProductPrices");
            return response?.prices ?? new List<ProductPrice>();
        }

        public async Task<IEnumerable<ProductUnit>> GetProductUnitsAsync()
        {
            var response = await _apiClient.GetAsync<ProductsApiResponse<List<ProductUnit>>>("getProductUnits");
            return response?.units ?? new List<ProductUnit>();
        }

        public async Task<IEnumerable<Product>> GetProductsByIdsAsync(int[] productIds)
        {
            var response = await _apiClient.PostAsync<ProductsApiResponse<List<Product>>>("getProductsArray", productIds);
            return response?.products ?? new List<Product>();
        }

        public async Task<IEnumerable<object>> GetProductAdditionalFieldsAsync()
        {
            var response = await _apiClient.GetAsync<ProductsApiResponse<List<object>>>("getProductAdditionalFields");
            return response?.fields ?? new List<object>();
        }

        public async Task<IEnumerable<object>> GetProductImagesAsync(int productId)
        {
            var response = await _apiClient.GetAsync<ProductsApiResponse<List<object>>>($"getProductImages/{productId}");
            return response?.images ?? new List<object>();
        }

        public async Task<IEnumerable<object>> GetProductsImageArrayAsync(int[] productIds)
        {
            var response = await _apiClient.PostAsync<ProductsApiResponse<List<object>>>("getProductsImageArray", productIds);
            return response?.images ?? new List<object>();
        }

        public async Task<IEnumerable<object>> GetProductsRestAsync()
        {
            var response = await _apiClient.GetAsync<ProductsApiResponse<List<object>>>("getProductsRest");
            return response?.products ?? new List<object>();
        }

        public async Task<IEnumerable<Product>> GetProductsAfterAsync(DateTime after_date)
        {
            var response = await _apiClient.GetAsync<ProductsApiResponse<List<Product>>>($"getProductsAfter/{after_date}");
            return response?.products ?? new List<Product>();
        }

        public async Task<IEnumerable<ProductPrice>> GetProductPricesAfterAsync(DateTime after_date)
        {
            var response = await _apiClient.GetAsync<ProductsApiResponse<List<ProductPrice>>>($"getProductPricesAfter/{after_date}");
            return response?.prices ?? new List<ProductPrice>();
        }
    }

    public class ProductsApiResponse<T>
    {
        public T products { get; set; }
        public T prices { get; set; }
        public T units { get; set; }
        public T fields { get; set; }
        public T images { get; set; }
        public string ex { get; set; }
    }
} 