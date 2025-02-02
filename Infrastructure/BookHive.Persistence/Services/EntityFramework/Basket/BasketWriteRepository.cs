using BookHive.Application.Abstracts.Services.EntityFramework;
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
        private readonly UserManager<AppUser> userManager;
        private readonly IHttpContextAccessor httpContextAccessor;
        public BasketWriteRepository(Context context, UserManager<AppUser> userManager, IHttpContextAccessor httpContextAccessor) : base(context)
        {
            this.context = context;
            this.userManager = userManager;
            this.httpContextAccessor = httpContextAccessor;
        }

        private async Task<Basket?> ContextUser()
        {
            //string username = httpContextAccessor.HttpContext.User.Identity.Name;
            string username = "bahruzalizada";
            if (!string.IsNullOrEmpty(username))
            {
                AppUser? user = await userManager.Users.Include(x => x.Baskets).ThenInclude(x => x.Order).FirstOrDefaultAsync(x => x.UserName == username);
                if (user is not null)
                {
                    Basket basket = user.Baskets.FirstOrDefault(b => !b.IsCompleted && b.Order == null);
                    if (basket is not null)
                        return basket;
                    else
                    {
                        Basket newBasket = new Basket
                        {
                            UserId = user.Id,
                            IsCompleted = false,
                        };
                        await context.Baskets.AddAsync(newBasket);
                        await context.SaveChangesAsync();
                        return newBasket;
                    }
                }
                else
                {
                    throw new Exception("An Error Occured");
                }

            }
            else
                throw new Exception("User is not authenticated.");
        }


        public async Task AddItemToBasketAsync(BasketItemAddDto basketItemAddDto)
        {
            Basket? basket = await ContextUser();
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

            await CalculateTotalPrice(basket);
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

            await CalculateTotalPrice(basket);
        }


        public async Task CalculateTotalPrice(Basket basket)
        {
            double totalPrice = 0;
            List<BasketItem> basketItems = await context.BasketItems.Include(x => x.Book).ThenInclude(x => x.BookDiscount).Where(x => x.BasketId == basket.Id).ToListAsync();
            if (basketItems.Count == 0)
            {
                basket.TotalPrice = totalPrice;
            }
            else
            {
                foreach (var item in basketItems)
                {
                    if (item.Book.DiscountPrice != 0 && item.Book.BookDiscount.IsDiscount)
                    {
                        totalPrice += item.Quantity * item.Book.DiscountPrice;
                    }
                    else
                    {
                        totalPrice += item.Quantity * item.Book.Price;
                    }
                }
                if (basket.IsUsedCoupon)
                {
                    Coupon? coupon = await context.Coupons.FirstOrDefaultAsync(x => x.Id == basket.CouponId);
                    if (coupon.IsPercentage)
                    {
                        totalPrice = totalPrice - (totalPrice * coupon.Discount / 100);
                    }
                    else
                    {
                        totalPrice -= coupon.Discount;
                    }
                }

                if (totalPrice % 1 != 0)
                {
                    totalPrice = Math.Round(totalPrice, 2, MidpointRounding.AwayFromZero);
                }
            }

            basket.TotalPrice = totalPrice;
            context.Baskets.Update(basket);
            await context.SaveChangesAsync();
        }

        public async Task ClearBasket()
        {
            Basket? basket = await ContextUser();
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

                await CalculateTotalPrice(basket);
            }
            
        }
    }
}
