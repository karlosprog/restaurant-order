using System;
using System.Collections.Generic;
using Layer.Architecture.Domain.Enums;
using Layer.Architecture.Domain.Interfaces;
using Layer.Architecture.Domain.Models;

namespace Layer.Architecture.Service.RuleHandlers
{
    public class NightDrinkLimitRule : AbstractRule
    {
        public NightDrinkLimitRule()
        {
        }

        public override IRule ApplyRule(Order order)
        {
            order.Dishes.TryGetValue(DishType.DRINK, out int qty);
            if (qty > 1)
            {
                order.ErrorFound = "you can only order 1 of drink";
                return null;
            }
            else
            {
                if (qty != 0)
                {
                    List<string> drinks = new();
                    drinks.Add(FoodType.WINE.ToString());
                    order.Orders.Add(DishType.DRINK, drinks);
                }
                return base.ApplyRule(order);
            }
        }
    }
}
