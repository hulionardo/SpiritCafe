
using System.ComponentModel.DataAnnotations;

namespace SpiritCafe.Entities;
public class Dish
{
    private const decimal TaxRate = 1.2m;

    [Key]
    public int Id { get; set; }

    [Required]
    [MaxLength(100)]
    public string Name { get; set; } = default!;

    [Required]
    public string Description { get; set; } = default!; 

    [Required]
    [Range(0, double.MaxValue)]
    public decimal Price { get; set; }

    [Required]
    [Range(1, 300)]
    public int EstTime { get; set; }

    public virtual ICollection<DishIngredient> DishIngredients { get; set; } = new List<DishIngredient>();

    public void UpdatePrice() => Price = DishIngredients.Sum(di => di.Ingredient!.Price) * TaxRate;
}