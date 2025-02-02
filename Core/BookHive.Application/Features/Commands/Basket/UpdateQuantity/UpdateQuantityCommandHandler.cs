using BookHive.Application.Abstracts.Services.EntityFramework;
using BookHive.Application.Constants;
using BookHive.Application.Parametres.ResponseParametres;
using BookHive.Application.Rule;
using BookHive.Application.Rules.Abstract;
using MediatR;

namespace BookHive.Application.Features.Commands.Basket.UpdateQuantity
{
    public class UpdateQuantityCommandHandler : IRequestHandler<UpdateQuantityCommandRequest, UpdateQuantityCommandResponse>
    {
        private readonly IBasketItemWriteRepository basketItemWriteRepository;
        private readonly IBasketRuleService basketRuleService; 
        public UpdateQuantityCommandHandler(IBasketItemWriteRepository basketItemWriteRepository, IBasketRuleService basketRuleService)
        {
            this.basketItemWriteRepository = basketItemWriteRepository;
            this.basketRuleService = basketRuleService;
        }



        public async Task<UpdateQuantityCommandResponse> Handle(UpdateQuantityCommandRequest request, CancellationToken cancellationToken)
        {

            var result = BusinessRules.Run(basketRuleService.CheckBasketItemQuantity(request.BasketItemUpdateDto.Quantity));
            if (result == null) return new() { Result = result };

            await basketItemWriteRepository.UpdateBasketItemQuantityAsync(request.BasketItemUpdateDto);
            return new() { Result = new SuccessResult(Messages.SuccessUpdated) };
        }
    }
}
