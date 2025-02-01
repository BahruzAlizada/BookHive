using System.Net.Http.Headers;
using AutoMapper;
using BookHive.Application.Abstracts.Services;
using BookHive.Application.Constants;
using BookHive.Application.DTOs;
using BookHive.Application.Extensions.FluentValidationExtension;
using BookHive.Application.Parametres.ResponseParametres;
using BookHive.Application.Rule;
using BookHive.Application.Rules.Abstract;
using BookHive.Application.Validation.FluentValidation.BookValidator;
using Mapster;
using MediatR;

namespace BookHive.Application.Features.Commands.Book.UpdateBook
{
    public class UpdateBookCommandHandler : IRequestHandler<UpdateBookCommandRequest, UpdateBookCommandResponse>
    {
        private readonly IBookWriteRepository bookWriteRepository;
        private readonly IBookRuleService bookRuleService;
        public UpdateBookCommandHandler(IBookWriteRepository bookWriteRepository, IBookRuleService bookRuleService)
        {
            this.bookWriteRepository = bookWriteRepository;
            this.bookRuleService = bookRuleService;
        }


        public async Task<UpdateBookCommandResponse> Handle(UpdateBookCommandRequest request, CancellationToken cancellationToken)
        {
            var validationResult = await ValidationExtension.ValidatorResult(new BookUpdateValidator(), request.BookUpdateDto);
            if (!validationResult.Success) return new() { Result = validationResult };


            var result = await CheckBusinessRules(request.BookUpdateDto);
            if (!result.Success) return new() { Result = result };

            var book = request.BookUpdateDto.Adapt<BookHive.Domain.Entities.Book>();
            bookWriteRepository.Update(book);
            await bookWriteRepository.SaveAsync();

            return new UpdateBookCommandResponse { Result = new SuccessResult(Messages.SuccessUpdated) };
        }


        private async Task<Result> CheckBusinessRules(BookUpdateDto bookUpdateDto)
        {
            var result = BusinessRules.Run
                (
                    bookRuleService.CheckIfISBNExisted(bookUpdateDto.ISBN,bookUpdateDto.Id),
                    bookRuleService.CheckPrice(bookUpdateDto.Price),
                    bookRuleService.CheckQuantity(bookUpdateDto.Quantity),
                    bookRuleService.CheckPages(bookUpdateDto.Pages),
                    bookRuleService.CheckBookLanguage((int)bookUpdateDto.BookLanguage),
                    await bookRuleService.CheckAuthorId(bookUpdateDto.AuthorId),
                    await bookRuleService.CheckGenreId(bookUpdateDto.GenreId),
                    await bookRuleService.CheckPublisherId(bookUpdateDto.PublisherId)
                );
            if (!result.Success) return result;

            return new Result { Success = true };
        }

    }
}
