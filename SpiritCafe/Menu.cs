using System;
using System.Linq;
using SpiritCafe.Data;
using SpiritCafe.Entities;

namespace SpiritCafe
{
    static public class Menu
    {
        private static List<Dish> _dishes = new();

        public static void LoadDishes(OrderingSystemContext context)
        {
            _dishes = context.Dishes.ToList();
            var dishes = context.Dishes.Select(dish => $"- {dish.Name}: {dish.Price:C} EST:{dish.EstTime} Mins").ToList();
            dishes.ForEach(d => Console.WriteLine(d));
        }

        public static void Start(OrderingSystemContext context)
        {
            Console.WriteLine("Menu started:");
            LoadDishes(context);
            System.Console.WriteLine("Select a dish by typing its name or type 'exit' to quit.");
            var input = Console.ReadLine();

            while (input != "exit");
            {
                if (string.IsNullOrWhiteSpace(input))
                {
                    Console.WriteLine("Invalid input. Please try again.");
                    input = Console.ReadLine();
                }
                else
                {
                    List<string> dishNames = input.Split(' ', StringSplitOptions.RemoveEmptyEntries)
                            .Select(name => name.Trim())
                            .ToList();

                    var selectedDish = context.Dishes
                    .AsEnumerable()
                    .FirstOrDefault(dish => dishNames.Contains(dish.Name, StringComparer.OrdinalIgnoreCase));



                    if (selectedDish != null)
                    {
                        Console.WriteLine($"Selected Dish: {selectedDish.Name}");

                        CookHandler cookHandler = new CookHandler(context);
                        var availableCook = cookHandler.GetAvailableCook();

                        if (availableCook != null)
                        {
                            int totalEstTime = cookHandler.CalculateCookQueueEst(availableCook,selectedDish);

                            Console.WriteLine($"Cook {availableCook.Name} is available to prepare the dish. Estimated total cooking time: {totalEstTime} minutes.");                         
                            int orderId = CreateOrder(context, availableCook,totalEstTime); 
                            CreateOrderDetails(context, orderId, selectedDish, availableCook);

                            Console.WriteLine($"if you would like to make a new order type the name of the dish, otherwise type 'exit' to quit.");   

                        }
                        else
                        {
                            Console.WriteLine("No cook is available to prepare the dish at the moment.");
                        }
                    }
                    else Console.WriteLine("Dish not found. Please try again.");
                }

                input = Console.ReadLine();
            }
        }

        private static int CreateOrder(OrderingSystemContext context, Cook availableCook, int totalEstTime)
        {
            var newOrder = new Order
            {
                OrderDate = DateTime.Now,
                CookId = availableCook.Id,
                OrderCompletionTime = DateTime.Now.AddMinutes(totalEstTime)
            };

            context.Orders.Add(newOrder);
            context.SaveChanges();

            return newOrder.Id;
        }

        private static void CreateOrderDetails(OrderingSystemContext context, int orderId, Dish selectedDish, Cook availableCook)
        {
            var orderDetail = new OrderDetails
            {
                OrderId = orderId,
                DishId = selectedDish.Id,
                Price = selectedDish.Price
            };
            context.OrderDetails.Add(orderDetail);


            availableCook.CurrentWorkload++;
            availableCook.IsAvailable = !(availableCook.CurrentWorkload == Cook.s_maxWorkLoad);
            context.SaveChanges();
        }
    }
}
