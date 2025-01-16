using BookHive.Application.Abstracts.Services;
using BookHive.Persistence.Context;
using BookHive.Persistence.Repositories;

namespace BookHive.Persistence.Concrete
{
    public class PublisherWriteRepository : WriteRepository<BookHive.Domain.Entities.Publisher>, IPublisherWriteRepository
    {
        public PublisherWriteRepository(AppDbContext context) : base(context)
        {
        }
    }
}
