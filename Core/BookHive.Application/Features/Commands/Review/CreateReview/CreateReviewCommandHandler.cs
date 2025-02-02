using BookHive.Application.Abstracts.Services.EntityFramework;
using BookHive.Application.Constants;
using BookHive.Application.Extensions.FluentValidationExtension;
using BookHive.Application.Parametres.ResponseParametres;
using BookHive.Application.Rule;
using BookHive.Application.Rules.Abstract;
using BookHive.Application.Validation.FluentValidation.ReviewValidator;
using MediatR;

namespace BookHive.Application.Features.Commands.Review.CreateReview
{
    public class CreateReviewCommandHandler : IRequestHandler<CreateReviewCommandRequest, CreateReviewCommandResponse>
    {
        private readonly IReviewWriteRepository reviewWriteRepository;
        private readonly IReviewRuleService reviewRuleService;
        public CreateReviewCommandHandler(IReviewWriteRepository reviewWriteRepository, IReviewRuleService reviewRuleService)
        {
            this.reviewWriteRepository = reviewWriteRepository;
            this.reviewRuleService = reviewRuleService; 
        }


        public async Task<CreateReviewCommandResponse> Handle(CreateReviewCommandRequest request, CancellationToken cancellationToken)
        {
            var validationResult = await ValidationExtension.ValidatorResult(new ReviewAddValidator(), request.ReviewAddDto);
            if(!validationResult.Success) return new() { Result = validationResult };

            var result = BusinessRules.Run(await reviewRuleService.CheckUserId(request.ReviewAddDto.UserId), await reviewRuleService.CheckBookId(request.ReviewAddDto.BookId),
                reviewRuleService.CheckRating(request.ReviewAddDto.Rating));
            if(!result.Success) return new() {Result = result};

            await reviewWriteRepository.AddReviewAsync(request.ReviewAddDto);
            return new() { Result = new SuccessResult(Messages.SuccessAdded) };
        }
    }
}
