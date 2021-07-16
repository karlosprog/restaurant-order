using System;
using Layer.Architecture.Domain.Models;

namespace Layer.Architecture.Domain.Interfaces
{
    public interface IOrderService
    {
        string EvaluateOrders(String customerOrders);
    }
}
