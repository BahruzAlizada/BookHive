using BookHive.Application.Abstracts.Services;
using BookHive.Domain.Entities;
using BookHive.Persistence.Context;
using BookHive.Persistence.Repositories;

namespace BookHive.Persistence.Concrete
{
    public class BookStatusReadRepository : ReadRepository<BookStatus>, IBookStatusReadRepository
    {
        public BookStatusReadRepository(AppDbContext context) : base(context)
        {
        }
    }
}
