
using System.Runtime.CompilerServices;
using Microsoft.VisualBasic;
using SpiritCafe.Data;
using SpiritCafe.Entities;

namespace SpiritCafe;

static public class Menu
{
    private static List<Dish> _dishes = new();

    public static void LoadDishes(OrderingSystemContext context)
    {
        _dishes = context.Dishes.ToList();
    }

    public static void Start()
    {
        Console.WriteLine("Menu started:");
        foreach (var dish in _dishes)
        {
            Console.WriteLine($"- {dish.Name}: {dish.Price:C} EST:{dish.EstTime} Mins" );
        }

        System.Console.WriteLine("Select a dish by typing its name");
        var input = Console.ReadLine(); 

        if (string.IsNullOrWhiteSpace(input))
        {
            Console.WriteLine("Invalid input. Please try again.");
            return;
        }

        List<string> dishNames = input.Split(' ', StringSplitOptions.RemoveEmptyEntries)
                                    .Select(name => name.Trim())
                                    .ToList();

        var selectedDish = _dishes.FirstOrDefault(d => dishNames.Contains(d.Name, StringComparer.OrdinalIgnoreCase));

        if (selectedDish != null)
        {
            Console.WriteLine($"Selected Dish: {selectedDish.Name}");
        }
        else
        {
            Console.WriteLine("No matching dish found.");
        }  

        

    }
}