using System.Diagnostics;
using System.Text;
using BookHive.Application.Exceptions;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;

namespace BookHive.Application.Features.Commands.AppUser.VerifyResetToken
{
    public class VerifyResetTokenCommandHandler : IRequestHandler<VerifyResetTokenCommandRequest, VerifyResetTokenCommandResponse>
    {
        private readonly UserManager<BookHive.Domain.Identity.AppUser> userManager;
        public VerifyResetTokenCommandHandler(UserManager<BookHive.Domain.Identity.AppUser> userManager)
        {
            this.userManager = userManager;
        }


        public async Task<VerifyResetTokenCommandResponse> Handle(VerifyResetTokenCommandRequest request, CancellationToken cancellationToken)
        {
            BookHive.Domain.Identity.AppUser? user = await userManager.Users.FirstOrDefaultAsync(x=> x.Id == request.UserId);
            if (user == null)
                throw new UserNotFoundException();

            byte[] tokenBytes = WebEncoders.Base64UrlDecode(request.ResetToken);
            request.ResetToken = Encoding.UTF8.GetString(tokenBytes);

            bool result = await userManager.VerifyUserTokenAsync(user, userManager.Options.Tokens.PasswordResetTokenProvider, "ResetToken", request.ResetToken);
            if (result)
            {
                return new VerifyResetTokenCommandResponse
                {
                    Result = new Parametres.ResponseParametres.Result
                    {
                        Success = true,
                        Message = "Verify Reset Token"
                    },
                    State = result
                };
            }
            else
            {
                return new VerifyResetTokenCommandResponse
                {
                    Result = new Parametres.ResponseParametres.Result
                    {
                        Success = false,
                        Message = "Not verify reset token"
                    }
                };
            }
        }
    }
}
