using BookHive.Application.Abstracts.Services.EntityFramework;
using BookHive.Application.Repositories;
using BookHive.Domain.Entities;
using BookHive.Persistence.Concrete;
using BookHive.Persistence.Repositories;

namespace BookHive.Persistence.Services.EntityFramework
{
    public class AuthorWriteRepository : WriteRepository<Author>, IAuthorWriteRepository
    {
        public AuthorWriteRepository(Context context) : base(context)
        {
        }
    }
}
