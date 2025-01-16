

using BookHive.Application.DTOs;
using BookHive.Application.Parametres.ResponseParametres;

namespace BookHive.Application.Features.Commands.AppUser.RefreshTokenLogin
{
    public class RefreshTokenLoginCommandResponse
    {
        public Result Result { get; set; }
        public TokenDto TokenDto { get; set; }
        public string UserName { get; set; }
    }
}
