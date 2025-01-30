using BookHive.Application.Constants;
using BookHive.Application.Exceptions;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace BookHive.Application.Features.Commands.AppUser.DeleteUser
{
    public class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommandRequest, DeleteUserCommandResponse>
    {
        private readonly UserManager<BookHive.Domain.Identity.AppUser> userManager;
        public DeleteUserCommandHandler(UserManager<BookHive.Domain.Identity.AppUser> userManager)
        {
            this.userManager = userManager;
        }


        public async Task<DeleteUserCommandResponse> Handle(DeleteUserCommandRequest request, CancellationToken cancellationToken)
        {
            BookHive.Domain.Identity.AppUser? user = await userManager.FindByNameAsync(request.UserName);
            if (user == null)
            {
                throw new UserNotFoundException();
            }

            await userManager.DeleteAsync(user);
            return new DeleteUserCommandResponse
            {
                Result = new Parametres.ResponseParametres.Result
                {
                    Success = true,
                    Message = Messages.SuccessDeleted
                }
            };

        }
    }
}
