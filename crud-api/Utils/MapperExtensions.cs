using crud_api.Models.DTOs;
using crud_api.Models.Entities;

namespace crud_api.Utils
{
    public static class MapperExtensions
    {
        public static List<ProductResponseDTO> ConvertToListResponseDTO(this IEnumerable<Product> products)
            => products.Select(p => (ProductResponseDTO)p)
            .ToList();
    }
}
