using FINAAPI.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using FINAAPI.Services.intefaces;

namespace FINAAPI.Services.implementation
{
    public class CharacteristicService : ICharacteristicService
    {
        private readonly FinaApiClient _apiClient;

        public CharacteristicService(FinaApiClient apiClient)
        {
            _apiClient = apiClient;
        }

        public async Task<IEnumerable<Characteristic>> GetCharacteristicsAsync()
        {
            var response = await _apiClient.GetAsync<ApiResponse<List<Characteristic>>>("getCharacteristics");
            return response?.characteristics ?? new List<Characteristic>();
        }

        public async Task<IEnumerable<CharacteristicValue>> GetCharacteristicValuesAsync()
        {
            var response = await _apiClient.GetAsync<ApiResponse<List<CharacteristicValue>>>("getCharacteristicValues");
            return response?.characteristic_values ?? new List<CharacteristicValue>();
        }

        public async Task<IEnumerable<object>> GetCharacteristicValuesArrayAsync(int[] characterIds)
        {
            var response = await _apiClient.PostAsync<ApiResponse<List<object>>>("getCharacteristicValuesArray" , characterIds);
            return response?.characteristic_values ?? new List<object>();
        }
    }

    public class ApiResponse<T>
    {
        public T characteristics { get; set; }
        public T characteristic_values { get; set; }
        public string ex { get; set; }
    }
} 