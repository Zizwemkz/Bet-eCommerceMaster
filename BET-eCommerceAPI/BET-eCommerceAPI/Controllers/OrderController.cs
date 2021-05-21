using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BET_eCommerceAPI.Interface;
using BET_eCommerceAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BET_eCommerceAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService  _OrderService;
        // GET: api/Category

        public OrderController(IOrderService OrderService)
        {
            _OrderService = OrderService;
        }

        // GET: api/Item
        [HttpGet("{OrderID}")]
        public async Task<ActionResult<OrderModel>> Get(string OrderId)
        {
            return Ok(await _OrderService.GetOrderAsync(OrderId));
        }



        // POST: api/Item
        [HttpPost]
        public async Task<ActionResult<int>> Post([FromBody] OrderModel OrderModel)
        {
            return Ok(await _OrderService.AddOrderAsync(OrderModel));
        }


        // PUT: api/Order/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
