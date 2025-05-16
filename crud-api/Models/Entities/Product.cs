using crud_api.Models.DTOs;

namespace crud_api.Models.Entities
{
    public class Product
    {
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public decimal Price { get; set; }

        public DateTime CreatedDate { get; set; }

        public static explicit operator Product(ProductRequestDTO productRequestDTO)
            => new() 
                {
                    Name = productRequestDTO.Name,
                    Price = productRequestDTO.Price
                };
        
        public (bool isValid, string errors) IsValid()
        {
            var invalidFields = new List<string>();
            if (Name == string.Empty)
                invalidFields.Add(nameof(Name));

            if (Price <= 0)
                invalidFields.Add(nameof(Price));

            if (invalidFields.Count > 0)
                return (isValid: false, errors: $"Invalid fields: {string.Join(", ", invalidFields)}");

            return (isValid: true, errors: string.Empty);
        }
    }
}
