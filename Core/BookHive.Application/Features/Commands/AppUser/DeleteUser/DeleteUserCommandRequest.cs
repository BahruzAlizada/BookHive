using MediatR;

namespace BookHive.Application.Features.Commands.AppUser.DeleteUser
{
    public class DeleteUserCommandRequest : IRequest<DeleteUserCommandResponse>
    {
        public string UserName { get; set; }
    }
}
