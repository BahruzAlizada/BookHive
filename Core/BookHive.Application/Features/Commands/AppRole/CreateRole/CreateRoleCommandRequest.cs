using BookHive.Application.DTOs;
using MediatR;

namespace BookHive.Application.Features.Commands.AppRole.CreateRole
{
    public class CreateRoleCommandRequest : IRequest<CreateRoleCommandResponse>
    {
        public RoleAddDto RoleAddDto { get; set; }
    }
}