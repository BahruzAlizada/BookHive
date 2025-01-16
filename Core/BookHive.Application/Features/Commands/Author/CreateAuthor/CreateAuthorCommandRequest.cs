
using BookHive.Application.DTOs;
using MediatR;

namespace BookHive.Application.Features.Commands.Author.CreateAuthor
{
    public class CreateAuthorCommandRequest : IRequest<CreateAuthorCommandResponse>
    {
        public AuthorAddDto AuthorAddDto { get; set; }
    }
}
