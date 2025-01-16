using MediatR;

namespace BookHive.Application.Features.Commands.Publisher.DeletePublisher
{
    public class DeletePublisherCommandRequest : IRequest<DeletePublisherCommandResponse>
    {
        public Guid Id { get; set; }
    }
}
