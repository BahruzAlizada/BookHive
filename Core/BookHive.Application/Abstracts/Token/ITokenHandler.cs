﻿using BookHive.Application.DTOs;

namespace BookHive.Application.Abstracts
{
    public interface ITokenHandler
    {
        TokenDto CreateAccessToken(int minute);
        string CreateRefreshToken();
    }
}
