using System;
using System.Collections.Generic;
using Layer.Architecture.Domain.Enums;
using Layer.Architecture.Domain.Interfaces;
using Layer.Architecture.Domain.Models;

namespace Layer.Architecture.Service.RuleHandlers
{
    public class NightMultiplePotatoAllowedSideRule : AbstractRule
    {

        public NightMultiplePotatoAllowedSideRule()
        {
        }

        public override IRule ApplyRule(Order order)
        {
            order.Dishes.TryGetValue(DishType.SIDE, out int qty);
            if (qty > 0)
            {
                List<string> sideOrders = new();
                for (int i = 0; i < qty; i++)
                {
                    sideOrders.Add(FoodType.POTATO.ToString());
                }
                order.Orders.Add(DishType.SIDE, sideOrders);
            }

            return base.ApplyRule(order);
        }
    }

}
