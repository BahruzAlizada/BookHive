using BookHive.Application.Abstracts.Services;
using BookHive.Domain.Entities;
using BookHive.Persistence.Context;
using BookHive.Persistence.Repositories;

namespace BookHive.Persistence.Concrete
{
    public class BookWriteRepository : WriteRepository<Book>, IBookWriteRepository
    {
        public BookWriteRepository(AppDbContext context) : base(context)
        {
        }
    }
}
