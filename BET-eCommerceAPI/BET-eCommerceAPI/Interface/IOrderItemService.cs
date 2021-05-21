using BET_eCommerceAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BET_eCommerceAPI.Interface
{
    public interface IOrderItemService
    {
        Task<int> AddOrderItemAsync(OrderItemModel ItemModel);
        Task<int> AddItemsToOrderAsync(List<OrderItemModel> ItemModel);
        Task<OrderItemModel> GetOrderItemAsync(int OrderItemId);
    }
}
