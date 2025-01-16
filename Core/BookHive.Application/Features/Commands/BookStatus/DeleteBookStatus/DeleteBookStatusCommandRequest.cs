using MediatR;

namespace BookHive.Application.Features.Commands.BookStatus.DeleteBookStatus
{
    public class DeleteBookStatusCommandRequest : IRequest<DeleteBookStatusCommandResponse>
    {
        public Guid Id { get; set; }
    }
}
