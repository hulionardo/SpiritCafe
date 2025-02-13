using System.ComponentModel.DataAnnotations;

namespace SpiritCafe.Entities;
public class Cook
{
    public const int MaxWorkLoad = 5;

    [Key]
    public int Id { get; set; }

    [Required]
    [MaxLength(100)]
    public string Name { get; set; } = default!;

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();

    public int CurrentWorkload () => Orders.Count(order => order.OrderCompletionTime > DateTime.Now);

}