
using MediatR;

namespace BookHive.Application.Features.Commands.Author.DeleteAuthor
{
    public class DeleteAuthorCommandRequest : IRequest<DeleteAuthorCommandResponse>
    {
        public Guid Id { get; set; }
    }
}
