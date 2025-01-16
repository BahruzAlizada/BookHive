using BookHive.Application.Abstracts.Services;
using BookHive.Domain.Entities;
using BookHive.Persistence.Context;
using BookHive.Persistence.Repositories;

namespace BookHive.Persistence.Concrete
{
    public class BookStatusWriteRepository : WriteRepository<BookStatus>, IBookStatusWriteRepository
    {
        public BookStatusWriteRepository(AppDbContext context) : base(context)
        {
        }
    }
}
