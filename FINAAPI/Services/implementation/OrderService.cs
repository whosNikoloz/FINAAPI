using FINAAPI.Models;
using FINAAPI.Services.intefaces;
using System.Threading.Tasks;

namespace FINAAPI.Services.implementation
{
    public class OrderService : IOrderService
    {
        private readonly FinaApiClient _apiClient;

        public OrderService(FinaApiClient apiClient)
        {
            _apiClient = apiClient;
        }

        public async Task<OrderResponse> SaveDocProductOutAsync(Order order)
        {
            var response = await _apiClient.PostAsync<OrderResponse>("saveDocProductOut", order);
            return response ?? new OrderResponse { Id = 0, Ex = "Failed to save document" };
        }

        public async Task<ProductsOnWayResponse> GetProductsOnWayAsync()
        {
            var response = await _apiClient.GetAsync<ProductsOnWayResponse>("getProductsOnWay");
            return response ?? new ProductsOnWayResponse { On_Way = new List<ProductOnWay>(), Ex = "Failed to get products on way" };
        }
    }
}
