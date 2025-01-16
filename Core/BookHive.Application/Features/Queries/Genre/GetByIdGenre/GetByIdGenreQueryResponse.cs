
using BookHive.Application.DTOs;
using BookHive.Application.Parametres.ResponseParametres;

namespace BookHive.Application.Features.Queries.Genre.GetByIdGenre
{
    public class GetByIdGenreQueryResponse
    {
        public GenreDto? GenreDto { get; set; }
        public Result Result { get; set; }
    }
}
