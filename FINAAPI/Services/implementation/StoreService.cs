using FINAAPI.Models;
using FINAAPI.Services.intefaces;

namespace FINAAPI.Services.implementation
{
    public class StoreService : IStoreService
    {
        private readonly FinaApiClient _apiClient;

        public StoreService(FinaApiClient apiClient)
        {
            _apiClient = apiClient;
        }

        public async Task<IEnumerable<Store>> GetStoresAsync()
        {
            var response = await _apiClient.GetAsync<StoresApiResponse<List<Store>>>("getStores");
            return response?.stores ?? new List<Store>();
        }

    }

    public class StoresApiResponse<T>
    {
        public T stores { get; set; }
        public string ex { get; set; }
    }
}
