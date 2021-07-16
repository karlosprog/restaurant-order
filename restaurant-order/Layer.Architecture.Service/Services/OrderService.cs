using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Layer.Architecture.Domain.Enums;
using Layer.Architecture.Domain.Interfaces;
using Layer.Architecture.Domain.Models;
using Layer.Architecture.Service.Exceptions;

namespace Layer.Architecture.Service.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderParser _orderParser;
        private readonly IRuleHandlerEngineInterface _ruleHandlerEngineInterface;

        public OrderService(IOrderParser orderParser, IRuleHandlerEngineInterface ruleHandlerEngineInterface)
        {
            this._orderParser = orderParser;
            this._ruleHandlerEngineInterface = ruleHandlerEngineInterface;
        }

        private void ApplyRules(Order order)
        {
            _ruleHandlerEngineInterface.ApplyRules(order);
        }

        public string EvaluateOrders(string customerOrders)
        {
            Order order = _orderParser.BuildNewOrder(customerOrders);
            ApplyRules(order);
            return BuildOutputStr(order);
        }

        private string BuildOutputStr(Order order)
        {
            StringBuilder outputStr = new StringBuilder();

            outputStr.Append("Output: ");

            String prefix = "";
            foreach (var item in order.Orders)
            {
                outputStr.Append(prefix);
                prefix = ", ";

                outputStr.Append(item.Value[0].ToLower());
                if (item.Value.Count() > 1)
                {
                    outputStr.Append(string.Format("(x{0})", item.Value.Count()));
                }
            }

            if (!string.IsNullOrWhiteSpace(order.ErrorFound))
            {
                outputStr.Append(prefix);
                outputStr.Append("error");
            }

            return outputStr.ToString();
        }
    }
}
