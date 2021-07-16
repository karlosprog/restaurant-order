using Layer.Architecture.Domain.Models;

namespace Layer.Architecture.Domain.Interfaces
{
    public interface IRule
    {
        IRule ApplyRule(Order order);
        IRule SetNext(IRule rule);
    }
}
