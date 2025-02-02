using BookHive.Application.DTOs;
using BookHive.Application.Repositories;

namespace BookHive.Application.Abstracts.Services.EntityFramework
{
    public interface IPublisherReadRepository : IReadRepository<Domain.Entities.Publisher>
    {
    }
}
