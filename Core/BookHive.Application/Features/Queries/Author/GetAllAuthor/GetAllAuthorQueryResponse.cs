using BookHive.Application.DTOs;
using BookHive.Application.Parametres.ResponseParametres;

namespace BookHive.Application.Features.Queries.Author.GetAllAuthor
{
    public class GetAllAuthorQueryResponse
    {
        public List<AuthorDto> AuthorDtos { get; set; }
        public Result Result { get; set; }
    }
}
