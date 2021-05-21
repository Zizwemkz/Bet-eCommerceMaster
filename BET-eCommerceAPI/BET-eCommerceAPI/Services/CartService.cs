using System;
using BET_eCommerceAPI.Interface;
using BET_eCommerceAPI.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace BET_eCommerceAPI.Services
{
    public class CartService : ICartService
    {

        private readonly ApplicationDbContext _dbContext;

        public CartService(ApplicationDbContext applicationDbContext)
        {
            _dbContext = applicationDbContext;
        }


    
        public async Task<int> AddCartAsync(Cartmodel cartmodel)
        {
            //string user = await _dbContext.Carts.FindAsync(Username);
            var CartPar = await _dbContext.Carts.FindAsync();


            //var item = await _dbContext.Items.FindAsync(itemmodel.ItemId);
            //if (item != null)
            //{
                //var cartItem = dataContext.Cart_Items.FirstOrDefault(x => x.cart_id == shoppingCartID && x.item_id == item.ItemCode);
                //        if (cartItem == null)
                //        {
                //            var cart = dataContext.Carts.Find(shoppingCartID);
                //            if (cart == null)

                // if (CartPar != null)
                // throw new ArgumentException("Item already exist"); //Add exceptions middleware  
                var cartobj = new Cart
              {
                cart_id = cartmodel.cart_id,
                date_created = cartmodel.date_created,
              };


            //await _dbContext.Carts.AddAsync(cartobj);
            //}
            return await _dbContext.SaveChangesAsync();
        }


        public async Task<double> GetCarttotal(string cartId)
        {
            double amount = 0;
            var item = await _dbContext.Cart_Items.Where(x=>x.cart_id == cartId).ToListAsync();
            foreach (var eachitem in item)
            {
                amount += (eachitem.price * eachitem.quantity);
            }
            return amount;
        }


        //public void AddItemToCart(int id)
        //{
        //    shoppingCartID = GetCartID();

        //    var item = dataContext.Items.Find(id);

        //    if (item != null)
        //    {
        //        var cartItem = dataContext.Cart_Items.FirstOrDefault(x => x.cart_id == shoppingCartID && x.item_id == item.ItemCode);
        //        if (cartItem == null)
        //        {
        //            var cart = dataContext.Carts.Find(shoppingCartID);
        //            if (cart == null)
        //            {
        //                dataContext.Carts.Add(entity: new Cart()
        //                {
        //                    cart_id = shoppingCartID,
        //                    date_created = DateTime.Now
        //                });
        //                dataContext.SaveChanges();
        //            }

        //            dataContext.Cart_Items.Add(entity: new Cart_Item()
        //            {
        //                cart_item_id = Guid.NewGuid().ToString(),
        //                cart_id = shoppingCartID,
        //                item_id = item.ItemCode,
        //                quantity = 1,
        //                price = item.Price
        //            }
        //                );
        //        }
        //        else
        //        {
        //            cartItem.quantity++;
        //        }
        //        dataContext.SaveChanges();
        //    }
        //}


        public async Task<int> DeleteCart(Cartmodel cartmodel)
        {
            var item = await _dbContext.Cart_Items.FindAsync(cartmodel.cart_id);

            if (item != null)
            {
                _dbContext.Cart_Items.Remove(item);
            }

            _dbContext.Carts.Remove(_dbContext.Carts.Find(cartmodel.cart_id));
            return await _dbContext.SaveChangesAsync(); 
        }


        public async Task<Cartmodel> GetByCartIdAsync(int cart_id)
        {
            var result = await _dbContext.Carts.FindAsync(cart_id);

            var Cartobj = new Cartmodel
            {
                cart_id = result.cart_id,
                date_created = result.date_created,

            };

            return Cartobj;
        }




        //public async Task<int> UpdateStudentAsync(applicationuser applicationuser)
        //{
        //    var result = await _dbContext.TbStudent.FindAsync(applicationuser.StudentId);

        //    result.FirstName = applicationuser.FirstName;
        //    result.LastName = applicationuser.LastName;
        //    result.ParentCellNumber = applicationuser.ParentPhoneNumber;
        //    result.ParentEmail = applicationuser.ParentEmail;
        //    result.Grade = applicationuser.Grade;
        //    result.ClassId = applicationuser.classId;

        //    _dbContext.Update(result);
        //    return await _dbContext.SaveChangesAsync();
        //}

    }
}
