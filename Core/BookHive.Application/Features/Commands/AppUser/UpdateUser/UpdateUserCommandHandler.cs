using BookHive.Application.Constants;
using BookHive.Application.Exceptions;
using BookHive.Application.Extensions.FluentValidationExtension;
using BookHive.Application.Features.Commands.AppUser.RegisterUser;
using BookHive.Application.Parametres.ResponseParametres;
using BookHive.Application.Validation.FluentValidation.UserValidator;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace BookHive.Application.Features.Commands.AppUser.UpdateUser
{
    public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommandRequest, UpdateUserCommandResponse>
    {
        private readonly UserManager<BookHive.Domain.Identity.AppUser> userManager;
        public UpdateUserCommandHandler(UserManager<BookHive.Domain.Identity.AppUser> userManager)
        {
            this.userManager = userManager;
        }


        public async Task<UpdateUserCommandResponse> Handle(UpdateUserCommandRequest request, CancellationToken cancellationToken)
        {
            BookHive.Domain.Identity.AppUser? user = await userManager.FindByNameAsync(request.UserUpdateDto.UserName);
            if (user == null)
                throw new UserNotFoundException();

            var validationResult = await new UserUpdateValidator().ValidateAsync(request.UserUpdateDto);
            if (!validationResult.IsValid)
            {
                return new UpdateUserCommandResponse
                {
                    Result = new Result
                    {
                        Success = false,
                        Message = validationResult.ValidationErrorString()
                    }
                };
            }

            user.FullName = request.UserUpdateDto.FullName;
            user.UserName = request.UserUpdateDto.UserName;
            user.Email = request.UserUpdateDto.Email;

            IdentityResult identityResult = await userManager.UpdateAsync(user);
            if (!identityResult.Succeeded)
            {
                string errorMessages = string.Join("; ", identityResult.Errors.Select(e => e.Description));
                return new UpdateUserCommandResponse
                {
                    Result = new Parametres.ResponseParametres.Result
                    {
                        Message = errorMessages,
                        Success = false
                    }
                };
            }

            return new UpdateUserCommandResponse
            {
                Result = new Parametres.ResponseParametres.Result
                {
                    Success = true,
                    Message = Messages.SuccessUpdated
                }
            };

        }
    }
}
