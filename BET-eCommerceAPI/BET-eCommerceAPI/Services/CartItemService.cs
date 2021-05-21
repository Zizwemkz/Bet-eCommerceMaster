using System;
using BET_eCommerceAPI.Interface;
using BET_eCommerceAPI.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BET_eCommerceAPI.Services
{
    public class CartItemService : ICartItemService
    {

        private readonly ApplicationDbContext _dbContext;

        public CartItemService(ApplicationDbContext applicationDbContext)
        {
            _dbContext = applicationDbContext;
        }





        public async Task<int> AddCartItemAsync(CartItemmodel cartItemmodel)
        {
            var CartItemPar = await _dbContext.Cart_Items.FindAsync(cartItemmodel.cart_item_id);

            if (CartItemPar != null)
                throw new ArgumentException("Item already exist"); //Add exceptions middleware

            var CartItemobj = new Cart_Item
            {
                cart_id = cartItemmodel.cart_id,
                cart_item_id = cartItemmodel.cart_item_id,
                item_id = cartItemmodel.item_id,
                quantity = cartItemmodel.quantity,
                price = cartItemmodel.price,
            };

            await _dbContext.Cart_Items.AddAsync(CartItemobj);

            return await _dbContext.SaveChangesAsync();
        }



        public async Task<CartItemmodel> GetCartItemAsync(int cart_item_id)
        {
            var result = await _dbContext.Cart_Items.FindAsync(cart_item_id);

            var Cartobj = new CartItemmodel
            {
                cart_id = result.cart_id,
                cart_item_id = result.cart_item_id,
                quantity = result.quantity,
                item_id = result.item_id,
                price = result.price,

            };

            return Cartobj;
        }

        public async Task<CartItemmodel> GetCartItemByCartIdItemIdAsync(string cartid, int ItemId)
        {
           
            var result =  _dbContext.Cart_Items.Where(x => x.cart_id == cartid && x.item_id == ItemId).FirstOrDefault();
           
               var  Cartobj = new CartItemmodel
                {
                    cart_id = result.cart_id,
                    cart_item_id = result.cart_item_id,
                    quantity = result.quantity,
                    item_id = result.item_id,
                    price = result.price,

                };
            
            return Cartobj;
        }

    }
}
