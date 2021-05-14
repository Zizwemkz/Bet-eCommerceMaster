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
    public class ItemController : ControllerBase
    {

        private readonly IItemService _IItemService;


        public ItemController(IItemService ItemService)
        {
            _IItemService = ItemService;
        }
        
        // GET: api/Item
        [HttpGet]
        public async Task<ActionResult<ItemModel>> Get(int itemId)
        {
            return Ok(await _IItemService.GetItemAsync(itemId));
        }



        // POST: api/Item
        [HttpPost]
        public async Task<ActionResult<int>> Post([FromBody] ItemModel itemModel)
        {
            return Ok(await _IItemService.AddItemAsync(itemModel));
        }


        // PUT: api/Item/5
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
