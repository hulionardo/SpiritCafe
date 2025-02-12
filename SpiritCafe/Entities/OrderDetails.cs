using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SpiritCafe.Entities;

public class OrderDetails
{
    [Key]
    public int Id { get; set; }
    [Required]
    public virtual ICollection<OrderDetailsDish> OrderDetailsDishes { get; set; } = new List<OrderDetailsDish>();
}