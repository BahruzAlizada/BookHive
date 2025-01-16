using MediatR;

namespace BookHive.Application.Features.Queries.BookStatus.GetByIdBookStatus
{
    public class GetByIdBookStatusQueryRequest : IRequest<GetByIdBookStatusQueryResponse>
    {
        public Guid Id { get; set; }
    }
}
