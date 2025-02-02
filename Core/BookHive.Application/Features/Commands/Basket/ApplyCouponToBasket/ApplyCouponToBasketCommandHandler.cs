using BookHive.Application.Abstracts.Services;
using BookHive.Application.Extensions.FluentValidationExtension;
using BookHive.Application.Parametres.ResponseParametres;
using BookHive.Application.Rule;
using BookHive.Application.Rules.Abstract;
using BookHive.Application.Validation.FluentValidation.BasketValidator;
using MediatR;

namespace BookHive.Application.Features.Commands.Basket.ApplyCouponToBasket
{
    public class ApplyCouponToBasketCommandHandler : IRequestHandler<ApplyCouponToBasketCommandRequest, ApplyCouponToBasketCommandResponse>
    {
        private readonly IBasketWriteRepository basketWriteRepository;
        private readonly IBasketRuleService basketRuleService;
        public ApplyCouponToBasketCommandHandler(IBasketWriteRepository basketWriteRepository, IBasketRuleService basketRuleService)
        {
            this.basketWriteRepository = basketWriteRepository;
            this.basketRuleService = basketRuleService;
        }


        public async Task<ApplyCouponToBasketCommandResponse> Handle(ApplyCouponToBasketCommandRequest request, CancellationToken cancellationToken)
        {
            var validationResult = await ValidationExtension.ValidatorResult(new ApplyCouponToBasketValdiator(), request.ApplyCouponToBasketDto);
            if(!validationResult.Success) return new() { Result = validationResult };

            var result = BusinessRules.Run(await basketRuleService.CheckBasketCouponExpiryDate(request.ApplyCouponToBasketDto.Code));
            if(!result.Success) return new() {Result = result};

            await basketWriteRepository.ApplyCouponAsync(request.ApplyCouponToBasketDto);
            return new ApplyCouponToBasketCommandResponse { Result = new SuccessResult("Coupon Applied to Basket") };
        }
    }
}
