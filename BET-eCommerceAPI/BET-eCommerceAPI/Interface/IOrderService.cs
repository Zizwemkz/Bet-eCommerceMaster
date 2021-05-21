using BET_eCommerceAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BET_eCommerceAPI.Interface
{
    public interface IOrderService
    {
        Task<int> AddOrderAsync(OrderModel OrderModel);
        Task<OrderModel> GetOrderAsync(string Orderid);
    }
}
