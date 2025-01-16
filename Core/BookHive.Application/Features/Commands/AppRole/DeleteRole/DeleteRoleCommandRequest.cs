using MediatR;

namespace BookHive.Application.Features.Commands.AppRole.DeleteRole
{
    public class DeleteRoleCommandRequest : IRequest<DeleteRoleCommandResponse>
    {
        public Guid Id { get; set; }
    }
}