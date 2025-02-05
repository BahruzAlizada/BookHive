using AutoMapper;
using BookHive.Application.Abstracts.Services.Dapper;
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
        private readonly IPublisherReadDapper publisherReadDapper;
        public GetAllPublisherQueryHandler(IPublisherReadDapper publisherReadDapper)
        {
            this.publisherReadDapper = publisherReadDapper;
        }


        public async Task<GetAllPublisherQueryResponse> Handle(GetAllPublisherQueryRequest request, CancellationToken cancellationToken)
        {
            List<BookHive.Domain.Entities.Publisher> publishers = await publisherReadDapper.GetPublishersAsync();
            List<PublisherDto> publisherDtos = publishers.Adapt<List<PublisherDto>>();

            return new GetAllPublisherQueryResponse { PublisherDtos = publisherDtos, Result = new SuccessResult(Messages.SuccessListed) };
        }
    }
}
