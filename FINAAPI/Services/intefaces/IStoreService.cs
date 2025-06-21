using FINAAPI.Models;

namespace FINAAPI.Services.intefaces
{
    public interface IStoreService
    {
        Task<IEnumerable<Store>> GetStoresAsync();
    }
}
