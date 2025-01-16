
using MediatR;

namespace BookHive.Application.Features.Commands.Book.DeleteBook
{
    public class DeleteBookCommandRequest : IRequest<DeleteBookCommandResponse>
    {
        public Guid Id { get; set; }
    }
}
