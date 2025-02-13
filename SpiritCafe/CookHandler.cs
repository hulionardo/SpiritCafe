using SpiritCafe.Data;
using SpiritCafe.Entities;

namespace SpiritCafe;
public class CookHandler
{
    private readonly OrderingSystemContext _context;

    public CookHandler(OrderingSystemContext context)
    {
        _context = context;
    }

    public Cook? GetAvailableCook()
        => _context.Cooks
        .Where(cook => _context.Orders.Count(order => order.CookId == cook.Id && order.OrderCompletionTime > DateTime.Now) < Cook.MaxWorkLoad)
        .OrderBy(cook => _context.Orders.Count(order => order.CookId == cook.Id && order.OrderCompletionTime > DateTime.Now))
        .FirstOrDefault();


    public int CalculateCookQueueEst(Cook availableCook, Dish selectedDish)
    {
        var baseTime = _context.Orders
            .Where(order => order.CookId == availableCook.Id && order.OrderCompletionTime > DateTime.Now)
            .OrderByDescending(order => order.OrderCompletionTime)
            .ToList()
            .Select(x => x.OrderCompletionTime)
            .FirstOrDefault(DateTime.Now);



        DateTime newOrderCompletionTime = baseTime.AddMinutes(selectedDish.EstTime);
        int estimatedTime = (int)(newOrderCompletionTime - DateTime.Now).TotalMinutes;
        return estimatedTime > 0 ? estimatedTime : selectedDish.EstTime;
    }
}