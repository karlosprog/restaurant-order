using System;
using System.Collections.Generic;
using Layer.Architecture.Domain.Enums;
using Layer.Architecture.Domain.Interfaces;
using Layer.Architecture.Domain.Models;

namespace Layer.Architecture.Service.RuleHandlers
{
    public class MorningEntreeLimitRule : AbstractRule
    {
        public MorningEntreeLimitRule()
        {
        }

        public override IRule ApplyRule(Order order)
        {
            List<string> entrees = new();
            entrees.Add(FoodType.EGGS.ToString());
            order.Orders.Add(DishType.ENTREE, entrees);

            order.Dishes.TryGetValue(DishType.ENTREE, out int qty);
            if (qty > 1)
            {
                order.ErrorFound = "you can only order 1 of entree";
                return null;
            }
            else
            {                
                return base.ApplyRule(order);
            }
        }
    }
}
