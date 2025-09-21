using CrudApi.Extensions.Mappers;
using CrudApi.Interfaces.Services;
using CrudApi.Models.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace CrudApi.Controllers;

[ApiController]
[Route("customers")]
public class CustomerController : ControllerBase
{
    private readonly ICustomerService _customerService;

    public CustomerController(ICustomerService customerService)
    {
        _customerService = customerService;
    }

    [HttpPost("")]
    public async Task<IActionResult> Insert([FromBody] CustomerRequestDTO customerDTO)
    {
        var result = await _customerService.Insert(customerDTO.ToCustomer());
        if (!result.IsSuccess)
            return UnprocessableEntity(result.Error);

        return Ok(result.Value.ToCustomerResponseDTO());
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> Get([FromRoute] int id)
    {
        var result = await _customerService.Get(id);
        if (!result.IsSuccess)
            return UnprocessableEntity(result.Error);

        return Ok(result.Value.ToCustomerResponseDTO());
    }

    [HttpGet("")]
    public async Task<IActionResult> Get([FromQuery] int pageNumber, [FromQuery] int pageSize)
    {
        var result = await _customerService.Get(pageNumber, pageSize);
        if (!result.IsSuccess)
            return UnprocessableEntity(result.Error);

        return Ok(result.Value.ToCustomersResponseDTO());
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(
        [FromRoute] int id, 
        [FromBody] CustomerRequestDTO customerDTO)
    {
        var result = await _customerService.Update(id, customerDTO.ToCustomer());
        if (!result.IsSuccess)
            return UnprocessableEntity(result.Error);

        return Ok(result.Value.ToCustomerResponseDTO());
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] int id)
    {
        var result = await _customerService.Delete(id);
        if (!result.IsSuccess)
            return UnprocessableEntity(result.Error);

        return Ok(result.Value);
    }
}