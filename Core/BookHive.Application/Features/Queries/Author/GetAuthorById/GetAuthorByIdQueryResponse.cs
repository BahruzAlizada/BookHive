
using BookHive.Application.DTOs;
using BookHive.Application.Parametres.ResponseParametres;

namespace BookHive.Application.Features.Queries.Author.GetAuthorById
{
    public class GetAuthorByIdQueryResponse
    {
        public AuthorDto? AuthorDto { get; set; }
        public Result Result { get; set; }
    }
}
