using System;
using Layer.Architecture.Domain.Enums;
using Layer.Architecture.Domain.Interfaces;
using Layer.Architecture.Domain.Models;

namespace Layer.Architecture.Service.RuleHandlers
{
    public class MorningDessertLimitRule : AbstractRule
    {
        public MorningDessertLimitRule()
        {
        }

        public override IRule ApplyRule(Order order)
        {
            order.Dishes.TryGetValue(DishType.DESSERT, out int qty);
            if (qty > 0)
            {
                order.ErrorFound = "There is no dessert for morning meals";
                return null;
            }
            else
            {
                return base.ApplyRule(order);
            }
        }
    }
}
