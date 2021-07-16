using System;
using System.Collections.Generic;
using Layer.Architecture.Domain.Enums;
using Layer.Architecture.Domain.Interfaces;
using Layer.Architecture.Domain.Models;

namespace Layer.Architecture.Service.RuleHandlers
{
    public class MorningSideLimitRule : AbstractRule
    {
        public MorningSideLimitRule()
        {
        }

        public override IRule ApplyRule(Order order)
        {
            order.Dishes.TryGetValue(DishType.SIDE, out int qty);
            if (qty > 1)
            {
                order.ErrorFound = "you can only order 1 of side";
                return null;
            }
            else
            {
                List<string> entrees = new();
                entrees.Add(FoodType.TOAST.ToString());
                order.Orders.Add(DishType.SIDE, entrees);
                return base.ApplyRule(order);
            }
        }
    }
}
