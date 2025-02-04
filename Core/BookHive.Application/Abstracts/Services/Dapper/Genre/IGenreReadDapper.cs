using BookHive.Domain.Entities;

namespace BookHive.Application.Abstracts.Services.Dapper
{
    public interface IGenreReadDapper
    {
        Task<List<Genre>> GetGenresAsync(Guid? categoryId);
        Task<Genre> GetGenreAsync(Guid Id);
    }
}
