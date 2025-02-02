

using BookHive.Application.Abstracts.Services;
using BookHive.Application.Constants;
using BookHive.Application.Parametres.ResponseParametres;
using BookHive.Domain.Entities;
using MediatR;

namespace BookHive.Application.Features.Commands.Basket.DeleteBasketItem
{
    public class DeleteBasketItemCommandHandler : IRequestHandler<DeleteBasketItemCommandRequest, DeleteBasketItemCommandResponse>
    {
        private readonly IBasketItemReadRepository basketItemReadRepository;
        private readonly IBasketItemWriteRepository basketItemWriteRepository;
        public DeleteBasketItemCommandHandler(IBasketItemReadRepository basketItemReadRepository, IBasketItemWriteRepository basketItemWriteRepository)
        {
            this.basketItemReadRepository = basketItemReadRepository;
            this.basketItemWriteRepository = basketItemWriteRepository;
        }



        public async Task<DeleteBasketItemCommandResponse> Handle(DeleteBasketItemCommandRequest request, CancellationToken cancellationToken)
        {
            BasketItem basketItem = await basketItemReadRepository.GetFindAsync(request.Id);
            if (basketItem == null) return new() { Result = new ErrorResult(Messages.IdNull) };

            await basketItemWriteRepository.DeleteBasketItem(basketItem);
            return new() { Result = new SuccessResult(Messages.SuccessDeleted) };
        }
    }
}
