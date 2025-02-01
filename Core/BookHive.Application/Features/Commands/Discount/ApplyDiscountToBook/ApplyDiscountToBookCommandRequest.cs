using BookHive.Application.DTOs;
using MediatR;

namespace BookHive.Application.Features.Commands.Discount.ApplyDiscountToBook
{
    public class ApplyDiscountToBookCommandRequest : IRequest<ApplyDiscountToBookCommandResponse>
    {
        public DiscountBookDto DiscountBookDto { get; set; }
    }
}