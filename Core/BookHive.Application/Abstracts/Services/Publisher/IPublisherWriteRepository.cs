using BookHive.Application.Repositories;

namespace BookHive.Application.Abstracts.Services
{
    public interface IPublisherWriteRepository : IWriteRepository<BookHive.Domain.Entities.Publisher>
    {
    }
}
