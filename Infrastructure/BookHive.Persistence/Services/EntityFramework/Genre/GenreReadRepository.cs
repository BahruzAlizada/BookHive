﻿using BookHive.Application.Abstracts.Services.EntityFramework;
using BookHive.Application.DTOs;
using BookHive.Domain.Entities;
using BookHive.Persistence.Concrete;
using BookHive.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;

namespace BookHive.Persistence.Services.EntityFramework
{
    public class GenreReadRepository : ReadRepository<Genre>, IGenreReadRepository
    {
        private readonly Context context;
        public GenreReadRepository(Context context) : base(context)
        {
            this.context = context;
        }

        public async Task<GenreDto> GetGenreDtoAsync(Guid id)
        {
            Genre? genre = await context.Genres.Include(x => x.Category).FirstOrDefaultAsync(x => x.Id == id);
            if (genre is null)
                return null;

            GenreDto genreDto = new GenreDto
            {
                Id = id,
                Name = genre.Name,
                Status = genre.Status,
                CategoryId = genre.CategoryId,
            };

            return genreDto;
        }

        public async Task<List<GenreDto>> GetGenreDtosAsync(Guid? categoryId)
        {
            IQueryable<Genre> genres = context.Genres.Include(x => x.Category).AsQueryable();
            if (categoryId is not null)
                genres = genres.Where(x => x.CategoryId == categoryId);

            List<Genre> genreList = await genres.ToListAsync();
            List<GenreDto> genreDtos = new List<GenreDto>();

            foreach (var genre in genreList)
            {
                GenreDto dto = new GenreDto
                {
                    Id = genre.Id,
                    Name = genre.Name,
                    Status = genre.Status,
                    CategoryId = genre.CategoryId,
                };
                genreDtos.Add(dto);
            }

            return genreDtos;
        }
    }
}
