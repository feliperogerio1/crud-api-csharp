namespace CrudApi.Models.DTOs;

public class ProductRequestDTO
{
    public int Id { get; init; }
    public string Name { get; init; } = string.Empty;
    public Decimal Price { get; init; }
}

public class ProductResponseDTO
{
    public int Id { get; init; }
    public string Name { get; init; } = string.Empty;
    public Decimal Price { get; init; }
}
