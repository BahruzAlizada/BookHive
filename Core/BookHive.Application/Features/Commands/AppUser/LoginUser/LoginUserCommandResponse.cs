

using BookHive.Application.DTOs;
using BookHive.Application.Parametres.ResponseParametres;

namespace BookHive.Application.Features.Commands.AppUser.LoginUser
{
    public class LoginUserCommandResponse
    {
        public Result Result { get; set; }
        public TokenDto? tokenDto { get; set; }
    }
}
