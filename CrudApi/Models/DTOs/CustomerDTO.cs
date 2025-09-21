namespace CrudApi.Models.DTOs;

public class CustomerRequestDTO
{
    public int Id { get; set; } 
    public string Name { get; init; } = string.Empty;
}

public class CustomerResponseDTO
{
    public int Id { get; init; }
    public string Name { get; init; } = string.Empty;
}