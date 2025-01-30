using BookHive.Application.Abstracts;
using BookHive.Application.Constants;
using BookHive.Application.DTOs;
using BookHive.Application.Exceptions;
using BookHive.Application.Extensions.FluentValidationExtension;
using BookHive.Application.Validation.FluentValidation.UserValidator;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;

namespace BookHive.Application.Features.Commands.AppUser.LoginUser
{
    public class LoginUserCommandHandler : IRequestHandler<LoginUserCommandRequest, LoginUserCommandResponse>
    {
        private readonly UserManager<BookHive.Domain.Identity.AppUser> userManager;
        private readonly SignInManager<BookHive.Domain.Identity.AppUser> signInManager;
        private readonly ITokenHandler tokenHandler;
        public LoginUserCommandHandler(UserManager<BookHive.Domain.Identity.AppUser> userManager,
            SignInManager<BookHive.Domain.Identity.AppUser> signInManager,ITokenHandler tokenHandler)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.tokenHandler = tokenHandler;
        }


        public async Task<LoginUserCommandResponse> Handle(LoginUserCommandRequest request, CancellationToken cancellationToken)
        {
            var validationResult = await new LoginUserValidator().ValidateAsync(request.LoginUserDto);
            if (!validationResult.IsValid)
            {
                return new LoginUserCommandResponse
                {
                    Result = new Parametres.ResponseParametres.Result
                    {
                        Success = false,
                        Message = validationResult.ValidationErrorString()
                    }
                };
            }

            BookHive.Domain.Identity.AppUser? user = await userManager.FindByNameAsync(request.LoginUserDto.UserName);
            if (user is null)
                throw new UserNotFoundException();

            var result = await signInManager.PasswordSignInAsync(user, request.LoginUserDto.Password, true, true);
            if (!result.Succeeded)
            {
                return new LoginUserCommandResponse
                {
                    Result = new Parametres.ResponseParametres.Result 
                    { 
                        Message = "Failed",
                        Success = false 
                    }
                };
            }

            TokenDto tokenDto = tokenHandler.CreateAccessToken(5);
            user.RefreshToken = tokenDto.RefreshToken;
            user.RefreshTokenEndDate = tokenDto.Expiration.AddMinutes(30);

            await userManager.UpdateAsync(user);

            return new LoginUserCommandResponse
            {
                Result = new Parametres.ResponseParametres.Result
                {
                    Success = true,
                    Message = Messages.Successlogin,
                },
                tokenDto = tokenDto
            };
        }
    } 
}
