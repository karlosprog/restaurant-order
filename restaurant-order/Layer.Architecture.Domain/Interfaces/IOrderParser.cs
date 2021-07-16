using System;
using Layer.Architecture.Domain.Models;

namespace Layer.Architecture.Domain.Interfaces
{
    public interface IOrderParser
    {
        Order BuildNewOrder(string paramsToBeParsed); 
    }
}
