using BookHive.Application.Abstracts.Services;
using BookHive.Application.DTOs;
using BookHive.Domain.Entities;
using BookHive.Persistence.Concrete;
using BookHive.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;

namespace BookHive.Persistence.Services.EntityFramework
{
    public class BookReadRepository : ReadRepository<Book>, IBookReadRepository
    {
        private readonly Context context;
        public BookReadRepository(Context context) : base(context)
        {
            this.context = context;
        }

       
    }
}
