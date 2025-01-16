using BookHive.Application.DTOs;
using MediatR;

namespace BookHive.Application.Features.Commands.BookLanguage
{
    public class CreateBookLanguageCommandRequest : IRequest<CreateBookLanguageCommandResponse>
    {
        public BookLanguageAddDto BookLanguageAddDto { get; set; }
    }
}
