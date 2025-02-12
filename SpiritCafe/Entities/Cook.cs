using System.ComponentModel.DataAnnotations;

namespace SpiritCafe.Entities;
public class Cook
{
    private static int s_maxCurrentDishes = 5;

    [Key]
    public int Id { get; set; }

    [Required]
    [MaxLength(100)]
    public string? Name { get; set; }

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}