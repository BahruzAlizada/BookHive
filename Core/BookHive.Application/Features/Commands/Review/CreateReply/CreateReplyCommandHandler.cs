using BookHive.Application.Abstracts.Services.EntityFramework;
using BookHive.Application.Constants;
using BookHive.Application.Extensions.FluentValidationExtension;
using BookHive.Application.Parametres.ResponseParametres;
using BookHive.Application.Rule;
using BookHive.Application.Rules.Abstract;
using BookHive.Application.Validation.FluentValidation.ReviewValidator;
using MediatR;

namespace BookHive.Application.Features.Commands.Review.CreateReply
{
    public class CreateReplyCommandHandler : IRequestHandler<CreateReplyCommandRequest, CreateReplyCommandResponse>
    {
        private readonly IReviewWriteRepository reviewWriteRepository;
        private readonly IReviewRuleService reviewRuleService;
        public CreateReplyCommandHandler(IReviewWriteRepository reviewWriteRepository, IReviewRuleService reviewRuleService)
        {
            this.reviewWriteRepository = reviewWriteRepository;
            this.reviewRuleService = reviewRuleService;
        }


        public async Task<CreateReplyCommandResponse> Handle(CreateReplyCommandRequest request, CancellationToken cancellationToken)
        {
            var validationResult = await ValidationExtension.ValidatorResult(new ReplyAddValidator(), request.ReplyAddDto);
            if (!validationResult.Success) return new() { Result = validationResult };

            var result = BusinessRules.Run(await reviewRuleService.CheckUserId(request.ReplyAddDto.UserId), await reviewRuleService.CheckReviewId(request.ReplyAddDto.ParentId));
            if(!result.Success) return new() { Result = result };

            await reviewWriteRepository.AddReplyAsync(request.ReplyAddDto);
            return new() { Result = new SuccessResult(Messages.SuccessAdded) };
            
        }
    }
}
