using MediatR;

namespace BookHive.Application.Features.Queries.Book.GetBookStatistic
{
    public class GetBookStatisticQueryRequest : IRequest<GetBookStatisticQueryResponse>
    {
        public Guid BookId { get; set; }
    }
}