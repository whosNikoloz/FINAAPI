using FINAAPI.Models;
using System.Threading.Tasks;

namespace FINAAPI.Services.intefaces
{
    public interface IOrderService
    {
        Task<OrderResponse> SaveDocProductOutAsync(Order order);
        Task<ProductsOnWayResponse> GetProductsOnWayAsync();
    }
}
