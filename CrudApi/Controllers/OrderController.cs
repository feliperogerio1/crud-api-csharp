using CrudApi.Extensions.Mappers;
using CrudApi.Interfaces.Services;
using CrudApi.Models.DTOs;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace CrudApi.Controllers;

[ApiController]
[Route("orders")]
public class OrderController : ControllerBase
{
    private readonly IOrderService _orderService;

    public OrderController(IOrderService orderService)
    {
        _orderService = orderService;
    }

    [HttpPost("")]
    public async Task<IActionResult> Insert([FromBody][Required] OrderRequestDTO orderDTO)
    {
        var result = await _orderService.Insert(orderDTO.ToOrder());
        if (!result.IsSuccess)
            return UnprocessableEntity(result.Error);

        return Ok(result.Value.ToOrderResponseDTO());
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> Get([FromRoute][Required] int id)
    {
        var result = await _orderService.Get(id);
        if (!result.IsSuccess)
            return UnprocessableEntity(result.Error);

        return Ok(result.Value.ToOrderResponseDTO());
    }

    [HttpGet("")]
    public async Task<IActionResult> Get(
        [FromQuery][Required] int pageNumber, 
        [FromQuery][Required] int pageSize)
    {
        var result = await _orderService.Get(pageNumber, pageSize);
        if (!result.IsSuccess)
            return UnprocessableEntity(result.Error);

        return Ok(result.Value.ToOrdersResponseDTO());
    }

    [HttpGet("{id}/customer")]
    public async Task<IActionResult> GetWithCustomer([FromRoute][Required] int id)
    {
        var result = await _orderService.GetWithCustomer(id);
        if (!result.IsSuccess)
            return UnprocessableEntity(result.Error);

        return Ok(result.Value.ToOrderWithCustomerResponseDTO());
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(
        [FromRoute][Required] int id, [FromBody][Required] OrderRequestDTO orderDTO)
    {
        var result = await _orderService.Update(id, orderDTO.ToOrder());
        if (!result.IsSuccess)
            return UnprocessableEntity(result.Error);

        return Ok(result.Value.ToOrderResponseDTO());
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute][Required] int id)
    {
        var result = await _orderService.Delete(id);
        if (!result.IsSuccess)
            return UnprocessableEntity(result.Error);

        return Ok(result.Value);
    }
}
