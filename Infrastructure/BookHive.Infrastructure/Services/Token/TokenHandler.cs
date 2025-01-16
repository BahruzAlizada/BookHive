using System.IdentityModel.Tokens.Jwt;
using System.Security.Cryptography;
using System.Text;
using BookHive.Application.Abstracts.Services;
using BookHive.Application.DTOs;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json.Linq;

namespace BookHive.Infrastructure.Services;

public class TokenHandler : ITokenHandler
{
    private readonly IConfiguration configuration;
    public TokenHandler(IConfiguration configuration)
    {
        this.configuration = configuration;
    }


    public TokenDto CreateAccessToken(int minute)
    {
        TokenDto tokenDto = new TokenDto();

        SymmetricSecurityKey symmetricSecurityKey = new(Encoding.UTF8.GetBytes(configuration["Token:SecurityKey"]));
        SigningCredentials signingCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256);

        tokenDto.Expiration = DateTime.UtcNow.AddMinutes(minute);

        JwtSecurityToken jwtSecurityToken = new JwtSecurityToken
            (
                 audience: configuration["Token:Audience"],
                issuer: configuration["Token:Issuer"],
                expires: tokenDto.Expiration,
                notBefore: DateTime.UtcNow,
                signingCredentials: signingCredentials
            );


        JwtSecurityTokenHandler jwtSecurityTokenHandler = new JwtSecurityTokenHandler();
        tokenDto.AccessToken = jwtSecurityTokenHandler.WriteToken(jwtSecurityToken);
        tokenDto.RefreshToken = CreateRefreshToken();

        return tokenDto;
    }

    public string CreateRefreshToken()
    {
        byte[] number = new byte[32];
        using var random = RandomNumberGenerator.Create();
        random.GetBytes(number);
        return Convert.ToBase64String(number);
    }


}

