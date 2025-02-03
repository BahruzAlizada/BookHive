using BookHive.Application.Abstracts.Services.ServiceContracts;
using BookHive.Domain.Entities;
using BookHive.Domain.Identity;
using BookHive.Persistence.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace BookHive.Persistence.Services.ServiceContracts
{
    public class OrderService : IOrderService
    {
        private readonly Context context;
        private readonly UserManager<AppUser> userManager;
        public OrderService(Context context, UserManager<AppUser> userManager)
        {
            this.context = context;
            this.userManager = userManager;
        }
        public async Task<Basket> GetUserActiveBasket()
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
    }
}
