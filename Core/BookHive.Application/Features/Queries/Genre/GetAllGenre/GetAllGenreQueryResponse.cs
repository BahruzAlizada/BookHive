

using BookHive.Application.DTOs;
using BookHive.Application.Parametres.ResponseParametres;

namespace BookHive.Application.Features.Queries.Genre.GetAllGenre
{
    public class GetAllGenreQueryResponse
    {
        public List<GenreDto> GenreDtos { get; set; }
        public Result Result { get; set; }
    }
}
