using BET_eCommerceAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BET_eCommerceAPI.Services
{
    public class OrderService
    {
        private readonly ApplicationDbContext _dbContext;

        public OrderService(ApplicationDbContext applicationDbContext)
        {
            _dbContext = applicationDbContext;
        }



        public async Task<int> AddOrderAsync(OrderModel ordermodel)
        {
            var OrderClass = await _dbContext.TbOrder.FindAsync(ordermodel.Order_ID);

            if (OrderClass == null)
                throw new ArgumentException("Invalid Class Id"); //Add exceptions middleware

            var Orderpar = new TbOrder
            {
                Order_ID = ordermodel.Order_ID,
                userName = ordermodel.userName,
                Total = ordermodel.Total,
                shippedStatus = ordermodel.shippedStatus,
                createddate = ordermodel.createddate
            };

            await _dbContext.TbOrder.AddAsync(Orderpar);

            return await _dbContext.SaveChangesAsync();
        }




        public async Task<OrderModel> GetOrderAsync(int OrderId)
        {
            var result = await _dbContext.TbOrder.FindAsync(OrderId);

            var ordermodel = new OrderModel
            {
                Order_ID = result.Order_ID,
                userName = result.userName,
                Total = result.Total,
                shippedStatus = result.shippedStatus,
                createddate = result.createddate

            };

            return ordermodel;
        }

    }
}
