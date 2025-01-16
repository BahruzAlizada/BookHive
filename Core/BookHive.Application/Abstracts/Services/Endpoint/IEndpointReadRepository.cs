using BookHive.Application.Repositories;
using BookHive.Domain.Entities;

namespace BookHive.Application.Abstracts.Services
{
    public interface IEndpointReadRepository : IReadRepository<Endpoint>
    {
    }
}
