using System;
using System.Collections.Generic;
using Layer.Architecture.Domain.Enums;
using Layer.Architecture.Domain.Interfaces;
using Layer.Architecture.Domain.Models;

namespace Layer.Architecture.Service.RuleHandlers
{
    public class NightDessertLimitRule : AbstractRule
    {
        public NightDessertLimitRule()
        {
        }

        public override IRule ApplyRule(Order order)
        {
            order.Dishes.TryGetValue(DishType.DESSERT, out int qty);
            if (qty > 1)
            {
                order.ErrorFound = "you can only order 1 of dessert";
                return null;
            }
            else
            {
                if (qty != 0)
                { 
                    List<string> entrees = new();
                    entrees.Add(FoodType.CAKE.ToString());
                    order.Orders.Add(DishType.DESSERT, entrees);
                }
                return base.ApplyRule(order);
            }
        }
    }
}
