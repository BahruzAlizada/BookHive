using BookHive.Application.DTOs;
using BookHive.Application.Repositories;

namespace BookHive.Application.Abstracts.Services
{
    public interface IPublisherReadRepository : IReadRepository<BookHive.Domain.Entities.Publisher>
    {
    }
}
