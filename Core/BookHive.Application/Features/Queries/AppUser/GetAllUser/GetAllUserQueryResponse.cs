using BookHive.Application.DTOs;
using BookHive.Application.Parametres.ResponseParametres;

namespace BookHive.Application.Features.Queries.AppUser.GetAllUser
{
    public class GetAllUserQueryResponse
    {
        public List<UserDto>? UserDtos { get; set; }
        public Result Result { get; set; }
    }
}
