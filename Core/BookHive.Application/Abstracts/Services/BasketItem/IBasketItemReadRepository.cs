using BookHive.Application.Repositories;
using BookHive.Domain.Entities;

namespace BookHive.Application.Abstracts.Services
{
    public interface IBasketItemReadRepository : IReadRepository<BasketItem>
    {
        Task<int> GetBasketItemBookQuantity(Guid bookId);
    }
}
