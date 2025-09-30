using CrudApi.Models.Entities;

namespace CrudApi.Models.DTOs;

public class OrderRequestDTO
{
    public int Id { get; init; }
    public DateTime OrderDate { get; init; }
    public Decimal Total { get; init; }
    public int CustomerId { get; init; }
    public List<OrderItem> OrderItems { get; init; } = new();
}

public class OrderResponseDTO
{
    public int Id { get; init; }
    public DateTime OrderDate { get; init; }
    public Decimal Total { get; init; }
    public int CustomerId { get; init; }
}

public class OrderWithItemsResponseDTO : OrderResponseDTO
{
    public Customer Customer { get; init; } = new();
    public List<OrderItem> OrderItems { get; init; } = new();
}
