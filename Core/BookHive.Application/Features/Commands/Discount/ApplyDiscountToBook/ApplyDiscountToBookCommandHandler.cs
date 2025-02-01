

using BookHive.Application.Abstracts.Services;
using BookHive.Application.Extensions.FluentValidationExtension;
using BookHive.Application.Parametres.ResponseParametres;
using BookHive.Application.Rule;
using BookHive.Application.Rules.Abstract;
using BookHive.Application.Validation.FluentValidation.DiscountValidator;
using MediatR;

namespace BookHive.Application.Features.Commands.Discount.ApplyDiscountToBook
{
    public class ApplyDiscountToBookCommandHandler : IRequestHandler<ApplyDiscountToBookCommandRequest, ApplyDiscountToBookCommandResponse>
    {
        private readonly IDiscountWriteRepository discountWriteRepository;
        private readonly IDiscountRuleService discountRuleService;
        public ApplyDiscountToBookCommandHandler(IDiscountWriteRepository discountWriteRepository, IDiscountRuleService discountRuleService)
        {
            this.discountWriteRepository = discountWriteRepository;
            this.discountRuleService = discountRuleService;
        }

        public async Task<ApplyDiscountToBookCommandResponse> Handle(ApplyDiscountToBookCommandRequest request, CancellationToken cancellationToken)
        {
            var validationResult = await ValidationExtension.ValidatorResult(new DiscountBookValidator(), request.DiscountBookDto);
            if (!validationResult.Success) return new() { Result = validationResult };

            var result = BusinessRules.Run(await discountRuleService.CheckBook(request.DiscountBookDto.BookId), discountRuleService.CheckDiscountPrice(request.DiscountBookDto.DiscountPercentage));
            if (!result.Success) return new() { Result = result };

            await discountWriteRepository.DiscountApplyBook(request.DiscountBookDto);
            return new() { Result = new SuccessResult("Discount Applied") };
        }
    }
}
