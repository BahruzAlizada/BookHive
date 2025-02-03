using BookHive.Application.Abstracts.Services.ServiceContracts;
using BookHive.Domain.Entities;
using BookHive.Domain.Identity;
using BookHive.Persistence.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace BookHive.Persistence.Services.ServiceContracts
{
    public class BasketService : IBasketService
    {
        private readonly Context context;
        private readonly UserManager<AppUser> userManager;
        private readonly IHttpContextAccessor httpContextAccessor;
        public BasketService(Context context, UserManager<AppUser> userManager, IHttpContextAccessor httpContextAccessor)
        {
            this.context = context;
            this.userManager = userManager; 
            this.httpContextAccessor = httpContextAccessor;
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
                    Coupon? coupon = await ValidateAndApplyCouponAsync(basket);
                    if(coupon != null)
                    {
                        if (coupon.IsPercentage)
                        {
                            totalPrice = totalPrice - (totalPrice * coupon.Discount / 100);
                        }
                        else
                        {
                            totalPrice -= coupon.Discount;
                        }
                    }
                }

                if (totalPrice < 0)
                {
                    totalPrice = Math.Max(0, totalPrice);
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

        public async Task<Basket?> GetBasket()
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

        private async Task<Coupon?> ValidateAndApplyCouponAsync(Basket basket)
        {
            if (!basket.IsUsedCoupon || basket.CouponId == null)
                return null;

            bool isCouponExpiredByAppliedDate = basket.CouponUsedDate.HasValue
            && basket.CouponUsedDate.Value.AddDays(3).Date < DateTime.Now.Date;

            Coupon? coupon = await context.Coupons.FirstOrDefaultAsync(x => x.Id == basket.CouponId);
            if ((coupon == null || coupon.ExpiryDate.Date < DateTime.Now.Date) || isCouponExpiredByAppliedDate)
            {
                basket.IsUsedCoupon = false;
                basket.CouponId = null;
                basket.CouponUsedDate = null;
                context.Baskets.Update(basket);
                await context.SaveChangesAsync();
                return null;
            }
            return coupon;
        }
    }
}
