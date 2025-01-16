using BookHive.Application.DTOs;
using MediatR;

namespace BookHive.Application.Features.Commands.BookLanguage
{
    public class UpdateBookLanguageCommandRequest : IRequest<UpdateBookLanguageCommandResponse>
    {
        public BookLanguageUpdateDto BookLanguageUpdateDto { get; set; }
    }
}
