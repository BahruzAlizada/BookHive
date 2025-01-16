
using BookHive.Application.DTOs.Book;
using BookHive.Application.Parametres.ResponseParametres;

namespace BookHive.Application.Features.Queries.Book.GetByIdBook
{
    public class GetByIdBookQueryResponse
    {
        public BookDto? BookDto { get; set; }
        public Result Result { get; set; }
    }
}
