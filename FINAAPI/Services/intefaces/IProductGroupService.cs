using FINAAPI.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FINAAPI.Services.intefaces
{
    public interface IProductGroupService
    {
        Task<IEnumerable<ProductGroup>> GetProductGroupsAsync();
        Task<IEnumerable<ProductGroup>> GetWebProductGroupsAsync();
        Task<ProductGroup> GetProductGroupByIdAsync(int id);
        Task<IEnumerable<ProductGroup>> GetChildGroupsAsync(int parentId);
    }
} 