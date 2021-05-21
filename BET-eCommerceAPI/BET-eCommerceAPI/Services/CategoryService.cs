//using BET_eCommerceAPI.Authentication;
using BET_eCommerceAPI.Interface;
using BET_eCommerceAPI.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BET_eCommerceAPI.Services
{
    public class CategoryService :ICategoryService
    {

        private readonly ApplicationDbContext _dbContext;

        public CategoryService(ApplicationDbContext applicationDbContext)
        {
            _dbContext = applicationDbContext;
        }


        public async Task<int> AddOrgCategoryAsync(CategoryModel categoryModel)
        {
           
            var categoryPar = await _dbContext.Categories.FindAsync(categoryModel.Category_ID);

            if (categoryPar != null)
                throw new ArgumentException("Item already exist"); //Add exceptions middleware

            var Category = new Category
            {
                Name = categoryModel.Name,
                Department_ID = categoryModel.Department_ID
            };

            await _dbContext.Categories.AddAsync(Category);

            return await _dbContext.SaveChangesAsync();
        }

        public async Task<List<CategoryModel>> GetAllCategoriesAync()
        {
            var Categorylist = await _dbContext.Categories.ToListAsync();
            var itempar = new List<CategoryModel>();

            foreach (var item in Categorylist)
            {
                itempar.Add(new CategoryModel
                {
                    Category_ID = item.Category_ID,
                    Name = item.Name,
                    Department_ID = item.Department_ID,
                });
            }
            if (itempar.Count() == 0)
                throw new ArgumentException("No Item where found");

            return itempar;
        }


        public async Task<CategoryModel> GetcategoryByIdAsync(int categoryId)
        {
            var result = await _dbContext.Categories.FindAsync(categoryId);

            var categoryModel = new CategoryModel
            {
                Category_ID = result.Category_ID,
                Name = result.Name,
                Department_ID = result.Department_ID,
               
            };

            return categoryModel;
        }

     
    }
}
