using BookHive.Application.Repositories;
using BookHive.Domain.Entities;

namespace BookHive.Application.Abstracts.Services
{
    public interface IBasketReadRepository : IReadRepository<Basket>
    {
    }
}
