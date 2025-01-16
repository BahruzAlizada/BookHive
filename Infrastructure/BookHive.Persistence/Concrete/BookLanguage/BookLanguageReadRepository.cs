
using BookHive.Application.Abstracts.Services;
using BookHive.Domain.Entities;
using BookHive.Persistence.Context;
using BookHive.Persistence.Repositories;

namespace BookHive.Persistence.Concrete
{
    public class BookLanguageReadRepository : ReadRepository<BookLanguage>, IBookLanguageReadRepository
    {
        public BookLanguageReadRepository(AppDbContext context) : base(context)
        {
        }
    }
}
