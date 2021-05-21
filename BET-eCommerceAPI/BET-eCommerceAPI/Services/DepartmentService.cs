using System;
using BET_eCommerceAPI.Interface;
using BET_eCommerceAPI.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace BET_eCommerceAPI.Services
{
    public class DepartmentService : IDepartmentService
    {

        private readonly ApplicationDbContext _dbContext;

        public DepartmentService(ApplicationDbContext applicationDbContext)
        {
            _dbContext = applicationDbContext;
        }



        public async Task<int> AddDepartmentAsync(Departmentmodel departmentmodel)
        {

            var Depart = new Department
            {
                Department_ID = departmentmodel.Department_ID,
                Department_Name = departmentmodel.Department_Name,
                Description = departmentmodel.Description,
            };

            await _dbContext.Departments.AddAsync(Depart);

            return await _dbContext.SaveChangesAsync();
        }



        public async Task<Departmentmodel> GetDepartmentByIdAsync(int DepartmentId)
        {
            var result = await _dbContext.Departments.FindAsync(DepartmentId);

            var Departpar = new Departmentmodel
            {
                Department_ID = result.Department_ID,
                Department_Name = result.Department_Name,
                Description = result.Description
            };

            return Departpar;
        }


        public async Task<List<Departmentmodel>> GetAllDepartmentAsync()
        {
            var Itemlist = await _dbContext.Departments.ToListAsync();
            var itempar = new List<Departmentmodel>();

            foreach (var item in Itemlist)
            {
                itempar.Add(new Departmentmodel
                {
                    Department_ID = item.Department_ID,
                    Department_Name = item.Department_Name,
                    Description = item.Description,
                });
            }
            if (itempar.Count() == 0)
                throw new ArgumentException("No Item where found");

            return itempar;
        }

    }
}
