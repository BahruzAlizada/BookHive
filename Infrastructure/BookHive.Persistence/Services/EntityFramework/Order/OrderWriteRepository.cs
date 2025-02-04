using BookHive.Application.Abstracts.ServiceContracts;
using BookHive.Application.Abstracts.Services.EntityFramework;
using BookHive.Application.DTOs;
using BookHive.Domain.Entities;
using BookHive.Domain.Identity;
using BookHive.Persistence.Concrete;
using BookHive.Persistence.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace BookHive.Persistence.Services.EntityFramework
{
    public class OrderWriteRepository : WriteRepository<Order>, IOrderWriteRepository
    {
        private readonly Context context;
        private readonly UserManager<AppUser> userManager;
        private readonly IOrderService orderService;
        public OrderWriteRepository(Context context, UserManager<AppUser> userManager, IOrderService orderService) : base(context)
        {
            this.context = context;
            this.userManager = userManager;
            this.orderService = orderService;
        }

       


        public async Task CreateOrder()
        {
            Basket? basket = await orderService.GetUserActiveBasket();
            if (basket == null)
                throw new Exception("Basket Not Found");

            var orderCode = (new Random().NextDouble() * 10000).ToString();
            orderCode = orderCode.Substring(orderCode.IndexOf(".") + 1, orderCode.Length - orderCode.IndexOf(".") - 1);

            Order order = new Order
            {
                BasketId = basket.Id,
                TotalPrice = basket.TotalPrice,
                IsCompleted = true,
                OrderCode = orderCode,
            };

            await context.Orders.AddAsync(order);

            basket.IsCompleted = true;
            context.Baskets.Update(basket);

            await context.SaveChangesAsync();
        }
    }
}
