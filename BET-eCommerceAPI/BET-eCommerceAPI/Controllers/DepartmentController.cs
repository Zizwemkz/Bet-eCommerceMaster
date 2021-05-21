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
    public class DepartmentController : ControllerBase
    {
        private readonly IDepartmentService _DepartmentService;
        // GET: api/Category

        public DepartmentController(IDepartmentService DepartmentService)
        {
            _DepartmentService = DepartmentService;
        }

        // GET: api/Item
        [HttpGet("{Departmentid}")]
        public async Task<ActionResult<Departmentmodel>> Get(int Departmentid)
        {
            return Ok(await _DepartmentService.GetDepartmentByIdAsync(Departmentid));
        }


        // GET: api/Item
        [HttpGet()]
        public async Task<List<Departmentmodel>> Get()
        {
            return (await _DepartmentService.GetAllDepartmentAsync());
        }


        // POST: api/Item
        [HttpPost]
        public async Task<ActionResult<int>> Post([FromBody] Departmentmodel departmentmodel)
        {
            return Ok(await _DepartmentService.AddDepartmentAsync(departmentmodel));
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
