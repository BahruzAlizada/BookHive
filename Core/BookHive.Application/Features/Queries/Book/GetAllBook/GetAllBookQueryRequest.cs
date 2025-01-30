using BookHive.Application.DTOs;
using BookHive.Application.Parametres.RequestParametres;
using MediatR;

namespace BookHive.Application.Features.Queries.Book.GetAllBook
{
    public class GetAllBookQueryRequest : IRequest<GetAllBookQueryResponse>
    {
    }
}
