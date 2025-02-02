using BookHive.Application.Abstracts.Services.EntityFramework;
using BookHive.Application.DTOs;
using BookHive.Domain.Entities;
using BookHive.Persistence.Concrete;
using BookHive.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;

namespace BookHive.Persistence.Services.EntityFramework
{
    public class AuthorReadRepository : ReadRepository<Author>, IAuthorReadRepository
    {
        private readonly Context context;
        public AuthorReadRepository(Context context) : base(context)
        {
            this.context = context;
        }

    }
}
