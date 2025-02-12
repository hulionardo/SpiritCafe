using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SpiritCafe.Entities;

public class OrderDetails
{
    [Key]
    public int Id { get; set; }
    [Required]
    public int OrderId { get; set; }
    public virtual Order Order { get; set; }

    [Required]
    public int DishId { get; set; }
    public virtual Dish Dish { get; set; }
    public decimal Price { get; set; } 
}

