using BookHive.Application.DTOs;
using BookHive.Domain.Entities;
using MediatR;

namespace BookHive.Application.Features.Commands.Coupon.CreateCoupon
{
    public class CreateCouponCommandRequest : IRequest<CreateCouponCommandResponse>
    {
        public CouponAddDto couponAddDto { get; set; }
    }
}