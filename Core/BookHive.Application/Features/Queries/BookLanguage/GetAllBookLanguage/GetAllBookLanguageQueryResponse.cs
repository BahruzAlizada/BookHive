
using BookHive.Application.DTOs;
using BookHive.Application.Parametres.ResponseParametres;

namespace BookHive.Application.Features.Queries.BookLanguage
{
    public class GetAllBookLanguageQueryResponse
    {
        public List<BookLanguageDto> BookLanguages { get; set; }
        public Result Result { get; set; }
    }
}
