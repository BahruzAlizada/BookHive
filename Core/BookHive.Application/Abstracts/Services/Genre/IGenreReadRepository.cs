using BookHive.Application.DTOs;
using BookHive.Application.Repositories;
using BookHive.Domain.Entities;

namespace BookHive.Application.Abstracts.Services
{
    public interface IGenreReadRepository : IReadRepository<Genre>
    {
        Task<List<GenreDto>> GetGenreDtosAsync(Guid? categoryId);
        Task<GenreDto> GetGenreDtoAsync(Guid id);
    }
}
