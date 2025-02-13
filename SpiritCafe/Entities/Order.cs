using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace SpiritCafe.Entities;

public class Order
{
    [Key]
    public int Id { get; set; }

    [Required]
    public DateTime OrderDate { get; set; } = DateTime.Now;

    [Required]
    public DateTime OrderCompletionTime { get; set; } = default!;

    [Required]
    public int CookId { get; set; }
    public virtual Cook? Cook { get; set; }

    public virtual ICollection<OrderDetails> OrderDetails { get; set; } = new List<OrderDetails>();
}