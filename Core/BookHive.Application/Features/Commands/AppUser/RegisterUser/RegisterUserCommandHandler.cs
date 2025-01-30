using BookHive.Application.Constants;
using BookHive.Application.Extensions.FluentValidationExtension;
using BookHive.Application.Validation.FluentValidation.UserValidator;
using BookHive.Domain.Identity;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace BookHive.Application.Features.Commands.AppUser.RegisterUser
{
    public class RegisterUserCommandHandler : IRequestHandler<RegisterUserCommandRequest, RegisterUserCommandResponse>
    {
        private readonly UserManager<BookHive.Domain.Identity.AppUser> userManager;
        public RegisterUserCommandHandler(UserManager<BookHive.Domain.Identity.AppUser> userManager)
        {
            this.userManager = userManager;
        }


        public async Task<RegisterUserCommandResponse> Handle(RegisterUserCommandRequest request, CancellationToken cancellationToken)
        {
            var validationResult = await new RegisterUserValidator().ValidateAsync(request.RegisterUserDto);
            if (!validationResult.IsValid)
            {
                return new RegisterUserCommandResponse
                {
                    Result = new Parametres.ResponseParametres.Result
                    {
                        Success = false,
                        Message = validationResult.ValidationErrorString()
                    }
                };
            }

            BookHive.Domain.Identity.AppUser user = new BookHive.Domain.Identity.AppUser
            {
                FullName = request.RegisterUserDto.FullName,
                UserName = request.RegisterUserDto.UserName,
                Email = request.RegisterUserDto.Email,
            };

            IdentityResult result = await userManager.CreateAsync(user, request.RegisterUserDto.Password);
            if (!result.Succeeded)
            {
                string errorMessages = string.Join("; ", result.Errors.Select(e => e.Description));
                return new RegisterUserCommandResponse
                {
                    Result = new Parametres.ResponseParametres.Result 
                    { 
                        Message = errorMessages,
                        Success = false 
                    }
                };
            }


            return new RegisterUserCommandResponse
            {
                Result = new Parametres.ResponseParametres.Result
                {
                    Success = true,
                    Message = Messages.SuccessRegister
                }
            };
        }
    }
}
