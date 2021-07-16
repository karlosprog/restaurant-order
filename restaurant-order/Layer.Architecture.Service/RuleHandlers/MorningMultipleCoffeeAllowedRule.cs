using System;
using System.Collections.Generic;
using Layer.Architecture.Domain.Enums;
using Layer.Architecture.Domain.Interfaces;
using Layer.Architecture.Domain.Models;

namespace Layer.Architecture.Service.RuleHandlers
{
    public class MorningMultipleCoffeeAllowedRule : AbstractRule
    {

        public MorningMultipleCoffeeAllowedRule()
        {
        }

        public override IRule ApplyRule(Order order)
        {
            order.Dishes.TryGetValue(DishType.DRINK, out int qty);
            if (qty > 0)
            {
                List<string> coffeeDrinks = new();
                for (int i=0; i < qty; i++)
                {
                    coffeeDrinks.Add(FoodType.COFFEE.ToString());
                }
                order.Orders.Add(DishType.DRINK, coffeeDrinks);
            }

            return base.ApplyRule(order);
        }
    }

}
