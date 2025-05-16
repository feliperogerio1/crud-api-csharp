using crud_api.Models.Entities;

namespace crud_api.Models.DTOs
{
    public class ProductRequestDTO
    {
        public string Name { get; set; } = string.Empty;

        public decimal Price { get; set; } 
    }

    public class ProductResponseDTO
    {
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public decimal Price { get; set; }

        public DateTime CreatedDate { get; set; }

        public static explicit operator ProductResponseDTO(Product product)
            => new()
                {
                    Id = product.Id,
                    Name = product.Name,
                    Price = product.Price,
                    CreatedDate = product.CreatedDate
                };
    }
}
