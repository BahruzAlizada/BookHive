using BookHive.Application.DTOs.Book;
using BookHive.Application.Repositories;
using BookHive.Domain.Entities;

namespace BookHive.Application.Abstracts.Services
{
    public interface IBookReadRepository : IReadRepository<Book>
    {
        Task<List<BookDto>> GetBookDtosAsync();
        Task<BookDto> GetBookAsync(Guid id);
    }
}
