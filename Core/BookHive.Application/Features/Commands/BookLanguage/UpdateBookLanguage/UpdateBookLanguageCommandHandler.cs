using AutoMapper;
using BookHive.Application.Abstracts.Caching;
using BookHive.Application.Abstracts.Services;
using BookHive.Application.ConstMessages;
using BookHive.Application.Extensions.FluentValidationExtension;
using BookHive.Application.Rule;
using BookHive.Application.Rules.Abstract;
using BookHive.Application.Validation.FluentValidation;
using MediatR;

namespace BookHive.Application.Features.Commands.BookLanguage.UpdateBookLanguage
{
    public class UpdateBookLanguageCommandHandler : IRequestHandler<UpdateBookLanguageCommandRequest, UpdateBookLanguageCommandResponse>
    {
        private readonly IBookLanguageWriteRepository bookLanguageWriteRepository;
        private readonly IBookLanguageRuleService bookLanguageRuleService;
        private readonly IMapper mapper;
        private readonly ICacheService cacheService;
        public UpdateBookLanguageCommandHandler(IBookLanguageWriteRepository bookLanguageWriteRepository,
            IBookLanguageRuleService bookLanguageRuleService, IMapper mapper,ICacheService cacheService)
        {
            this.bookLanguageWriteRepository = bookLanguageWriteRepository;
            this.bookLanguageRuleService = bookLanguageRuleService;
            this.mapper = mapper;
            this.cacheService = cacheService;
        }


        public async Task<UpdateBookLanguageCommandResponse> Handle(UpdateBookLanguageCommandRequest request, CancellationToken cancellationToken)
        {
            var validationResult = await new BookLanguageUpdateValidator().ValidateAsync(request.BookLanguageUpdateDto);
            if (!validationResult.IsValid)
            {
                return new UpdateBookLanguageCommandResponse
                {
                    Result = new Parametres.ResponseParametres.Result
                    {
                        Success = false,
                        Message = validationResult.ValidationErrorString()
                    }
                };
            }

            var result = BusinessRules.Run(bookLanguageRuleService.CheckIfNameExisted(request.BookLanguageUpdateDto.Name, request.BookLanguageUpdateDto.Id));
            if (!result.Success)
            {
                return new UpdateBookLanguageCommandResponse { Result = result };
            }

            var bookLanguage = mapper.Map<BookHive.Domain.Entities.BookLanguage>(request.BookLanguageUpdateDto);

            bookLanguageWriteRepository.Update(bookLanguage);
            await bookLanguageWriteRepository.SaveAsync();

            cacheService.Remove(CacheKeys.BookLanguage);

            return new UpdateBookLanguageCommandResponse
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
