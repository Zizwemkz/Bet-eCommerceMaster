//using BET_eCommerceAPI.Authentication;
using BET_eCommerceAPI.Interface;
using BET_eCommerceAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BET_eCommerceAPI.Services
{
    public class ItemService:IItemService
    {

        private readonly ApplicationDbContext _dbContext;

        public ItemService(ApplicationDbContext applicationDbContext)
        {
            _dbContext = applicationDbContext;
        }



        public async Task<int> AddItemAsync(Item itemModel)
        {
           
            var itempar = new Item
            {
                Name = itemModel.Name,
                Description = itemModel.Description,
                QuantityInStock = itemModel.QuantityInStock,
                Price = itemModel.Price,
                Picture = itemModel.Picture,
                Category_ID = itemModel.Category_ID

            };

            await _dbContext.Items.AddAsync(itempar);

            return await _dbContext.SaveChangesAsync();
        }

        public async Task<Item> GetItemAsync(int ItemId)
        {
            var result = await _dbContext.Items.FindAsync(ItemId);

            var itempar = new Item
            {
                ItemCode = result.ItemCode,
                Name = result.Name,
                Description = result.Description,
                QuantityInStock = result.QuantityInStock,
                Price = result.Price,
                Category_ID= result.Category_ID

            };

            return itempar;
        }


        public async Task<List<Item>> GetItembyCategoryIdAsync(int Category_Id)
        {
            var itempar = new List<Item>();
            var result =  _dbContext.Items.Where(x=>x.Category_ID == Category_Id).ToList();

            if (result != null)
            {
                foreach (var colitem in result)
                {
                    var itemcol = new Item
                    {
                        ItemCode = colitem.ItemCode,
                        Name = colitem.Name,
                        Description = colitem.Description,
                        QuantityInStock = colitem.QuantityInStock,
                        Price = colitem.Price,
                        Category_ID = colitem.Category_ID

                    };
                    itempar.Add(itemcol);
                }
            }
            return itempar;
        }



        public async Task<List<Item>> GetAllItemAsync()
        {
            var Itemlist =  _dbContext.Items.Where(x => x.QuantityInStock > 0).ToList();
          
            var itempar = new List<Item>();

            foreach (var colitem in Itemlist)
            {
               itempar.Add(new Item
               {
                   ItemCode = colitem.ItemCode,
                   Name = colitem.Name,
                   Description = colitem.Description,
                   QuantityInStock = colitem.QuantityInStock,
                   Price = colitem.Price,
                   Picture =  colitem.Picture,
                   Category_ID = colitem.Category_ID
               });
            }
            if (itempar.Count() == 0)
                throw new ArgumentException("No Item where found");

            return  itempar;
        }



    }
}
