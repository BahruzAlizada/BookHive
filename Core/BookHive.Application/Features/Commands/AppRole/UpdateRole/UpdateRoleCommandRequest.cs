using BookHive.Application.DTOs;
using MediatR;

namespace BookHive.Application.Features.Commands.AppRole.UpdateRole
{
    public class UpdateRoleCommandRequest : IRequest<UpdateRoleCommandResponse>
    {
        public RoleUpdateDto RoleUpdateDto { get; set; }
    }
}