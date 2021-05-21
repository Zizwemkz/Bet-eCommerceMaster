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
    public class OrderItemController : ControllerBase
    {

        private readonly IOrderItemService _OrderItemServiceService;
        // GET: api/Category

        public OrderItemController(IOrderItemService OrderItemServiceService)
        {
            _OrderItemServiceService = OrderItemServiceService;
        }



        // POST: api/Item
        [HttpPost]
        public async Task<ActionResult<int>> Post([FromBody] OrderItemModel orderItemModel)
        {
            return Ok(await _OrderItemServiceService.AddOrderItemAsync(orderItemModel));
        }

        [HttpPost]
        public async Task<ActionResult<int>> Post([FromBody] List<OrderItemModel> orderItemModel)
        {
            return Ok(await _OrderItemServiceService.AddItemsToOrderAsync(orderItemModel));
        }


        // GET: api/Item
        [HttpGet("{OrderItemId}")]
        public async Task<ActionResult<OrderItemModel>> Get(int OrderItemId)
        {
            return Ok(await _OrderItemServiceService.GetOrderItemAsync(OrderItemId));
        }


        // GET: api/OrderItem
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }


        // PUT: api/OrderItem/5
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
