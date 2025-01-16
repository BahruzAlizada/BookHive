using BookHive.Application.DTOs;

namespace BookHive.Application.Abstracts.Services
{
    public interface ITokenHandler
    {
        TokenDto CreateAccessToken(int minute);
        string CreateRefreshToken();
    }
}
