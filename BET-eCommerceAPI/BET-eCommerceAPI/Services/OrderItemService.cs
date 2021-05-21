//using BET_eCommerceAPI.Authentication;
using BET_eCommerceAPI.Interface;
using BET_eCommerceAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BET_eCommerceAPI.Services
{
    public class OrderItemService: IOrderItemService
    {
        private readonly ApplicationDbContext _dbContext;

        public OrderItemService(ApplicationDbContext applicationDbContext)
        {
            _dbContext = applicationDbContext;
        }

        public async Task<int> AddOrderItemAsync(OrderItemModel orderItemmodel)
        {
            var OrderItem = await _dbContext.TbOrder_item.FindAsync(orderItemmodel.OrderItemId);
            if (OrderItem != null)
                throw new ArgumentException("Invalid Class Id"); //Add exceptions middleware

            var OrderItempar = new TbOrder_Item
            {
                Id = orderItemmodel.Id,
                OrderItemId = orderItemmodel.OrderItemId,
                Quantity = orderItemmodel.Quatity,
                ItemId = orderItemmodel.itemId
            };

            await _dbContext.TbOrder_item.AddAsync(OrderItempar);

            return await _dbContext.SaveChangesAsync();
        }


        public async Task<int> AddItemsToOrderAsync(List<OrderItemModel> ordermodel)
        {
            foreach (var ItemOrderpar in ordermodel)
            {
                await AddItems(ItemOrderpar);
            }

            return await _dbContext.SaveChangesAsync();
        }

        public async Task<OrderItemModel> GetOrderItemAsync(int OrderItemId)
        {
            var result = await _dbContext.TbOrder_item.FindAsync(OrderItemId);

            var ordermodel = new OrderItemModel
            {
                OrderItemId = result.OrderItemId,
                Quatity = result.Quantity,
                itemId = result.ItemId
            };

            return ordermodel;
        }

        private async Task AddItems(OrderItemModel ordermodel)
        {
            var orderpar = await _dbContext.TbOrder_item.FindAsync(ordermodel.Id);

            await _dbContext.AddAsync(new TbOrder_Item
            {
                OrderItemId = ordermodel.OrderItemId,
                Quantity = ordermodel.Quatity,
                ItemId = ordermodel.itemId
            });
        }


    }
}
