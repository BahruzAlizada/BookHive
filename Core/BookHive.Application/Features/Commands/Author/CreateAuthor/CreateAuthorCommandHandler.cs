using AutoMapper;
using BookHive.Application.Abstracts.Services;
using BookHive.Application.ConstMessages;
using BookHive.Application.Extensions.FluentValidationExtension;
using BookHive.Application.Rule;
using BookHive.Application.Rules.Abstract;
using BookHive.Application.Validation.FluentValidation.AuthorValidator;
using MediatR;

namespace BookHive.Application.Features.Commands.Author.CreateAuthor
{
    public class CreateAuthorCommandHandler : IRequestHandler<CreateAuthorCommandRequest, CreateAuthorCommandResponse>
    {
        private readonly IAuthorWriteRepository authorWriteRepository;
        private readonly IAuthorRuleService authorRuleService;
        private readonly IMapper mapper;
        public CreateAuthorCommandHandler(IAuthorWriteRepository authorWriteRepository, IAuthorRuleService authorRuleService, IMapper mapper)
        {
            this.authorWriteRepository = authorWriteRepository;
            this.authorRuleService = authorRuleService;
            this.mapper = mapper;
        }


        public async Task<CreateAuthorCommandResponse> Handle(CreateAuthorCommandRequest request, CancellationToken cancellationToken)
        {
            var validationResult = await new AuthorAddValidator().ValidateAsync(request.AuthorAddDto);
            if(!validationResult.IsValid)
            {
                return new CreateAuthorCommandResponse
                {
                    Result = new Parametres.ResponseParametres.Result
                    {
                        Success = false,
                        Message = validationResult.ValidationErrorString()
                    }
                };
            }

            var result = BusinessRules.Run(authorRuleService.CheckIfNameExisted(request.AuthorAddDto.Name));
            if (!result.Success)
            {
                return new CreateAuthorCommandResponse
                {
                    Result = result
                };
            }

            BookHive.Domain.Entities.Author Author = mapper.Map<BookHive.Domain.Entities.Author>(request.AuthorAddDto);

            await authorWriteRepository.AddAsync(Author);
            await authorWriteRepository.SaveAsync();

            return new CreateAuthorCommandResponse
            {
                Result = new Parametres.ResponseParametres.Result
                {
                    Success = true,
                    Message = Messages.SuccessAdded
                }
            };
        }
    }
}
