
using AutoMapper;
using BookHive.Application.Abstracts.Services;
using BookHive.Application.ConstMessages;
using BookHive.Application.Extensions.FluentValidationExtension;
using BookHive.Application.Rule;
using BookHive.Application.Rules.Abstract;
using BookHive.Application.Validation.FluentValidation.AuthorValidator;
using MediatR;

namespace BookHive.Application.Features.Commands.Author.UpdateAuthor
{
    public class UpdateAuthorCommandHandler : IRequestHandler<UpdateAuthorCommandRequest, UpdateAuthorCommandResponse>
    {
        private readonly IAuthorWriteRepository authorWriteRepository;
        private readonly IAuthorRuleService authorRuleService;
        private readonly IMapper mapper;
        public UpdateAuthorCommandHandler(IAuthorWriteRepository authorWriteRepository, IAuthorRuleService authorRuleService, IMapper mapper)
        {
            this.authorWriteRepository = authorWriteRepository;
            this.authorRuleService = authorRuleService;
            this.mapper = mapper;
        }



        public async Task<UpdateAuthorCommandResponse> Handle(UpdateAuthorCommandRequest request, CancellationToken cancellationToken)
        {
            var validationResult = await new AuthorUpdateValidator().ValidateAsync(request.AuthorUpdateDto);
            if(!validationResult.IsValid)
            {
                return new UpdateAuthorCommandResponse
                {
                    Result = new Parametres.ResponseParametres.Result
                    {
                        Success = false,
                        Message = validationResult.ValidationErrorString()
                    }
                };
            }

            var result = BusinessRules.Run(authorRuleService.CheckIfNameExisted(request.AuthorUpdateDto.Name, request.AuthorUpdateDto.Id));
            if(!result.Success)
            {
                return new UpdateAuthorCommandResponse
                {
                    Result = result
                };
            }

            var author = mapper.Map<BookHive.Domain.Entities.Author>(request.AuthorUpdateDto);

            authorWriteRepository.Update(author);
            await authorWriteRepository.SaveAsync();

            return new UpdateAuthorCommandResponse
            {
                Result = new Parametres.ResponseParametres.Result
                {
                    Success = true,
                    Message = Messages.SuccessUpdated
                }
            };

        }
    }
}
