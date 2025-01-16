using AutoMapper;
using BookHive.Application.Abstracts.Caching;
using BookHive.Application.Abstracts.Services;
using BookHive.Application.ConstMessages;
using BookHive.Application.Extensions.FluentValidationExtension;
using BookHive.Application.Rule;
using BookHive.Application.Rules.Abstract;
using BookHive.Application.Utilities;
using BookHive.Application.Validation.FluentValidation;
using MediatR;

namespace BookHive.Application.Features.Commands.BookLanguage
{
    public class CreateBookLanguageCommandHandler : IRequestHandler<CreateBookLanguageCommandRequest, CreateBookLanguageCommandResponse>
    {
        private readonly IBookLanguageWriteRepository bookLanguageWriteRepository;
        private readonly IBookLanguageRuleService bookLanguageRuleService;
        private readonly IMapper mapper;
        private readonly ICacheService cacheService;
        public CreateBookLanguageCommandHandler(IBookLanguageWriteRepository bookLanguageWriteRepository,
            IBookLanguageRuleService bookLanguageRuleService, IMapper mapper, ICacheService cacheService)
        {
            this.bookLanguageWriteRepository = bookLanguageWriteRepository;
            this.bookLanguageRuleService = bookLanguageRuleService;
            this.mapper = mapper;
            this.cacheService = cacheService;
        }



        public async Task<CreateBookLanguageCommandResponse> Handle(CreateBookLanguageCommandRequest request, CancellationToken cancellationToken)
        {
            using PerformanceMeter performanceMeter = new PerformanceMeter("CreateBookLanguageCommandHandler");

            var validationResult = await new BookLanguageAddValidator().ValidateAsync(request.BookLanguageAddDto);
            if (!validationResult.IsValid)
            {
                return new CreateBookLanguageCommandResponse
                {
                    Result = new Parametres.ResponseParametres.Result
                    {
                        Success = false,
                        Message = validationResult.ValidationErrorString()
                    }
                };
            }

            var result = BusinessRules.Run(bookLanguageRuleService.CheckIfNameExisted(request.BookLanguageAddDto.Name));
            if (!result.Success)
            {
                return new CreateBookLanguageCommandResponse { Result = result };
            }

            var bookLanguage = mapper.Map<BookHive.Domain.Entities.BookLanguage>(request.BookLanguageAddDto);

            await bookLanguageWriteRepository.AddAsync(bookLanguage);
            await bookLanguageWriteRepository.SaveAsync();

            cacheService.Remove(CacheKeys.BookLanguage);

            return new CreateBookLanguageCommandResponse
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
