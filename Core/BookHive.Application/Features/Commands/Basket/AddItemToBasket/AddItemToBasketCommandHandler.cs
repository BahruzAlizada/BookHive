using BookHive.Application.Abstracts.Services;
using BookHive.Application.Extensions.FluentValidationExtension;
using BookHive.Application.Parametres.ResponseParametres;
using BookHive.Application.Rule;
using BookHive.Application.Rules.Abstract;
using BookHive.Application.Validation.FluentValidation.BasketValidator;
using MediatR;

namespace BookHive.Application.Features.Commands.Basket.AddItemToBasket
{
    public class AddItemToBasketCommandHandler : IRequestHandler<AddItemToBasketCommandRequest, AddItemToBasketCommandResponse>
    {
        private readonly IBasketWriteRepository basketWriteRepository;
        private readonly IBasketRuleService basketRuleService;
        public AddItemToBasketCommandHandler(IBasketWriteRepository basketWriteRepository, IBasketRuleService basketRuleService)
        {
            this.basketWriteRepository = basketWriteRepository;
            this.basketRuleService = basketRuleService;
        }


        public async Task<AddItemToBasketCommandResponse> Handle(AddItemToBasketCommandRequest request, CancellationToken cancellationToken)
        {
            var validationResult = await ValidationExtension.ValidatorResult(new BasketItemAddDtoValidator(), request.BasketItemAddDto);
            if(!validationResult.Success) return new() { Result = validationResult };


            var result = BusinessRules.Run(basketRuleService.CheckBasketItemQuantity(request.BasketItemAddDto.Quantity), await basketRuleService.CheckBookAvailability(request.BasketItemAddDto.BookId, request.BasketItemAddDto.Quantity));
            if(!result.Success) return new() { Result= result };


            await basketWriteRepository.AddItemToBasketAsync(request.BasketItemAddDto);
            return new() { Result = new SuccessResult("Item Added to Basket") };
        }
    }
}
