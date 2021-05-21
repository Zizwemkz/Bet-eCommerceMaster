using BET_eCommerceAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BET_eCommerceAPI.Interface
{
    public interface ICategoryService
    {
        Task<int> AddOrgCategoryAsync(CategoryModel categoryModel);
        Task<CategoryModel> GetcategoryByIdAsync(int categoryId); 
        Task<List<CategoryModel>> GetAllCategoriesAync();
    }
}
