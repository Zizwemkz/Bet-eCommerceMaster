using System;
using System.Collections.Generic;
using BET_eCommerceAPI.Models;
using System.Linq;
using System.Threading.Tasks;

namespace BET_eCommerceAPI.Interface
{
    public interface ICartService
    {
        Task<int> AddCartAsync(Cartmodel categoryModel);
        Task<Cartmodel> GetByCartIdAsync(int categoryId);
    }
}
