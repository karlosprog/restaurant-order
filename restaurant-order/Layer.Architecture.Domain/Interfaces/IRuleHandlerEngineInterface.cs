using System;
using Layer.Architecture.Domain.Models;

namespace Layer.Architecture.Domain.Interfaces
{
    public interface IRuleHandlerEngineInterface
    {
        void ApplyRules(Order order);
    }
}
