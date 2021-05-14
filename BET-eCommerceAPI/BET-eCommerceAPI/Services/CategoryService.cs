using BET_eCommerceAPI.Interface;
using BET_eCommerceAPI.Models;
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



        public async Task<int> AddCategoryAsync(CategoryModel categoryModel)
        {
            var studentClass = await _dbContext.TbCategory.FindAsync(categoryModel.CategoryId);

            if (studentClass == null)
                throw new ArgumentException("Invalid category Id"); //Add exceptions middleware

            var Category = new TbCategory
            {
                CategoryID = categoryModel.CategoryId,
                Name = categoryModel.Name,
                Description = categoryModel.Description
            };

            await _dbContext.TbCategory.AddAsync(Category);

            return await _dbContext.SaveChangesAsync();
        }




        public async Task<CategoryModel> GetcategoryAsync(int categoryId)
        {
            var result = await _dbContext.TbCategory.FindAsync(categoryId);

            var categoryModel = new CategoryModel
            {
                CategoryId = result.CategoryID,
                Name = result.Name,
                Description = result.Description,
               
            };

            return categoryModel;
        }

     
    }
}
