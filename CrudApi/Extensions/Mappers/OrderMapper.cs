using CrudApi.Models.DTOs;
using CrudApi.Models.Entities;

namespace CrudApi.Extensions.Mappers;

public static class OrderMapper
{
    public static Order ToOrder(this OrderRequestDTO orderDTO)
    {
        return new()
        {
            Id = orderDTO.Id,
            OrderDate = orderDTO.OrderDate,
            Total = orderDTO.Total,
            CustomerId = orderDTO.CustomerId
        };
    }

    public static OrderResponseDTO ToOrderResponseDTO(this Order order)
    {
        return new()
        {
            Id = order.Id,
            OrderDate = order.OrderDate,
            Total = order.Total,
            CustomerId = order.CustomerId
        };
    }

    public static List<OrderResponseDTO> ToOrdersResponseDTO(this List<Order> orders)
    {
        return orders.Select(ToOrderResponseDTO).ToList();
    }

    public static OrderWithCustomerResponseDTO ToOrderWithCustomerResponseDTO(this Order order)
    {
        return new()
        {
            Id = order.Id,
            OrderDate = order.OrderDate,
            Total = order.Total,
            CustomerId = order.CustomerId,
            Customer = order.Customer
        };
    }
}
