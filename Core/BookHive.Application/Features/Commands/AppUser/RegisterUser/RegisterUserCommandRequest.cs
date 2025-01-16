
using BookHive.Application.DTOs;
using MediatR;

namespace BookHive.Application.Features.Commands.AppUser.RegisterUser
{
    public class RegisterUserCommandRequest : IRequest<RegisterUserCommandResponse>
    {
        public RegisterUserDto RegisterUserDto { get; set; }
    }
}
