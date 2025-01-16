
using BookHive.Application.DTOs;
using MediatR;

namespace BookHive.Application.Features.Commands.Author.UpdateAuthor
{
    public class UpdateAuthorCommandRequest : IRequest<UpdateAuthorCommandResponse>
    {
        public AuthorUpdateDto AuthorUpdateDto { get; set; }    
    }
}
