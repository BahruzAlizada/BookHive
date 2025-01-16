using BookHive.Application.DTOs;
using MediatR;

namespace BookHive.Application.Features.Commands.Publisher.CreatePublisher
{
    public class CreatePublisherCommandRequest : IRequest<CreatePublisherCommandResponse>
    {
        public PublisherAddDto PublisherAddDto { get; set; }
    }
}
