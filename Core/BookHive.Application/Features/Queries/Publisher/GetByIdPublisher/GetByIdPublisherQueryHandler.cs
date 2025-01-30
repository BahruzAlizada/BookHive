using BookHive.Application.Abstracts.Services;
using BookHive.Application.Constants;
using BookHive.Application.DTOs;
using BookHive.Application.Parametres.ResponseParametres;
using Mapster;
using MediatR;

namespace BookHive.Application.Features.Queries.Publisher.GetByIdPublisher
{
    public class GetByIdPublisherQueryHandler : IRequestHandler<GetByIdPublisheQueryRequest, GetByIdPublisherQueryResponse>
    {
        private readonly IPublisherReadRepository publisherReadRepository;
        public GetByIdPublisherQueryHandler(IPublisherReadRepository publisherReadRepository)
        {
            this.publisherReadRepository = publisherReadRepository;
        }


        public async Task<GetByIdPublisherQueryResponse> Handle(GetByIdPublisheQueryRequest request, CancellationToken cancellationToken)
        {
            BookHive.Domain.Entities.Publisher? publisher = await publisherReadRepository.GetFindAsync(request.Id);
            if (publisher == null) return new() { Result = new ErrorResult(Messages.IdNull) };

            PublisherDto publisherDto = publisher.Adapt<PublisherDto>();
            return new GetByIdPublisherQueryResponse { PublisherDto = publisherDto, Result = new SuccessResult(Messages.SuccessGetFiltered) };
        }
    }
}
