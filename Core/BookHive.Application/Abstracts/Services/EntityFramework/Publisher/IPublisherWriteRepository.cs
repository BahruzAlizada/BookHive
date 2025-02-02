using BookHive.Application.Repositories;

namespace BookHive.Application.Abstracts.Services.EntityFramework
{
    public interface IPublisherWriteRepository : IWriteRepository<Domain.Entities.Publisher>
    {
    }
}
