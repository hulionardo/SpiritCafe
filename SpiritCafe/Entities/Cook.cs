using System.ComponentModel.DataAnnotations;

namespace SpiritCafe.Entities;
public class Cook
{
    public readonly static int s_maxWorkLoad = 5;

    [Key]
    public int Id { get; set; }

    [Required]
    [MaxLength(100)]
    public string Name { get; set; }

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();

    public bool IsAvailable { get; set; } = true;
    
    public int CurrentWorkload { get; set; } = 0;
}