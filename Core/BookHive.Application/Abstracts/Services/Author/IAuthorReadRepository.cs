using BookHive.Application.DTOs;
using BookHive.Application.Repositories;
using BookHive.Domain.Entities;

namespace BookHive.Application.Abstracts.Services
{
    public interface IAuthorReadRepository : IReadRepository<Author>
    {
        Task<List<AuthorDto>> GetAuthorDtosAsync();
        Task<AuthorDto> GetAuthorDtoAsync(Guid id);
    }
}
