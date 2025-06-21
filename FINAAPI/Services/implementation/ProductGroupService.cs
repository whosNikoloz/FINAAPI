using FINAAPI.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using FINAAPI.Services.intefaces;

namespace FINAAPI.Services.implementation
{
    public class ProductGroupService : IProductGroupService
    {
        private readonly FinaApiClient _apiClient;

        public ProductGroupService(FinaApiClient apiClient)
        {
            _apiClient = apiClient;
        }

        public async Task<IEnumerable<ProductGroup>> GetProductGroupsAsync()
        {
            var response = await _apiClient.GetAsync<GroupsApiResponse<List<ProductGroup>>>("getProductGroups");
            return response?.groups ?? new List<ProductGroup>();
        }

        public async Task<IEnumerable<ProductGroup>> GetWebProductGroupsAsync()
        {
            var response = await _apiClient.GetAsync<GroupsApiResponse<List<ProductGroup>>>("getWebProductGroups");
            return response?.groups ?? new List<ProductGroup>();
        }

        public async Task<ProductGroup> GetProductGroupByIdAsync(int id)
        {
            var groups = await GetProductGroupsAsync();
            return groups.FirstOrDefault(g => g.Id == id);
        }

        public async Task<IEnumerable<ProductGroup>> GetChildGroupsAsync(int parentId)
        {
            var groups = await GetProductGroupsAsync();
            return groups.Where(g => g.ParentId == parentId);
        }
    }

    public class GroupsApiResponse<T>
    {
        public T groups { get; set; }
        public string ex { get; set; }
    }
} 