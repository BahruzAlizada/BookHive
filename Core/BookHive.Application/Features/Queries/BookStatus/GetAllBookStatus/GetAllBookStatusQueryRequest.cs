using BookHive.Application.DTOs;
using MediatR;

namespace BookHive.Application.Features.Queries.BookStatus.GetAllBookStatus
{
    public class GetAllBookStatusQueryRequest : IRequest<GetAllBookStatusQueryResponse>
    {
    }
}
