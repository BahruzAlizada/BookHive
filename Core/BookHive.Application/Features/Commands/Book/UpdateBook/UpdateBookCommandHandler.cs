
using System.Net.Http.Headers;
using AutoMapper;
using BookHive.Application.Abstracts.Services;
using BookHive.Application.ConstMessages;
using BookHive.Application.Extensions.FluentValidationExtension;
using BookHive.Application.Rule;
using BookHive.Application.Rules.Abstract;
using BookHive.Application.Validation.FluentValidation.BookValidator;
using MediatR;

namespace BookHive.Application.Features.Commands.Book.UpdateBook
{
    public class UpdateBookCommandHandler : IRequestHandler<UpdateBookCommandRequest, UpdateBookCommandResponse>
    {
        private readonly IBookWriteRepository bookWriteRepository;
        private readonly IBookRuleService bookRuleService;
        private readonly IMapper mapper;
        public UpdateBookCommandHandler(IBookWriteRepository bookWriteRepository, IBookRuleService bookRuleService, IMapper mapper)
        {
            this.bookWriteRepository = bookWriteRepository;
            this.bookRuleService = bookRuleService;
            this.mapper = mapper;
        }


        public async Task<UpdateBookCommandResponse> Handle(UpdateBookCommandRequest request, CancellationToken cancellationToken)
        {
            var validationResult = await new BookUpdateValidator().ValidateAsync(request.BookUpdateDto);
            if (!validationResult.IsValid)
            {
                return new UpdateBookCommandResponse
                {
                    Result = new Parametres.ResponseParametres.Result
                    {
                        Success = false,
                        Message = validationResult.ValidationErrorString()
                    }
                };
            }

            var result = BusinessRules.Run(bookRuleService.CheckIfISBNExisted(request.BookUpdateDto.ISBN, request.BookUpdateDto.Id));
            if(!result.Success)
            {
                return new UpdateBookCommandResponse
                {
                    Result = result
                };
            }

            var book = mapper.Map<BookHive.Domain.Entities.Book>(request.BookUpdateDto);

            bookWriteRepository.Update(book);
            await bookWriteRepository.SaveAsync();

            return new UpdateBookCommandResponse
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
