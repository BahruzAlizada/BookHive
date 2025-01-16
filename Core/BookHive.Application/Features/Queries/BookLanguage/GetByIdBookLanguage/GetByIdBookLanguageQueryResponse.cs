using BookHive.Application.DTOs;
using BookHive.Application.Parametres.ResponseParametres;

namespace BookHive.Application.Features.Queries.BookLanguage.GetByIdBookLanguage
{
    public class GetByIdBookLanguageQueryResponse
    {
        public BookLanguageDto? BookLanguageDto { get; set; }
        public Result Result { get; set; }
    }
}
