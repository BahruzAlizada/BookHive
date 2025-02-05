

using BookHive.Domain.Entities;

namespace BookHive.Application.Abstracts.Services.Dapper
{
    public interface IAuthorReadDapper
    {
        Task<List<Author>> GetAuthorsAsync();
        Task<Author> GetAuthorAsync(Guid id);
    }
}
