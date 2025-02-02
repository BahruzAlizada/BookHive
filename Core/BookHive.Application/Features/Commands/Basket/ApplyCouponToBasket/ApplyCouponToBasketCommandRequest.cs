using BookHive.Application.DTO;
using MediatR;

namespace BookHive.Application.Features.Commands.Basket.ApplyCouponToBasket
{
    public class ApplyCouponToBasketCommandRequest : IRequest<ApplyCouponToBasketCommandResponse>
    {
        public ApplyCouponToBasketDto ApplyCouponToBasketDto { get; set; }
    }
}