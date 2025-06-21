using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using FINAAPI.Models;
using FINAAPI.Services.intefaces;
using System;
using System.Threading.Tasks;

namespace FINAAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpPost("saveDocProductOut")]
        public async Task<ActionResult<OrderResponse>> SaveDocProductOut([FromBody] Order request)
        {
            try
            {
                var response = await _orderService.SaveDocProductOutAsync(request);
                if (response.Ex != null)
                {
                    return BadRequest(response);
                }
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(new OrderResponse { Id = 0, Ex = ex.Message });
            }
        }

        [HttpGet("getProductsOnWay")]
        public async Task<ActionResult<ProductsOnWayResponse>> GetProductsOnWay()
        {
            try
            {
                var response = await _orderService.GetProductsOnWayAsync();
                if (response.Ex != null)
                {
                    return BadRequest(response);
                }
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(new ProductsOnWayResponse { Ex = ex.Message });
            }
        }
    }
}
