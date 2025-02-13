using System.ComponentModel.DataAnnotations;
using System.Reflection.Metadata;
namespace SpiritCafe.Entities;

public class OrderDetails
{
    [Key]
    public int Id { get; set; }
    [Required]
    public int OrderId { get; set; }
    public virtual Order? Order { get; set; }

    [Required]
    public int DishId { get; set; }
    public virtual Dish? Dish { get; set; }
}
