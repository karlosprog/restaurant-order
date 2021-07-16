using System;
using Layer.Architecture.Domain.Enums;
using Layer.Architecture.Domain.Interfaces;
using Layer.Architecture.Domain.Models;
using Layer.Architecture.Service.RuleHandlers;

namespace Layer.Architecture.Service.Engines
{
    public class RuleHandlerEngine : IRuleHandlerEngineInterface
    {
        private IRule MorningRuleHandler;
        private IRule NightRuleHandler;

        public RuleHandlerEngine()
        {
            InitializeMorningRules();
            InitializeNightRules();
        }

        public void ApplyRules(Order order)
        {
            if (order.PeriodOfDay.Equals(PeriodOfDayType.MORNING))
            {
                MorningRuleHandler.ApplyRule(order);
            } else
            {
                NightRuleHandler.ApplyRule(order);
            }
        }

        private void InitializeMorningRules()
        {
            MorningRuleHandler = new MorningEntreeLimitRule(); 
            MorningRuleHandler.SetNext(new MorningSideLimitRule())              
                .SetNext(new MorningMultipleCoffeeAllowedRule())
                  .SetNext(new MorningDessertLimitRule())
                .SetNext(new InvalidDishFoundRule());
        }

        private void InitializeNightRules()
        {
            NightRuleHandler = new NightEntreeLimitRule();
            NightRuleHandler.SetNext(new NightMultiplePotatoAllowedSideRule())
                .SetNext(new NightDrinkLimitRule())
                .SetNext(new NightDessertLimitRule())
                .SetNext(new InvalidDishFoundRule());
        }
    }
}
