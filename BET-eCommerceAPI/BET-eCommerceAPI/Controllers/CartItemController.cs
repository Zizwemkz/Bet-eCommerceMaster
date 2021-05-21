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
    public class CartItemController : ControllerBase
    {
        private readonly ICartItemService _CartItemService;
        // GET: api/Category

        public CartItemController(ICartItemService CartItemService)
        {
            _CartItemService = CartItemService;
        }

        // GET: api/Item
        [HttpGet("{cart_item_id}")]
        public async Task<ActionResult<CartItemmodel>> Get(int CartItemId)
        {
            return Ok(await _CartItemService.GetCartItemAsync(CartItemId));
        }


        // GET: api/Item
        [HttpGet]
        public async Task<ActionResult<CartItemmodel>> Get(string CartId,int ItemId)
        {
            return Ok(await _CartItemService.GetCartItemByCartIdItemIdAsync(CartId,ItemId));
        }



        // POST: api/Item
        [HttpPost]
        public async Task<ActionResult<int>> Post([FromBody] CartItemmodel CartItemmodel)
        {
            return Ok(await _CartItemService.AddCartItemAsync(CartItemmodel));
        }



        // PUT: api/Category/5
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
