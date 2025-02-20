﻿using BookHive.Application.DTOs;
using BookHive.Application.Repositories;
using BookHive.Domain.Entities;

namespace BookHive.Application.Abstracts.Services.EntityFramework
{
    public interface IBookReadRepository : IReadRepository<Book>
    {
        Task<List<BookDto>> GetBookAllDtos();
    }
}
