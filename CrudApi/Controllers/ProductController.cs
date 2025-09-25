using CrudApi.Extensions.Mappers;
using CrudApi.Interfaces.Services;
using CrudApi.Models.DTOs;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace CrudApi.Controllers;

[ApiController]
[Route("products")]
public class ProductController : ControllerBase
{
    private readonly IProductService _productService;

    public ProductController(IProductService productService)
    {
        _productService = productService;
    }

    [HttpPost("")]
    public async Task<IActionResult> Insert([FromBody][Required] ProductRequestDTO productDTO)
    {
        var result = await _productService.Insert(productDTO.ToProduct());
        if (!result.IsSuccess)
            return UnprocessableEntity(result.Error);

        return Ok(result.Value.ToProductResponseDTO());
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> Get([FromRoute][Required] int id)
    {
        var result = await _productService.Get(id);
        if (!result.IsSuccess)
            return UnprocessableEntity(result.Error);

        return Ok(result.Value.ToProductResponseDTO());
    }

    [HttpGet("")]
    public async Task<IActionResult> Get(
        [FromQuery][Required] int pageNumber, [FromQuery][Required] int pageSize)
    {
        var result = await _productService.Get(pageNumber, pageSize);
        if (!result.IsSuccess)
            return UnprocessableEntity(result.Error);

        return Ok(result.Value.ToProductsResponseDTO());
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(
        [FromRoute][Required] int id, [FromBody][Required] ProductRequestDTO productDTO)
    {
        var result = await _productService.Update(id, productDTO.ToProduct());
        if (!result.IsSuccess)
            return UnprocessableEntity(result.Error);

        return Ok(result.Value.ToProductResponseDTO());
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
