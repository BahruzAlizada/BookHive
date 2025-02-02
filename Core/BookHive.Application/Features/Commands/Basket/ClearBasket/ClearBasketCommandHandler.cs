using BookHive.Application.Abstracts.Services.EntityFramework;
using BookHive.Application.Constants;
using BookHive.Application.Parametres.ResponseParametres;
using MediatR;

namespace BookHive.Application.Features.Commands.Basket.ClearBasket
{
    public class ClearBasketCommandHandler : IRequestHandler<ClearBasketCommandRequest, ClearBasketCommandResponse>
    {
        private readonly IBasketWriteRepository basketWriteRepository;
        public ClearBasketCommandHandler(IBasketWriteRepository basketWriteRepository)
        {
            this.basketWriteRepository = basketWriteRepository;
        }



        public async Task<ClearBasketCommandResponse> Handle(ClearBasketCommandRequest request, CancellationToken cancellationToken)
        {
            await basketWriteRepository.ClearBasket();
            return new ClearBasketCommandResponse { Result = new SuccessResult(Messages.SuccessDeleted) };
        }
    }
}
