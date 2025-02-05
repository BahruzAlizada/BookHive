using BookHive.Application.Abstracts.Services.Dapper;
using BookHive.Application.Abstracts.Services.EntityFramework;
using BookHive.Application.Constants;
using BookHive.Application.DTOs;
using BookHive.Application.Parametres.ResponseParametres;
using Mapster;
using MediatR;

namespace BookHive.Application.Features.Queries.Publisher.GetByIdPublisher
{
    public class GetByIdPublisherQueryHandler : IRequestHandler<GetByIdPublisheQueryRequest, GetByIdPublisherQueryResponse>
    {
        private readonly IPublisherReadDapper publisherReadDapper;
        public GetByIdPublisherQueryHandler(IPublisherReadDapper publisherReadDapper)
        {
            this.publisherReadDapper = publisherReadDapper;
        }


        public async Task<GetByIdPublisherQueryResponse> Handle(GetByIdPublisheQueryRequest request, CancellationToken cancellationToken)
        {
            BookHive.Domain.Entities.Publisher? publisher = await publisherReadDapper.GetPublisherAsync(request.Id);
            if (publisher == null) return new() { Result = new ErrorResult(Messages.IdNull) };

            PublisherDto publisherDto = publisher.Adapt<PublisherDto>();
            return new GetByIdPublisherQueryResponse { PublisherDto = publisherDto, Result = new SuccessResult(Messages.SuccessGetFiltered) };
        }
    }
}
