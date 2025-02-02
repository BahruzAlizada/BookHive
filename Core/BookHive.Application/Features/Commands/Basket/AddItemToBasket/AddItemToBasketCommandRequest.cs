using BookHive.Application.DTOs;
using MediatR;

namespace BookHive.Application.Features.Commands.Basket.AddItemToBasket
{
    public class AddItemToBasketCommandRequest : IRequest<AddItemToBasketCommandResponse>
    {
        public BasketItemAddDto BasketItemAddDto { get; set; }
    }
}