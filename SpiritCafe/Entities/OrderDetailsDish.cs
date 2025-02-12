namespace SpiritCafe.Entities;

public class OrderDetailsDish
{
    public int OrderDetailsId { get; set; }
    public OrderDetails OrderDetails { get; set; }

    public int DishId { get; set; }
    public Dish Dish { get; set; }
}