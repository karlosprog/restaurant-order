using Layer.Architecture.Application.Models;
using Layer.Architecture.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Layer.Architecture.Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _baseOrderService;

        public OrderController(IOrderService baseOrderService)
        {
            _baseOrderService = baseOrderService;
        }

        [HttpPost]
        public IActionResult ProcessOrder([FromBody] String order)
        {
            if (order == null )
                return NotFound();

            return Execute(() => _baseOrderService.EvaluateOrders(order));
        }


        [HttpGet]
        public IActionResult Get()
        {
            return Execute(() => _baseOrderService.EvaluateOrders("morning, 1, 2, 3, 3, 3"));
        }

        private IActionResult Execute(Func<object> func)
        {
            try
            {
                var result = func();

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}
