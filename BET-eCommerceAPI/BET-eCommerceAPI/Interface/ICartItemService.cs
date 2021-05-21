using System;
using System.Collections.Generic;
using BET_eCommerceAPI.Models;
using System.Linq;
using System.Threading.Tasks;

namespace BET_eCommerceAPI.Interface
{
    public interface ICartItemService
    {
        Task<int> AddCartItemAsync(CartItemmodel Model);
        Task<CartItemmodel> GetCartItemAsync(int cartId); 
        Task<CartItemmodel> GetCartItemByCartIdItemIdAsync(string cartId, int itemId);
    }
}
