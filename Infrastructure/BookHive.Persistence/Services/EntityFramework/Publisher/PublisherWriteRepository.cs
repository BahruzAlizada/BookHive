using BookHive.Application.Abstracts.Services;
using BookHive.Persistence.Concrete;
using BookHive.Persistence.Repositories;

namespace BookHive.Persistence.Services.EntityFramework
{
    public class PublisherWriteRepository : WriteRepository<Domain.Entities.Publisher>, IPublisherWriteRepository
    {
        public PublisherWriteRepository(Context context) : base(context)
        {
        }
    }
}
