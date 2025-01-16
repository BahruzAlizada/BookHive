using MediatR;

namespace BookHive.Application.Features.Queries.Publisher.GetByIdPublisher
{
    public class GetByIdPublisheQueryRequest : IRequest<GetByIdPublisherQueryResponse>
    {
        public Guid Id { get; set; }
    }
}
