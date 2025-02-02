using BookHive.Application.Abstracts.Services.EntityFramework;
using BookHive.Domain.Entities;
using BookHive.Domain.Identity;
using BookHive.Persistence.Concrete;
using BookHive.Persistence.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace BookHive.Persistence.Services.EntityFramework
{
    public class BasketItemReadRepository : ReadRepository<BasketItem>, IBasketItemReadRepository
    {
        private readonly Context context;
        private readonly UserManager<AppUser> userManager;
        private readonly IHttpContextAccessor httpContextAccessor;
        public BasketItemReadRepository(Context context, UserManager<AppUser> userManager, IHttpContextAccessor httpContextAccessor) : base(context)
        {
            this.context = context;
            this.userManager = userManager;
            this.httpContextAccessor = httpContextAccessor;
        }

        public async Task<int> GetBasketItemBookQuantity(Guid bookId)
        {
            //string username = httpContextAccessor.HttpContext.User.Identity.Name;
            string username = "bahruzalizada";
            if (string.IsNullOrEmpty(username))
                throw new Exception("An Error occured");

            AppUser? user = await userManager.FindByNameAsync(username);
            if (user == null)
                throw new Exception("User is not authenticated.");

            Basket? basket = await context.Baskets.FirstOrDefaultAsync(x => x.UserId == user.Id && !x.IsCompleted);
            if (basket == null)
            {
                return 0;
            }

            var basketItems = await context.BasketItems.FirstOrDefaultAsync(x => x.BookId == bookId && x.BasketId == basket.Id);
            if (basketItems == null)
                return 0;
            else
                return basketItems.Quantity;
        }
    }
}
