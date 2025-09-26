using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CrudApi.Models.Entities;

public class Order
{
    [Key]
    public int Id { get; set; }
    public DateTime OrderDate { get; set; }
    public Decimal Total { get; set; }
    public int CustomerId { get; set; }

    #region Navigation properties
    [ForeignKey("CustomerId")]
    public Customer Customer { get; set; } = new();
    #endregion
}
