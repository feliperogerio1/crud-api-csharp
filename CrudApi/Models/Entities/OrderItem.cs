using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CrudApi.Models.Entities;

public class OrderItem
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.None)]
    public int OrderId { get; set; }
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.None)]
    public int ProductId { get; set; }
    public int Quantity { get; set; }
    public Decimal SubTotal { get; set; }

    #region Navigation properties
    [ForeignKey("OrderId")]
    public Order Order { get; set; } = new();
    [ForeignKey("ProductId")]
    public Product Product { get; set; } = new();
    #endregion
}
