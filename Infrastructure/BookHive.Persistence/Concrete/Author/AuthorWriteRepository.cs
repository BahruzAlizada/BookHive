
using BookHive.Application.Abstracts.Services;
using BookHive.Application.Repositories;
using BookHive.Domain.Entities;
using BookHive.Persistence.Context;
using BookHive.Persistence.Repositories;

namespace BookHive.Persistence.Concrete
{
    public class AuthorWriteRepository : WriteRepository<Author>, IAuthorWriteRepository
    {
        public AuthorWriteRepository(AppDbContext context) : base(context)
        {
        }
    }
}
