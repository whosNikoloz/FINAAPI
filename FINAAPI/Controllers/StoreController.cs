using FINAAPI.Models;
using FINAAPI.Services.intefaces;
using Microsoft.AspNetCore.Mvc;

namespace FINAAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StoreController : Controller
    {
        private readonly IStoreService _storeService;

        public StoreController(IStoreService storeService)
        {
            _storeService = storeService;
        }

        [HttpGet]
        public async Task<IActionResult> GetStores()
        {
            try
            {
                var groups = await _storeService.GetStoresAsync();
                return Ok(new { groups, ex = (string)null });
            }
            catch (System.Exception ex)
            {
                return Ok(new { groups = new List<Store>(), ex = ex.Message });
            }
        }
    }
}
