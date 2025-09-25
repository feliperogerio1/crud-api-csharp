using CrudApi.Models.DTOs;
using CrudApi.Models.Entities;

namespace CrudApi.Extensions.Mappers;

public static class ProductMapper
{
    public static Product ToProduct(this ProductRequestDTO requestDTO)
    {
        return new()
        {
            Id = requestDTO.Id,
            Name = requestDTO.Name,
            Price = requestDTO.Price
        };
    }

    public static ProductResponseDTO ToProductResponseDTO(this Product product)
    {
        return new()
        {
            Id = product.Id,
            Name = product.Name,
            Price = product.Price
        };
    }

    public static List<ProductResponseDTO> ToProductsResponseDTO(this List<Product> products)
    {
        return products.Select(ToProductResponseDTO).ToList();
    }
}
