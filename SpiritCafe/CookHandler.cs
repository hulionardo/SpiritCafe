using SpiritCafe.Data;
using SpiritCafe.Entities;
using System;
using System.Linq;

namespace SpiritCafe;
   public class CookHandler
{
    private readonly OrderingSystemContext _context;

    public CookHandler(OrderingSystemContext context)
    {
        _context = context;
    }

    public Cook GetAvailableCook()
    {
        var cooks = _context.Cooks.ToList();

        foreach (var cook in cooks)
        {

            var pendingOrders = _context.Orders.Count(order => order.CookId == cook.Id && order.OrderCompletionTime > DateTime.Now);
            cook.CurrentWorkload = pendingOrders;
            cook.IsAvailable = cook.CurrentWorkload < Cook.s_maxWorkLoad;
        }

        return cooks.Where(cook => cook.IsAvailable).OrderBy(cook => cook.CurrentWorkload).FirstOrDefault();
    }

    public int CalculateCookQueueEst(Cook availableCook, Dish selectedDish)
    {
        var pendingOrders = _context.Orders
            .Where(order => order.CookId == availableCook.Id && order.OrderCompletionTime > DateTime.Now)
            .OrderByDescending(order => order.OrderCompletionTime)
            .ToList();

        DateTime baseTime;

        if (!pendingOrders.Any()) baseTime = DateTime.Now;
        else baseTime = pendingOrders.First().OrderCompletionTime.Value;

        DateTime newOrderCompletionTime = baseTime.AddMinutes(selectedDish.EstTime);
        int estimatedTime = (int)(newOrderCompletionTime - DateTime.Now).TotalMinutes;
        return estimatedTime > 0 ? estimatedTime : selectedDish.EstTime;
    }





}

