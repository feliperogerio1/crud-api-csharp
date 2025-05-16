using Microsoft.AspNetCore.Mvc;

using crud_api.Models.Entities;
using crud_api.Models.DTOs;
using crud_api.Interfaces.IServices;
using crud_api.Utils;

namespace crud_api.Controllers
{
    [ApiController]
    [Route("products")]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpPost("")]
        public async Task<IActionResult> Post([FromBody] ProductRequestDTO product)
        {
            var result = await _productService.Insert((Product)product);
            if (!result.IsSuccess)
                return UnprocessableEntity(result.Error);

            return Ok((ProductResponseDTO)result.Value);
        }

        [HttpGet("")]
        public async Task<IActionResult> Get()
        {
            var result = await _productService.Get();
            if (!result.IsSuccess)
                return UnprocessableEntity(result.Error);

            return Ok(result.Value.ConvertToListResponseDTO());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get([FromRoute] int id)
        {
            var result = await _productService.Get(id);
            if (!result.IsSuccess)
                return UnprocessableEntity(result.Error);

            if (result.Value is null)
                return Ok();

            return Ok((ProductResponseDTO)result.Value);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(
            [FromRoute] int id, 
            [FromBody] ProductRequestDTO productRequestDTO)
        {
            var result = await _productService.Update(id, (Product)productRequestDTO);
            if (!result.IsSuccess)
                return UnprocessableEntity(result.Error);

            return Ok((ProductResponseDTO)result.Value);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var result = await _productService.Delete(id);
            if (!result.IsSuccess)
                return UnprocessableEntity(result.Error);

            return Ok(result.Value);
        }
    }
}
