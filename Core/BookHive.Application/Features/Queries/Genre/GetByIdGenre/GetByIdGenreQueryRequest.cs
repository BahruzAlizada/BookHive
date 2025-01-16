using MediatR;

namespace BookHive.Application.Features.Queries.Genre.GetByIdGenre
{
    public class GetByIdGenreQueryRequest : IRequest<GetByIdGenreQueryResponse>
    {
        public Guid Id { get; set; }
    }
}
