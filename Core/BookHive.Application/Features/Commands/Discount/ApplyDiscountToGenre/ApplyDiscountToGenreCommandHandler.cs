using BookHive.Application.Abstracts.Services.EntityFramework;
using BookHive.Application.Constants;
using BookHive.Application.Extensions.FluentValidationExtension;
using BookHive.Application.Parametres.ResponseParametres;
using BookHive.Application.Rule;
using BookHive.Application.Rules.Abstract;
using BookHive.Application.Validation.FluentValidation.DiscountValidator;
using MediatR;

namespace BookHive.Application.Features.Commands.Discount.ApplyDiscountToGenre
{
    public class ApplyDiscountToGenreCommandHandler : IRequestHandler<ApplyDiscountToGenreCommandRequest, ApplyDiscountToGenreCommandResponse>
    {
        private readonly IDiscountWriteRepository discountWriteRepository;
        private readonly IDiscountRuleService discountRuleService;
        public ApplyDiscountToGenreCommandHandler(IDiscountWriteRepository discountWriteRepository, IDiscountRuleService discountRuleService)
        {
            this.discountWriteRepository = discountWriteRepository;
            this.discountRuleService = discountRuleService;
        }


        public async Task<ApplyDiscountToGenreCommandResponse> Handle(ApplyDiscountToGenreCommandRequest request, CancellationToken cancellationToken)
        {
            var validationResult = await ValidationExtension.ValidatorResult(new DiscountGenreValidator(), request.DiscountGenreDto);
            if(!validationResult.Success) return new() { Result = validationResult };

            var result = BusinessRules.Run(await discountRuleService.CheckGenre(request.DiscountGenreDto.GenreId), discountRuleService.CheckDiscountPrice(request.DiscountGenreDto.DiscountPercentage));
            if(!result.Success) return new() {Result = result};

            await discountWriteRepository.DiscountApplyGenre(request.DiscountGenreDto);
            return new() { Result = new SuccessResult("Discount Applied") };
        }
    }
}
