using BookHive.Application.Abstracts.Services;
using BookHive.Domain.Entities;
using BookHive.Persistence.Context;
using BookHive.Persistence.Repositories;

namespace BookHive.Persistence.Concrete
{
    public class BookLanguageWriteRepository : WriteRepository<BookLanguage>, IBookLanguageWriteRepository
    {
        public BookLanguageWriteRepository(AppDbContext context) : base(context)
        {
        }
    }
}
