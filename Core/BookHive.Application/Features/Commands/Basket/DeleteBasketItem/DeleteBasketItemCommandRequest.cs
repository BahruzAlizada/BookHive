using MediatR;

namespace BookHive.Application.Features.Commands.Basket.DeleteBasketItem
{
    public class DeleteBasketItemCommandRequest : IRequest<DeleteBasketItemCommandResponse>
    {
        public Guid Id { get; set; }
    }
}