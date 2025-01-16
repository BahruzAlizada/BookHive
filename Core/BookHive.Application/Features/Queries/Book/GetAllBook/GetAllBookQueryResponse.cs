
using BookHive.Application.DTOs.Book;
using BookHive.Application.Parametres.ResponseParametres;

namespace BookHive.Application.Features.Queries.Book.GetAllBook
{
    public class GetAllBookQueryResponse
    {
        public List<BookDto> BookDtos { get; set; }
        public Result Result { get; set; }
    }
}
