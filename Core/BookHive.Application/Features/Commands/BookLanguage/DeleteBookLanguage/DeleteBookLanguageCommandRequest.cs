

using BookHive.Application.Features.Commands.BookLanguage;
using MediatR;

namespace BookHive.Application.Features.Commands.BookLanguage
{
    public class DeleteBookLanguageCommandRequest : IRequest<DeleteBookLanguageCommandResponse>
    {
        public Guid Id { get; set; }    
    }
}
