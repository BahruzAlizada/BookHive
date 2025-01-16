using System.Text;
using BookHive.Application.Exceptions;
using BookHive.Application.Extensions.FluentValidationExtension;
using BookHive.Application.Validation.FluentValidation.UserValidator;
using BookHive.Domain.Identity;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.EntityFrameworkCore;

namespace BookHive.Application.Features.Commands.AppUser.UpdatePassword
{
    public class UpdatePasswordCommandHandler : IRequestHandler<UpdatePasswordCommandRequest, UpdatePasswordCommandResponse>
    {
        private readonly UserManager<BookHive.Domain.Identity.AppUser> userManager;
        public UpdatePasswordCommandHandler(UserManager<BookHive.Domain.Identity.AppUser> userManager)
        {
            this.userManager = userManager;
        }


        public async Task<UpdatePasswordCommandResponse> Handle(UpdatePasswordCommandRequest request, CancellationToken cancellationToken)
        {
            var validationResult = await new UpdatePasswordValidator().ValidateAsync(request.UpdatePassword);
            if (!validationResult.IsValid)
            {
                return new UpdatePasswordCommandResponse
                {
                    Result = new Parametres.ResponseParametres.Result
                    {
                        Success = false,
                        Message = validationResult.ValidationErrorString()
                    }
                };
            }

            if (!request.UpdatePassword.Password.Equals(request.UpdatePassword.PasswordConfirm))
            {
                return new UpdatePasswordCommandResponse
                {
                    Result = new Parametres.ResponseParametres.Result
                    {
                        Success = false,
                        Message = "Password and Password confirm must equal each other."
                    }
                };
            }

            BookHive.Domain.Identity.AppUser? user = await userManager.Users.FirstOrDefaultAsync(x => x.Id == request.UpdatePassword.UserId);
            if (user == null)
                throw new UserNotFoundException();

            byte[] bytes = WebEncoders.Base64UrlDecode(request.UpdatePassword.ResetToken);
            request.UpdatePassword.ResetToken = Encoding.UTF8.GetString(bytes);

            IdentityResult identityResult = await userManager.ResetPasswordAsync(user, request.UpdatePassword.ResetToken, request.UpdatePassword.Password);
            if (!identityResult.Succeeded)
                throw new PasswordChangeFailedException();

            await userManager.UpdateSecurityStampAsync(user);
            return new UpdatePasswordCommandResponse
            {
                Result = new Parametres.ResponseParametres.Result
                {
                    Success = true,
                    Message = "Success Password Update"
                }
            };
        }
    }
}
