
using BookHive.Application.DTOs;
using MediatR;

namespace BookHive.Application.Features.Commands.AppUser.UpdateUser
{
    public class UpdateUserCommandRequest : IRequest<UpdateUserCommandResponse>
    {
        public UserUpdateDto UserUpdateDto { get; set; }
    }
}
