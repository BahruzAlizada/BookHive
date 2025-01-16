

using BookHive.Application.DTOs;
using MediatR;

namespace BookHive.Application.Features.Commands.AppUser.UpdatePassword
{
    public class UpdatePasswordCommandRequest : IRequest<UpdatePasswordCommandResponse>
    {
        public UpdatePasswordDto UpdatePassword { get; set; }
    }
}
