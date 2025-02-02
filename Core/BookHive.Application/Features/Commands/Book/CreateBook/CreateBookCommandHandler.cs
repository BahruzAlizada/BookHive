using BookHive.Application.Abstracts.Services.EntityFramework;
using BookHive.Application.Constants;
using BookHive.Application.DTOs;
using BookHive.Application.Extensions.FluentValidationExtension;
using BookHive.Application.Parametres.ResponseParametres;
using BookHive.Application.Rule;
using BookHive.Application.Rules.Abstract;
using BookHive.Application.Validation.FluentValidation.BookValidator;
using Mapster;
using MediatR;

namespace BookHive.Application.Features.Commands.Book.CreateBook
{
    public class CreateBookCommandHandler : IRequestHandler<CreateBookCommandRequest, CreateBookCommandResponse>
    {
        private readonly IBookWriteRepository bookWriteRepository;
        private readonly IBookRuleService bookRuleService;
        public CreateBookCommandHandler(IBookWriteRepository bookWriteRepository, IBookRuleService bookRuleService)
        {
            this.bookWriteRepository = bookWriteRepository; 
            this.bookRuleService = bookRuleService;
        }


        public async Task<CreateBookCommandResponse> Handle(CreateBookCommandRequest request, CancellationToken cancellationToken)
        {
            var validationResult = await ValidationExtension.ValidatorResult(new BookAddValidator(), request.BookAddDto);
            if (!validationResult.Success) return new() { Result = validationResult };

     
            var result = await CheckBusinessRules(request.BookAddDto);
            if(!result.Success) return new() { Result = result };

            
            await bookWriteRepository.AddBookAsync(request.BookAddDto);
            return new CreateBookCommandResponse() { Result = new SuccessResult(Messages.SuccessAdded) };
        }



        private async Task<Result> CheckBusinessRules(BookAddDto bookAddDto)
        {
            var result = BusinessRules.Run
                (
                    bookRuleService.CheckIfISBNExisted(bookAddDto.ISBN),
                    bookRuleService.CheckPrice(bookAddDto.Price),
                    bookRuleService.CheckQuantity(bookAddDto.Quantity),
                    bookRuleService.CheckPages(bookAddDto.Pages),
                    bookRuleService.CheckBookLanguage((int)bookAddDto.BookLanguage),
                    await bookRuleService.CheckAuthorId(bookAddDto.AuthorId),
                    await bookRuleService.CheckGenreId(bookAddDto.GenreId),
                    await bookRuleService.CheckPublisherId(bookAddDto.PublisherId)
                );
            if (!result.Success) return result;

            return new Result { Success = true };
        }

    }
}
