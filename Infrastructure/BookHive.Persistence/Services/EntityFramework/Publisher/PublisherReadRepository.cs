using BookHive.Application.Abstracts.Services.EntityFramework;
using BookHive.Application.DTOs;
using BookHive.Application.Parametres.ResponseParametres;
using BookHive.Persistence.Concrete;
using BookHive.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;

namespace BookHive.Persistence.Services.EntityFramework
{
    public class PublisherReadRepository : ReadRepository<Domain.Entities.Publisher>, IPublisherReadRepository
    {
        private readonly Context context;
        public PublisherReadRepository(Context context) : base(context)
        {
            this.context = context;
        }

    }
}
