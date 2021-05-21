//using BET_eCommerceAPI.Authentication;
using BET_eCommerceAPI.Interface;
using BET_eCommerceAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BET_eCommerceAPI.Services
{
    public class OrderService : IOrderService
    {
        private readonly ApplicationDbContext _dbContext;

        public OrderService(ApplicationDbContext applicationDbContext)
        {
            _dbContext = applicationDbContext;
        }



        public async Task<int> AddOrderAsync(OrderModel ordermodel)
        {
            var findOrder = await _dbContext.TbOrder.FindAsync(ordermodel.OrderID);

            if (findOrder != null)
                throw new ArgumentException("Order Already in the database"); //Add exceptions middleware

            var Orderpar = new TbOrder
            {
                OrderID = ordermodel.OrderID,
                userName = ordermodel.userName,
                Total = ordermodel.Total,
                ShippedStatus = ordermodel.shippedStatus,
                Createddate = DateTime.Now,
                OrderitemId = ordermodel.OrderitemId
            };

            await _dbContext.TbOrder.AddAsync(Orderpar);

            return await _dbContext.SaveChangesAsync();
        }

        public async Task<OrderModel> GetOrderAsync(string OrderId)
        {
            var ordermodel = new OrderModel();
            var result = await _dbContext.TbOrder.FindAsync(OrderId);
            if (result != null)
            {
                ordermodel = new OrderModel
                {
                    OrderID = result.OrderID,
                    userName = result.userName,
                    Total = result.Total,
                    shippedStatus = result.ShippedStatus,
                    createddate = result.Createddate,
                    OrderitemId = result.OrderitemId
                };
            }
            else
            {
                throw new ArgumentException("The is No order for the sent request");
            }
            return ordermodel;
        }
    }
}
