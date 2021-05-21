using BET_eCommerceAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BET_eCommerceAPI.Interface
{
    public interface IItemService
    {
        Task<int> AddItemAsync(Item ItemModel);
        Task<Item> GetItemAsync(int ItemId);
        Task<List<Item>> GetAllItemAsync();
        Task<List<Item>> GetItembyCategoryIdAsync(int Category_Id);
        
    }
}
