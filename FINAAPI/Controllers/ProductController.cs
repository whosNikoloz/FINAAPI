using Microsoft.AspNetCore.Mvc;
using FINAAPI.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using FINAAPI.Services.intefaces;

namespace FINAAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public async Task<IActionResult> GetProducts()
        {
            try
            {
                var products = await _productService.GetProductsAsync();
                return Ok(new { products, ex = (string)null });
            }
            catch (System.Exception ex)
            {
                return Ok(new { products = new List<Product>(), ex = ex.Message }   );
            }
        }

        [HttpGet("after")]
        public async Task<IActionResult> GetProductsAfter(DateTime after_date)
        {
            try
            {
                var products = await _productService.GetProductsAfterAsync(after_date);
                return Ok(new { products, ex = (string)null });
            }
            catch (System.Exception ex)
            {
                return Ok(new { products = new List<Product>(), ex = ex.Message });
            }
        }

        [HttpGet("prices")]
        public async Task<IActionResult> GetProductPrices()
        {
            try
            {
                var prices = await _productService.GetProductPricesAsync();
                return Ok(new { prices, ex = (string)null });
            }
            catch (System.Exception ex)
            {
                return Ok(new { prices = new List<ProductPrice>(), ex = ex.Message });
            }
        }

        [HttpGet("prices/after")]
        public async Task<IActionResult> GetProductPricesAfter(DateTime after_date)
        {
            try
            {
                var prices = await _productService.GetProductPricesAfterAsync(after_date);
                return Ok(new { prices, ex = (string)null });
            }
            catch (System.Exception ex)
            {
                return Ok(new { prices = new List<ProductPrice>(), ex = ex.Message });
            }
        }

        [HttpGet("units")]
        public async Task<IActionResult> GetProductUnits()
        {
            try
            {
                var units = await _productService.GetProductUnitsAsync();
                return Ok(new { units, ex = (string)null });
            }
            catch (System.Exception ex)
            {
                return Ok(new { units = new List<ProductUnit>(), ex = ex.Message });
            }
        }

        [HttpPost("array")]
        public async Task<IActionResult> GetProductsByIds([FromBody] int[] productIds)
        {
            try
            {
                var products = await _productService.GetProductsByIdsAsync(productIds);
                return Ok(new { products, ex = (string)null });
            }
            catch (System.Exception ex)
            {
                return Ok(new { products = new List<Product>(), ex = ex.Message });
            }
        }

        [HttpGet("additional-fields")]
        public async Task<IActionResult> GetProductAdditionalFields()
        {
            try
            {
                var fields = await _productService.GetProductAdditionalFieldsAsync();
                return Ok(new { fields, ex = (string)null });
            }
            catch (System.Exception ex)
            {
                return Ok(new { fields = new List<object>(), ex = ex.Message });
            }
        }

        [HttpGet("images/{productId}")]
        public async Task<IActionResult> GetProductImages(int productId)
        {
            try
            {
                var images = await _productService.GetProductImagesAsync(productId);
                return Ok(new { images, ex = (string)null });
            }
            catch (System.Exception ex)
            {
                return Ok(new { images = new List<object>(), ex = ex.Message });
            }
        }

        [HttpPost("images/array")]
        public async Task<IActionResult> GetProductsImageArray([FromBody] int[] productIds)
        {
            try
            {
                var images = await _productService.GetProductsImageArrayAsync(productIds);
                return Ok(new { images, ex = (string)null });
            }
            catch (System.Exception ex)
            {
                return Ok(new { images = new List<object>(), ex = ex.Message });
            }
        }

        [HttpGet("rest")]
        public async Task<IActionResult> GetProductsRest()
        {
            try
            {
                var products = await _productService.GetProductsRestAsync();
                return Ok(new { products, ex = (string)null });
            }
            catch (System.Exception ex)
            {
                return Ok(new { products = new List<object>(), ex = ex.Message });
            }
        }
    }
} 