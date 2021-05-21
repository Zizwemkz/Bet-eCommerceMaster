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

        [HttpPost]
        public async Task<ActionResult<Item>> Post(Item itemmodele)
        {
            return Ok(await _IItemService.AddItemAsync(itemmodele));
        }


        // GET: api/Item
        [HttpGet("{ItemCode}")]
        public async Task<ActionResult<Item>> Get(int ItemCode)
        {
            return Ok(await _IItemService.GetItemAsync(ItemCode));
        }

        [HttpGet]
        public async Task<List<Item>> Get()
        {
            return (await _IItemService.GetAllItemAsync());
        }

        // GET: api/Item
        //[HttpGet("{Category_Id}")]
        //public async Task<ActionResult<Item>> Get(int Category_Id)
        //{
        //    return Ok(await _IItemService.GetItembyCategoryIdAsync(Category_Id));
        //}



        //// PUT: api/Item/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        //// DELETE: api/ApiWithActions/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
