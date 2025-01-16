
using BookHive.Application.DTOs;
using MediatR;

namespace BookHive.Application.Features.Commands.Publisher.UpdatePublisher
{
    public class UpdatePublisherCommandRequest : IRequest<UpdatePublisherCommandResponse>
    {
        public PublisherUpdateDto PublisherUpdateDto { get; set; }
    }
}
