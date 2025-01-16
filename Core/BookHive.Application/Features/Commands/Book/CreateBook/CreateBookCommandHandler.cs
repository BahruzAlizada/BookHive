

using AutoMapper;
using BookHive.Application.Abstracts.Services;
using BookHive.Application.ConstMessages;
using BookHive.Application.Extensions.FluentValidationExtension;
using BookHive.Application.Rule;
using BookHive.Application.Rules.Abstract;
using BookHive.Application.Validation.FluentValidation.BookValidator;
using MediatR;

namespace BookHive.Application.Features.Commands.Book.CreateBook
{
    public class CreateBookCommandHandler : IRequestHandler<CreateBookCommandRequest, CreateBookCommandResponse>
    {
        private readonly IBookWriteRepository bookWriteRepository;
        private readonly IBookRuleService bookRuleService;
        private readonly IMapper mapper;
        public CreateBookCommandHandler(IBookWriteRepository bookWriteRepository, IBookRuleService bookRuleService, IMapper mapper)
        {
            this.bookWriteRepository = bookWriteRepository; 
            this.bookRuleService = bookRuleService;
            this.mapper = mapper;
        }


        public async Task<CreateBookCommandResponse> Handle(CreateBookCommandRequest request, CancellationToken cancellationToken)
        {
            var validationResult = await new BookAddValidator().ValidateAsync(request.BookAddDto);
            if (!validationResult.IsValid)
            {
                return new CreateBookCommandResponse
                {
                    Result = new Parametres.ResponseParametres.Result
                    {
                        Success = false,
                        Message = validationResult.ValidationErrorString()
                    }
                };
            }

            var result = BusinessRules.Run(bookRuleService.CheckIfISBNExisted(request.BookAddDto.ISBN));
            if(!result.Success)
            {
                return new CreateBookCommandResponse
                {
                    Result = result
                };
            }

            BookHive.Domain.Entities.Book book = mapper.Map<BookHive.Domain.Entities.Book>(request.BookAddDto);

            await bookWriteRepository.AddAsync(book);
            await bookWriteRepository.SaveAsync();

            return new CreateBookCommandResponse
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
