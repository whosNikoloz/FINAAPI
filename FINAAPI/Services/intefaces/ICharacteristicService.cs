using FINAAPI.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FINAAPI.Services.intefaces
{
    public interface ICharacteristicService
    {
        Task<IEnumerable<Characteristic>> GetCharacteristicsAsync();
        Task<IEnumerable<CharacteristicValue>> GetCharacteristicValuesAsync();
        Task<IEnumerable<object>> GetCharacteristicValuesArrayAsync(int[] characterIds);
    }
} 