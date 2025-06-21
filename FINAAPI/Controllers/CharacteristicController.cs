using Microsoft.AspNetCore.Mvc;
using FINAAPI.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using FINAAPI.Services.intefaces;

namespace FINAAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CharacteristicController : ControllerBase
    {
        private readonly ICharacteristicService _characteristicService;

        public CharacteristicController(ICharacteristicService characteristicService)
        {
            _characteristicService = characteristicService;
        }

        [HttpGet]
        public async Task<IActionResult> GetCharacteristics()
        {
            try
            {
                var characteristics = await _characteristicService.GetCharacteristicsAsync();
                return Ok(new { characteristics, ex = (string)null });
            }
            catch (System.Exception ex)
            {
                return Ok(new { characteristics = new List<Characteristic>(), ex = ex.Message });
            }   
        }

        [HttpGet("values")]
        public async Task<IActionResult> GetCharacteristicValues()
        {
            try
            {
                var values = await _characteristicService.GetCharacteristicValuesAsync();
                return Ok(new { characteristic_values = values, ex = (string)null });
            }
            catch (System.Exception ex)
            {
                return Ok(new { characteristic_values = new List<CharacteristicValue>(), ex = ex.Message });
            }
        }

        [HttpPost("values/array")]
        public async Task<IActionResult> GetProductsImageArray([FromBody] int[] characterIds)
        {
            try
            {
                var values = await _characteristicService.GetCharacteristicValuesArrayAsync(characterIds);
                return Ok(new { values, ex = (string)null });
            }
            catch (System.Exception ex)
            {
                return Ok(new { values = new List<object>(), ex = ex.Message });
            }
        }


    }
} 