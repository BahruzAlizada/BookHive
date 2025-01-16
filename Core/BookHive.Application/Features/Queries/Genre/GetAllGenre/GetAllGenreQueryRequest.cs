

using MediatR;

namespace BookHive.Application.Features.Queries.Genre.GetAllGenre
{
    public class GetAllGenreQueryRequest : IRequest<GetAllGenreQueryResponse>
    {
        public Guid? categoryId { get; set; }
    }
}
