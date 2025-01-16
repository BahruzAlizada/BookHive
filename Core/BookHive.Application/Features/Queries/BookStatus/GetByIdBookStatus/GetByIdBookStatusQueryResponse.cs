using BookHive.Application.DTOs;
using BookHive.Application.Parametres.ResponseParametres;

namespace BookHive.Application.Features.Queries.BookStatus.GetByIdBookStatus
{
    public class GetByIdBookStatusQueryResponse
    {
        public BookStatusDto? BookStatusDto { get; set; }
        public Result Result { get; set; }
    }
}
