namespace CrudApi.Models.Entities;

public class Product
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public Decimal Price { get; set; }

    #region Navigation properties
    public List<OrderItem> OrderItems { get; set; } = new();
    #endregion
}
