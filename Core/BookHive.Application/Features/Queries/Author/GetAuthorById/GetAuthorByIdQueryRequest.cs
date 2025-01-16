using MediatR;

namespace BookHive.Application.Features.Queries.Author.GetAuthorById
{
    public class GetAuthorByIdQueryRequest : IRequest<GetAuthorByIdQueryResponse>
    {
        public Guid Id { get; set; }
    }
}
