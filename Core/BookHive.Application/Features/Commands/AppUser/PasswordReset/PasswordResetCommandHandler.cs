
using System.Text;
using BookHive.Application.Abstracts.Services;
using BookHive.Application.Exceptions;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Identity.Client;

namespace BookHive.Application.Features.Commands.AppUser.PasswordReset
{
    public class PasswordResetCommandHandler : IRequestHandler<PasswordResetCommandRequest, PasswordResetCommandResponse>
    {
        private readonly UserManager<BookHive.Domain.Identity.AppUser> userManager;
        private readonly IMailService mailService;
        public PasswordResetCommandHandler(UserManager<BookHive.Domain.Identity.AppUser> userManager, IMailService mailService)
        {
            this.userManager = userManager;
            this.mailService = mailService;
        }


        public async Task<PasswordResetCommandResponse> Handle(PasswordResetCommandRequest request, CancellationToken cancellationToken)
        {
            BookHive.Domain.Identity.AppUser? user = await userManager.FindByEmailAsync(request.Email);
            if (user == null)
                throw new UserNotFoundException();

            string resetToken = await userManager.GeneratePasswordResetTokenAsync(user);

            byte[] tokenBytes = Encoding.UTF8.GetBytes(resetToken);
            resetToken = WebEncoders.Base64UrlEncode(tokenBytes);

            await mailService.SendPasswordResetMailAsync(request.Email, user.Id, resetToken);
            return new PasswordResetCommandResponse
            {
                Result = new Parametres.ResponseParametres.Result
                {
                    Success = true,
                    Message = "Succes"
                }
            };
        }
    }
}
