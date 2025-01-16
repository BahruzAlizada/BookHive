using BookHive.Application.DTOs;
using MediatR;

namespace BookHive.Application.Features.Commands.AppUser.LoginUser
{
    public class LoginUserCommandRequest : IRequest<LoginUserCommandResponse>
    {
        public LoginUserDto LoginUserDto { get; set; }
    }
}
