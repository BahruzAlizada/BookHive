using BookHive.Application.Abstracts.ServiceContracts;
using BookHive.Application.Abstracts.Services.EntityFramework;
using BookHive.Application.DTOs;
using BookHive.Domain.Entities;
using BookHive.Persistence.Concrete;
using BookHive.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;

namespace BookHive.Persistence.Services.EntityFramework
{
    public class BasketItemWriteRepository : WriteRepository<BasketItem>, IBasketItemWriteRepository
    {
        private readonly Context context;
        private readonly IBasketService basketService;
        public BasketItemWriteRepository(Context context, IBasketService basketService) : base(context)
        {
            this.context = context;
            this.basketService = basketService;
        }

        public async Task DeleteBasketItem(BasketItem item)
        {
            Basket? basket = await context.Baskets.FindAsync(item.BasketId);
            if (basket == null)
                throw new Exception("Basket not found");

            context.BasketItems.Remove(item);
            context.Baskets.Update(basket);
            await context.SaveChangesAsync();


            await basketService.CalculateTotalPrice(basket);
        }

        public async Task UpdateBasketItemQuantityAsync(BasketItemUpdateDto basketItemUpdateDto)
        {
            BasketItem? basketItem = await context.BasketItems.FindAsync(basketItemUpdateDto.BasketItemId);
            if (basketItem == null)
                throw new Exception("BasketItem NotFound");

            Basket? basket = await context.Baskets.FirstOrDefaultAsync(x => x.Id == basketItem.BasketId);
            if (basket == null)
                throw new Exception("Basket not found");

            basketItem.Quantity = basketItemUpdateDto.Quantity;
            context.BasketItems.Update(basketItem);
            await context.SaveChangesAsync();

            await basketService.CalculateTotalPrice(basket);
        }
    }
}
