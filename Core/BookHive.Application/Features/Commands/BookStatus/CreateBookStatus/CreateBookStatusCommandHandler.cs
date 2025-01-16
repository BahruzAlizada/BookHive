using AutoMapper;
using BookHive.Application.Abstracts.Services;
using BookHive.Application.ConstMessages;
using BookHive.Application.Extensions.FluentValidationExtension;
using BookHive.Application.Rule;
using BookHive.Application.Rules.Abstract;
using BookHive.Application.Validation.FluentValidation;
using MediatR;

namespace BookHive.Application.Features.Commands.BookStatus.CreateBookStatus
{
    public class CreateBookStatusCommandHandler : IRequestHandler<CreateBookStatusCommandRequest, CreateBookStatusCommandResponse>
    {
        private readonly IBookStatusWriteRepository bookStatusWriteRepository;
        private readonly IBookStatusRuleService bookStatusRuleService;
        private readonly IMapper mapper;
        public CreateBookStatusCommandHandler(IBookStatusWriteRepository bookStatusWriteRepository, IBookStatusRuleService bookStatusRuleService, IMapper mapper)
        {
            this.bookStatusWriteRepository = bookStatusWriteRepository;
            this.bookStatusRuleService = bookStatusRuleService;
            this.mapper = mapper;
        }
        public async Task<CreateBookStatusCommandResponse> Handle(CreateBookStatusCommandRequest request, CancellationToken cancellationToken)
        {
            var validationResult = await new BookStatusAddValidator().ValidateAsync(request.BookStatusAddDto);
            if (!validationResult.IsValid)
            {
                return new CreateBookStatusCommandResponse
                {
                    Result = new Parametres.ResponseParametres.Result
                    {
                        Success = false,
                        Message = validationResult.ValidationErrorString()
                    }
                };
            }

            var result = BusinessRules.Run(bookStatusRuleService.CheckIfNameExisted(request.BookStatusAddDto.Name));
            if (!result.Success)
            {
                return new CreateBookStatusCommandResponse
                {
                    Result = result
                };
            }

            var bookStatus = mapper.Map<BookHive.Domain.Entities.BookStatus>(request.BookStatusAddDto);

            await bookStatusWriteRepository.AddAsync(bookStatus);
            await bookStatusWriteRepository.SaveAsync();
            return new CreateBookStatusCommandResponse
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
