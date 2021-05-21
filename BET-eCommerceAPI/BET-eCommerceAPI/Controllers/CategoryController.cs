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
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _CategoryService;
        // GET: api/Category

        public CategoryController(ICategoryService CategoryService)
        {
            _CategoryService = CategoryService;
        }

        // GET: api/Item
        [HttpGet("{CategoryId}")]
        public async Task<ActionResult<CategoryModel>> Get(int CategoryId)
        {
            return Ok(await _CategoryService.GetcategoryByIdAsync(CategoryId));
        }

        [HttpGet]
        public async Task<ActionResult<CategoryModel>> Get()
        {
            return Ok(await _CategoryService.GetAllCategoriesAync());
        }




        // POST: api/Item
        [HttpPost]
        public async Task<ActionResult<int>> Post([FromBody] CategoryModel CategoryModel)
        {
            return Ok(await _CategoryService.AddOrgCategoryAsync(CategoryModel));
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
