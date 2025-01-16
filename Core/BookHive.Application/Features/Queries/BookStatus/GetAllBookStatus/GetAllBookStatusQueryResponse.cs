using BookHive.Application.DTOs;
using BookHive.Application.Parametres.ResponseParametres;

namespace BookHive.Application.Features.Queries.BookStatus.GetAllBookStatus
{
    public class GetAllBookStatusQueryResponse
    {
        public List<BookStatusDto> bookStatusDtos { get; set; }
        public Result Result { get; set; }
    }
}
