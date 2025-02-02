using AutoMapper;
using BookHive.Application.Abstracts.Services.EntityFramework;
using BookHive.Application.Constants;
using BookHive.Application.DTOs;
using BookHive.Application.Parametres.ResponseParametres;
using Mapster;
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
            List<BookHive.Domain.Entities.Publisher> publishers = await publisherReadRepository.GetAll().ToListAsync();
            List<PublisherDto> publisherDtos = publishers.Adapt<List<PublisherDto>>();

            return new GetAllPublisherQueryResponse { PublisherDtos = publisherDtos, Result = new SuccessResult(Messages.SuccessListed) };
        }
    }
}
