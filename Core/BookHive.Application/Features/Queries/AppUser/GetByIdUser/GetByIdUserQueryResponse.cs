using BookHive.Application.DTOs;
using BookHive.Application.Parametres.ResponseParametres;

namespace BookHive.Application.Features.Queries.AppUser.GetByIdUser
{
    public class GetByIdUserQueryResponse
    {
        public Result Result { get; set; }
        public UserDto? UserDto { get; set; }
    }
}
