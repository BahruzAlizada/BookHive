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
        public OrderWriteRepository(Context context, UserManager<AppUser> userManager) : base(context)
        {
            this.context = context;
            this.userManager = userManager;
        }

        private async Task<Basket> GetUserActiveBasket()
        {
            //string username = httpContextAccessor.HttpContext.User.Identity.Name;
            string username = "bahruzalizada";
            if (string.IsNullOrEmpty(username))
                throw new Exception("An error occured");

            AppUser? user = await userManager.FindByNameAsync(username);
            if (user == null)
                throw new Exception("User is not authenticated.");

            Basket? basket = await context.Baskets.FirstOrDefaultAsync(x => x.UserId == user.Id && !x.IsCompleted);
            if (basket == null)
                throw new Exception("An error occured");

            return basket;
        }


        public async Task CreateOrder()
        {
            Basket? basket = await GetUserActiveBasket();
            if (basket == null)
                throw new Exception("Basket Not Found");

            var orderCode = (new Random().NextDouble() * 10000).ToString();
            orderCode = orderCode.Substring(orderCode.IndexOf(".") + 1, orderCode.Length - orderCode.IndexOf(".") - 1);

            Order order = new Order
            {
                BasketId = basket.Id,
                TotalPrice = basket.TotalPrice,
                IsCompleted = false,
                OrderCode = orderCode,
            };

            await context.Orders.AddAsync(order);

            basket.IsCompleted = true;
            context.Baskets.Update(basket);

            await context.SaveChangesAsync();
        }
    }
}
