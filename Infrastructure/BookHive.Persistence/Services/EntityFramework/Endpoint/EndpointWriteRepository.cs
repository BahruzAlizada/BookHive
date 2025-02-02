using BookHive.Application.Abstracts.Services.EntityFramework;
using BookHive.Domain.Entities;
using BookHive.Persistence.Concrete;
using BookHive.Persistence.Repositories;

namespace BookHive.Persistence.Services.EntityFramework
{
    public class EndpointWriteRepository : WriteRepository<Endpoint>, IEndpointWriteRepository
    {
        private readonly Context context;
        public EndpointWriteRepository(Context context) : base(context)
        {
            this.context = context;
        }



    }
}
