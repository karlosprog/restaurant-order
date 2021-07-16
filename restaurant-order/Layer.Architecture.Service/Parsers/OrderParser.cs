using System;
using System.Collections.Generic;
using System.Linq;
using Layer.Architecture.Domain.Enums;
using Layer.Architecture.Domain.Interfaces;
using Layer.Architecture.Domain.Models;
using Layer.Architecture.Service.Exceptions;

namespace Layer.Architecture.Service.Parsers
{
    public class OrderParser : IOrderParser
    {     

        public OrderParser()
        {

        }

        public Order BuildNewOrder(string paramsToBeParsed)
        {
            paramsToBeParsed = paramsToBeParsed.Replace("Input: ", "");
            Order order = new Order
            {
                RawData = paramsToBeParsed
            };
            CheckAndParseParams(order);

            return order;
        }

        private void CheckAndParseParams(Order order)
        {
            var customerOrdersList = SplitAndParse(order);
            TryToParsePeriod(order, customerOrdersList[0]);
            TryToParseDishes(order, customerOrdersList);       
        }

        private List<string> SplitAndParse(Order order)
        {
            var customerOrdersList = order.RawData.Trim().Split(',').ToList();
            if (customerOrdersList.Count == 0)
            {
                throw new ParseException("Fail trying to parse the data.");
            }
            return customerOrdersList;
        }

        private void TryToParsePeriod(Order order, String periodStr)
        {
            PeriodOfDayType periodOfDay = (PeriodOfDayType)Enum.Parse(typeof(PeriodOfDayType), periodStr.ToUpper());
            if (!Enum.IsDefined(typeof(PeriodOfDayType), periodOfDay))
            {
                throw new ParseException("Fail trying to recognize the period");
            }
            order.PeriodOfDay = periodOfDay;
        }

        private void TryToParseDishes(Order order, List<string> customerOrdersList)
        {
            DishType dishType;
            for (int i = 1; i < customerOrdersList.Count; i++)
            {
                customerOrdersList[i] = customerOrdersList[i].Trim();
                if (customerOrdersList[i].Length == 0)
                    continue;
                dishType = GetDishTypeFromIntStrCode(customerOrdersList[i]);

                if (order.Dishes.ContainsKey(dishType))
                {
                    order.Dishes[dishType] = ++order.Dishes[dishType];
                } else
                {
                    order.Dishes.Add(dishType, 1);
                }
            }
        }

        private DishType GetDishTypeFromIntStrCode(string itemCodeStr)
        {
            DishType dishType;
            if (Int32.TryParse(itemCodeStr, out int intEnumValue))
            {
                if (Enum.IsDefined(typeof(DishType), intEnumValue))
                {
                    dishType = (DishType)intEnumValue;
                }
                else
                {
                    dishType = DishType.UNKNOWN;
                }
            }
            else
            {
                throw new ParseException("Unrecognized data inputed.");
            }
            return dishType;
        }
    }
}
