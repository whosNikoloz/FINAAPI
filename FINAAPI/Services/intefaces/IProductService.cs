using FINAAPI.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FINAAPI.Services.intefaces
{
    public interface IProductService
    {
        Task<IEnumerable<Product>> GetProductsAsync();
        Task<IEnumerable<Product>> GetProductsAfterAsync(DateTime after_date);
        Task<IEnumerable<ProductPrice>> GetProductPricesAsync();
        Task<IEnumerable<ProductPrice>> GetProductPricesAfterAsync(DateTime after_date);
        Task<IEnumerable<ProductUnit>> GetProductUnitsAsync();
        Task<IEnumerable<Product>> GetProductsByIdsAsync(int[] productIds);
        Task<IEnumerable<object>> GetProductAdditionalFieldsAsync();
        Task<IEnumerable<object>> GetProductImagesAsync(int productId);
        Task<IEnumerable<object>> GetProductsImageArrayAsync(int[] productIds);
        Task<IEnumerable<object>> GetProductsRestAsync();
    }
} 