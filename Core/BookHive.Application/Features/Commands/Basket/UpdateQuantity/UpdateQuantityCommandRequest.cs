using BookHive.Application.DTOs;
using MediatR;

namespace BookHive.Application.Features.Commands.Basket.UpdateQuantity
{
    public class UpdateQuantityCommandRequest : IRequest<UpdateQuantityCommandResponse>
    {
        public BasketItemUpdateDto BasketItemUpdateDto { get; set; }
    }
}