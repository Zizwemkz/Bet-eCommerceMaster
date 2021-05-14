using BET_eCommerceAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BET_eCommerceAPI.Interface
{
    public interface IItemService
    {
        Task<int> AddItemAsync(ItemModel ItemModel);
        Task<ItemModel> GetItemAsync(int ItemId);
    }
}
