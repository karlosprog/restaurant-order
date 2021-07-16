using System;
using System.Collections.Generic;
using Layer.Architecture.Domain.Enums;
using Layer.Architecture.Domain.Interfaces;

namespace Layer.Architecture.Domain.Models
{
    public class Order : IOrder
    {
        public PeriodOfDayType PeriodOfDay { get; set; }
        public Dictionary<DishType, int> Dishes { get; set; }
        public Dictionary<DishType, List<string>> Orders { get; set; }
        public string ErrorFound { get; set; }
        public String RawData { get; set; }

        public Order()
        {
            this.Dishes = new();
            this.Orders = new();
            this.RawData = String.Empty;
        }

        public void ParseOrders(string orders)
        {
            throw new NotImplementedException();
        }
    }
}
