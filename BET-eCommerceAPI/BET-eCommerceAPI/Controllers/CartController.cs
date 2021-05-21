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
    public class CartController : ControllerBase
    {
        private readonly ICartService _CartService;
        // GET: api/Category

        public CartController(ICartService CartService)
        {
            _CartService = CartService;
        }

        // GET: api/Item
        [HttpGet("{cart_id}")]
        public async Task<ActionResult<CartItemmodel>> Get(int CartId)
        {
            return Ok(await _CartService.GetByCartIdAsync(CartId));
        }



        // POST: api/Item
        [HttpPost]
        public async Task<ActionResult<int>> Post([FromBody] Cartmodel cartmodel)
        {
            return Ok(await _CartService.AddCartAsync(cartmodel));
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
