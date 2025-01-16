using MediatR;

namespace BookHive.Application.Features.Queries.Book.GetByIdBook
{
    public class GetByIdBookQueryRequest : IRequest<GetByIdBookQueryResponse>
    {
        public Guid Id { get; set; }
    }
}
