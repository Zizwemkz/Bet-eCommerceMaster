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



        public async Task<int> AddItemAsync(ItemModel itemModel)
        {
             itemModel.ItemId = Guid.NewGuid();
             var ItemPar = await _dbContext.TbItem.FindAsync(itemModel.ItemId);

            if (ItemPar != null)
                throw new ArgumentException("Item already exist"); //Add exceptions middleware

            var Item = new TbItem
            {
                ItemId = itemModel.ItemId,
                Name = itemModel.Name,
                Description = itemModel.Description,
                Quantity  = itemModel.QuantityInStock,
                Price = itemModel.Price
            };

            await _dbContext.TbItem.AddAsync(Item);

            return await _dbContext.SaveChangesAsync();
        }



        public async Task<ItemModel> GetItemAsync(int ItemId)
        {
            var result = await _dbContext.TbItem.FindAsync(ItemId);

            var itempar = new ItemModel
            {
                ItemId = result.ItemId,
                Name = result.Name,
                Description = result.Description,
                QuantityInStock = result.Quantity,
                Price = result.Price

            };

            return itempar;
        }


    }
}
