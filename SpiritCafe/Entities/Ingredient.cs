using System.ComponentModel.DataAnnotations;

namespace SpiritCafe.Entities;
public class Ingredient
{
    [Key]
    public int Id { get; set; }

    [Required]
    [MaxLength(100)]
    public string Name { get; set; } = default!;

    [Required]
    [Range(0, double.MaxValue)]
    public decimal Price { get; set; }

    public virtual ICollection<DishIngredient> DishIngredients { get; set; } = new List<DishIngredient>();
}