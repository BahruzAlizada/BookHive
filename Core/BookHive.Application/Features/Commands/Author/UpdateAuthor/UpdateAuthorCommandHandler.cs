using BookHive.Application.Abstracts.Services.EntityFramework;
using BookHive.Application.Constants;
using BookHive.Application.Extensions.FluentValidationExtension;
using BookHive.Application.Parametres.ResponseParametres;
using BookHive.Application.Rule;
using BookHive.Application.Rules.Abstract;
using BookHive.Application.Validation.FluentValidation.AuthorValidator;
using Mapster;
using MediatR;

namespace BookHive.Application.Features.Commands.Author.UpdateAuthor
{
    public class UpdateAuthorCommandHandler : IRequestHandler<UpdateAuthorCommandRequest, UpdateAuthorCommandResponse>
    {
        private readonly IAuthorWriteRepository authorWriteRepository;
        private readonly IAuthorRuleService authorRuleService;
        public UpdateAuthorCommandHandler(IAuthorWriteRepository authorWriteRepository, IAuthorRuleService authorRuleService)
        {
            this.authorWriteRepository = authorWriteRepository;
            this.authorRuleService = authorRuleService;
        }



        public async Task<UpdateAuthorCommandResponse> Handle(UpdateAuthorCommandRequest request, CancellationToken cancellationToken)
        {
            var validationResult = await ValidationExtension.ValidatorResult(new AuthorUpdateValidator(), request.AuthorUpdateDto);
            if (!validationResult.Success) return new() { Result = validationResult };
            

            var result = BusinessRules.Run(authorRuleService.CheckIfNameExisted(request.AuthorUpdateDto.Name, request.AuthorUpdateDto.Id));
            if (!result.Success) return new() { Result = result };
         

            var author = request.AuthorUpdateDto.Adapt<BookHive.Domain.Entities.Author>();
            authorWriteRepository.Update(author);
            await authorWriteRepository.SaveAsync();

            return new UpdateAuthorCommandResponse { Result = new SuccessResult(Messages.SuccessUpdated) };
        }
    }
}
