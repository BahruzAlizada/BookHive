
using MediatR;

namespace BookHive.Application.Features.Queries.BookLanguage.GetByIdBookLanguage
{
    public class GetByIdBookLanguageQueryRequest : IRequest<GetByIdBookLanguageQueryResponse>
    {
        public Guid Id { get; set; }
    }
}
