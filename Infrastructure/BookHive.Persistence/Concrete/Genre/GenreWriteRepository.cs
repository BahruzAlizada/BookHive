using BookHive.Application.Abstracts.Services;
using BookHive.Domain.Entities;
using BookHive.Persistence.Context;
using BookHive.Persistence.Repositories;

namespace BookHive.Persistence.Concrete
{
    public class GenreWriteRepository : WriteRepository<Genre>, IGenreWriteRepository
    {
        public GenreWriteRepository(AppDbContext context) : base(context)
        {
        }
    }
}
