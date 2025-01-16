using BookHive.Application.Abstracts.Services;
using BookHive.Domain.Entities;
using BookHive.Persistence.Context;
using BookHive.Persistence.Repositories;

namespace BookHive.Persistence.Concrete
{
    public class EndpointWriteRepository : WriteRepository<Endpoint>, IEndpointWriteRepository
    {
        private readonly AppDbContext context;
        public EndpointWriteRepository(AppDbContext context) : base(context)
        {
            this.context = context;
        }


     
    }
}
