using MediatR;

namespace BookHive.Application.Features.Commands.Basket.ClearBasket
{
    public class ClearBasketCommandRequest : IRequest<ClearBasketCommandResponse>
    {
    }
}