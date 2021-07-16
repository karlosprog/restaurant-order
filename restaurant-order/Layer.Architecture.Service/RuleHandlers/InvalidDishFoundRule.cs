using System;
using Layer.Architecture.Domain.Enums;
using Layer.Architecture.Domain.Interfaces;
using Layer.Architecture.Domain.Models;

namespace Layer.Architecture.Service.RuleHandlers
{
    public class InvalidDishFoundRule : AbstractRule
    {
        public InvalidDishFoundRule()
        {
        }

        public override IRule ApplyRule(Order order)
        {
            if (order.Dishes.ContainsKey(DishType.UNKNOWN))
            {
                order.ErrorFound = "Invalid dish";
                return null;
            }
            else
            {
                return base.ApplyRule(order);
            }
        }
    }
}
