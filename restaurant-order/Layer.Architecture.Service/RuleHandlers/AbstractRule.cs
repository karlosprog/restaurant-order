using System;
using Layer.Architecture.Domain.Enums;
using Layer.Architecture.Domain.Interfaces;
using Layer.Architecture.Domain.Models;

namespace Layer.Architecture.Service.RuleHandlers
{

    public abstract class AbstractRule : IRule
    {
        protected PeriodOfDayType PeriodOfDayType { get; set; }
        private IRule _nextRule;

        public IRule SetNext(IRule rule)
        {
            this._nextRule = rule;
            return rule;
        }

        public virtual IRule ApplyRule(Order order)
        {
            if (this._nextRule != null)
            {
                return this._nextRule.ApplyRule(order);
            }
            else
            {
                return null;
            }            
        }
    }
}
