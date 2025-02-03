using BookHive.Application.Abstracts.Services.EntityFramework;
using BookHive.Application.Abstracts.Services.ServiceContracts;
using BookHive.Application.DTO;
using BookHive.Application.DTOs;
using BookHive.Domain.Entities;
using BookHive.Domain.Identity;
using BookHive.Persistence.Concrete;
using BookHive.Persistence.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace BookHive.Persistence.Services.EntityFramework
{
    public class BasketWriteRepository : WriteRepository<Basket>, IBasketWriteRepository
    {
        private readonly Context context;
        private readonly IBasketService basketService;
        private readonly UserManager<AppUser> userManager;
        public BasketWriteRepository(Context context, IBasketService basketService, UserManager<AppUser> userManager) : base(context)
        {
            this.context = context;
            this.basketService = basketService;
            this.userManager = userManager;
        }

        


        public async Task AddItemToBasketAsync(BasketItemAddDto basketItemAddDto)
        {
            Basket? basket = await basketService.GetBasket();
            if (basket is null)
                throw new Exception("Basket not found");

            BasketItem? basketItem = await context.BasketItems.FirstOrDefaultAsync(x => x.BookId == basketItemAddDto.BookId && x.BasketId == basket.Id);
            if (basketItem is not null)
            {
                basketItem.Quantity += basketItemAddDto.Quantity;
            }
            else
            {
                BasketItem item = new BasketItem
                {
                    BasketId = basket.Id,
                    Quantity = basketItemAddDto.Quantity,
                    BookId = basketItemAddDto.BookId,
                };

                await context.BasketItems.AddAsync(item);
            }
            await context.SaveChangesAsync();


            context.Baskets.Update(basket);
            await context.SaveChangesAsync();

            await basketService.CalculateTotalPrice(basket);
        }


        public async Task ApplyCouponAsync(ApplyCouponToBasketDto applyCouponToBasketDto)
        {
            Basket? basket = await context.Baskets.FindAsync(applyCouponToBasketDto.BasketId);
            if (basket is null)
                throw new Exception("Basket Not found");

            Coupon? coupon = await context.Coupons.FirstOrDefaultAsync(x => x.Code == applyCouponToBasketDto.Code);
            if (coupon is null)
                throw new Exception("Coupon not found");


            CouponUsage? couponUsage = await context.CouponUsages.FirstOrDefaultAsync(x=>x.UserId==basket.UserId && x.Coupon.Code == applyCouponToBasketDto.Code);
            if(couponUsage is not null)
            {
                throw new Exception("Siz bu kupondan istifadə etmisiniz");
            }

            basket.IsUsedCoupon = true;
            basket.CouponUsedDate = DateTime.UtcNow.AddHours(4);
            basket.CouponId = coupon.Id;

            context.Baskets.Update(basket);

            CouponUsage newCouponUsage = new CouponUsage
            {
                CouponId = coupon.Id,
                UserId = basket.UserId,
                UsedDate = DateTime.UtcNow.AddHours(4)
            };
            await context.CouponUsages.AddAsync(newCouponUsage);
            await context.SaveChangesAsync();

            await basketService.CalculateTotalPrice(basket);
        }



        public async Task ClearBasket()
        {
            Basket? basket = await basketService.GetBasket();
            if (basket == null)
                throw new Exception("Basket not found");

            List<BasketItem> basketItems = await context.BasketItems.Where(x=>x.BasketId==basket.Id).ToListAsync();
            if (basketItems.Count == 0)
            {
                return;
            }
            else
            {
                context.BasketItems.RemoveRange(basketItems);
                await context.SaveChangesAsync();

                await basketService.CalculateTotalPrice(basket);
            }
            
        }
    }
}
