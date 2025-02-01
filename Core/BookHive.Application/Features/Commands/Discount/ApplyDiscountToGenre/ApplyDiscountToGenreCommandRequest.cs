using BookHive.Application.DTOs.Discount;
using MediatR;

namespace BookHive.Application.Features.Commands.Discount.ApplyDiscountToGenre
{
    public class ApplyDiscountToGenreCommandRequest : IRequest<ApplyDiscountToGenreCommandResponse>
    {
        public DiscountGenreDto DiscountGenreDto { get; set; }
    }
}