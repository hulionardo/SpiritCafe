using SpiritCafe.Data;
using SpiritCafe.Entities;

namespace SpiritCafe
{
    static public class Menu
    {
        public static void LoadDishes(OrderingSystemContext context)
        {
            var dishes = context.Dishes.Select(dish => $"- {dish.Name}: {dish.Price:C} EST:{dish.EstTime} Mins").ToList();
            dishes.ForEach(d => Console.WriteLine(d));
        }

        public static void UpdateDishesPrice(OrderingSystemContext context)
        {
            context.Dishes.ToList().ForEach(dish => dish.UpdatePrice());
        }

        public static void Start(OrderingSystemContext context)
        {
            Console.WriteLine("Menu started:");
            LoadDishes(context);
            UpdateDishesPrice(context);
            Console.WriteLine("Select a dish by typing its name or type 'exit' to quit.");
            var input = Console.ReadLine();

            while (input != "exit")
            {
                if (string.IsNullOrWhiteSpace(input))
                {
                    Console.WriteLine("Invalid input. Please try again.");
                    input = Console.ReadLine();
                    continue;
                }

                List<string> dishNames = input.Split(' ', StringSplitOptions.RemoveEmptyEntries)
                        .Select(name => name.Trim())
                        .ToList();

                var selectedDish = context.Dishes.AsQueryable()
                        .FirstOrDefault(dish => dishNames
                        .Select(name => name.ToLower())
                        .Contains(dish.Name.ToLower()));


                if (selectedDish is null)
                {
                    Console.WriteLine("Dish not found. Please try again.");
                    input = Console.ReadLine();
                    continue;
                }

                Console.WriteLine($"Selected Dish: {selectedDish.Name}");

                CookHandler cookHandler = new(context);
                var availableCook = cookHandler.GetAvailableCook();

                if (availableCook is null)
                {
                    Console.WriteLine("No cook is available to prepare the dish at the moment.");
                    input = Console.ReadLine();
                    continue;
                }

                int totalEstTime = cookHandler.CalculateCookQueueEst(availableCook, selectedDish);


                Console.WriteLine($"Cook {availableCook.Name} is available to prepare the dish. Estimated total cooking time: {totalEstTime} minutes.");
                int orderId = CreateOrder(context, availableCook, totalEstTime);
                CreateOrderDetails(context, orderId, selectedDish);

                Console.WriteLine($"Order created, if you would like to make a new order type the name of the dish, otherwise type 'exit' to quit.");
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

        private static void CreateOrderDetails(OrderingSystemContext context, int orderId, Dish selectedDish)
        {
            var orderDetail = new OrderDetails
            {
                OrderId = orderId,
                DishId = selectedDish.Id,
            };
            context.OrderDetails.Add(orderDetail);
            context.SaveChanges();
        }
    }
}