using BookHive.Application.Abstracts.Services.EntityFramework;
using BookHive.Application.Constants;
using BookHive.Application.Extensions.FluentValidationExtension;
using BookHive.Application.Parametres.ResponseParametres;
using BookHive.Application.Rule;
using BookHive.Application.Rules.Abstract;
using BookHive.Application.Validation.FluentValidation.AuthorValidator;
using Mapster;
using MediatR;

namespace BookHive.Application.Features.Commands.Author.CreateAuthor
{
    public class CreateAuthorCommandHandler : IRequestHandler<CreateAuthorCommandRequest, CreateAuthorCommandResponse>
    {
        private readonly IAuthorWriteRepository authorWriteRepository;
        private readonly IAuthorRuleService authorRuleService;
        public CreateAuthorCommandHandler(IAuthorWriteRepository authorWriteRepository, IAuthorRuleService authorRuleService)
        {
            this.authorWriteRepository = authorWriteRepository;
            this.authorRuleService = authorRuleService;
        }


        public async Task<CreateAuthorCommandResponse> Handle(CreateAuthorCommandRequest request, CancellationToken cancellationToken)
        {
            var validationResult = await ValidationExtension.ValidatorResult(new AuthorAddValidator(), request.AuthorAddDto);
            if(!validationResult.Success) return new() { Result = validationResult };
            

            var result = BusinessRules.Run(authorRuleService.CheckIfNameExisted(request.AuthorAddDto.Name));
            if (!result.Success) return new() { Result = result };
            

            BookHive.Domain.Entities.Author Author = request.AuthorAddDto.Adapt<BookHive.Domain.Entities.Author>();
            await authorWriteRepository.AddAsync(Author);
            await authorWriteRepository.SaveAsync();

            return new CreateAuthorCommandResponse { Result = new SuccessResult(Messages.SuccessAdded) };
        }
    }
}
