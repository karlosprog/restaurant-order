using System;
using Layer.Architecture.Domain.Interfaces;
using NUnit.Framework;

namespace Layer.Architecture.Service.UnitTests
{
    public class OrderServiceTest
    {
        private readonly IOrderService _orderService;

        public OrderServiceTest(IOrderService orderService)
        {
            this._orderService = orderService;
        }

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void OrderServiceMustHandleRepeatedCoffee()
        {
            string resultValue = _orderService.EvaluateOrders("Input: morning, 1, 2, 3, 3, 3");
            Assert.AreEqual(resultValue, "Output: eggs, toast, coffee(x3)");
        }

        [Test]
        public void OrderServiceMustHandleRepeatedCoffeeAndPrintError()
        {
            string resultValue =_orderService.EvaluateOrders("Input: night, 1, 2, 2, 2, 2, 2, 2, 2, 2, 2, 3, 5");
            Assert.AreEqual(resultValue, "Output: steak, potato(x9), wine, error");
        }

        [Test]
        public void OrderServiceMustHandleRepeatedPotatoes()
        {
            string resultValue = _orderService.EvaluateOrders("Input: night, 1, 2, 2, 2, 2, 2, 2, 2, 2, 2, 3, 4");
            Assert.AreEqual(resultValue, "Output: steak, potato(x9), wine, cake");
        }


        [Test]
        public void OrderServiceMustPrintErrorWhenHandlingWrongInput()
        {
            string resultValue = _orderService.EvaluateOrders("Input: morning, 1, 2, 5");
            Assert.AreEqual(resultValue, "Output: eggs, toast, error");
        }


        [Test]
        public void OrderServiceMustFailWhenHandlingUnknowCharException()
        {
            Assert.Throws<Exceptions.ParseException>(() => _orderService.EvaluateOrders("Input: morning, 1, 2, 5?"));
        }
    }
}

