using AutoMapper;
using BookHive.Application.Abstracts.Services;
using BookHive.Application.ConstMessages;
using BookHive.Application.DTOs;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BookHive.Application.Features.Queries.Publisher.GetAllPublisher
{
    public class GetAllPublisherQueryHandler : IRequestHandler<GetAllPublisherQueryRequest, GetAllPublisherQueryResponse>
    {
        private readonly IPublisherReadRepository publisherReadRepository;
        public GetAllPublisherQueryHandler(IPublisherReadRepository publisherReadRepository, IMapper mapper)
        {
            this.publisherReadRepository = publisherReadRepository;
        }


        public async Task<GetAllPublisherQueryResponse> Handle(GetAllPublisherQueryRequest request, CancellationToken cancellationToken)
        {
            List<PublisherDto> publishers = await publisherReadRepository.GetPublisherDtosAsync();
            return new GetAllPublisherQueryResponse
            {
                PublisherDtos = publishers,
                Result = new Parametres.ResponseParametres.Result
                {
                    Success = true,
                    Message = Messages.SuccessListed
                }
            };
        }
    }
}
