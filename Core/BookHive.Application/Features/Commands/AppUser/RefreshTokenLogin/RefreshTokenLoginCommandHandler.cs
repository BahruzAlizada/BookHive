using BookHive.Application.Abstracts;
using BookHive.Application.Constants;
using BookHive.Application.DTOs;
using BookHive.Application.Exceptions;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace BookHive.Application.Features.Commands.AppUser.RefreshTokenLogin
{
    public class RefreshTokenLoginCommandHandler : IRequestHandler<RefreshTokenLoginCommandRequest, RefreshTokenLoginCommandResponse>
    {
        private readonly UserManager<BookHive.Domain.Identity.AppUser> userManager;
        private readonly ITokenHandler tokenHandler;
        public RefreshTokenLoginCommandHandler(UserManager<BookHive.Domain.Identity.AppUser> userManager,ITokenHandler tokenHandler)
        {
            this.userManager = userManager;
            this.tokenHandler = tokenHandler;
        }

        public async Task<RefreshTokenLoginCommandResponse> Handle(RefreshTokenLoginCommandRequest request, CancellationToken cancellationToken)
        {
            BookHive.Domain.Identity.AppUser? appUser = await userManager.Users.FirstOrDefaultAsync(x=>x.RefreshToken==request.RefreshToken);
            if (appUser != null && appUser?.RefreshTokenEndDate > DateTime.UtcNow)
            {
                TokenDto tokenDto = tokenHandler.CreateAccessToken(30);

                appUser.RefreshToken = tokenDto.RefreshToken; ;
                appUser.RefreshTokenEndDate = tokenDto.Expiration.AddMinutes(30);
                await userManager.UpdateAsync(appUser);

                return new RefreshTokenLoginCommandResponse
                {
                    TokenDto = tokenDto,
                    UserName = appUser.UserName,
                    Result = new Parametres.ResponseParametres.Result
                    {
                        Success = true,
                        Message = Messages.Successlogin
                    }
                };
            }
            else
                throw new UserNotFoundException();
        }
    }
}
