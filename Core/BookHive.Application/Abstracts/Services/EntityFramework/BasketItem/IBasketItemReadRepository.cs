using BookHive.Application.Repositories;
using BookHive.Domain.Entities;

namespace BookHive.Application.Abstracts.Services.EntityFramework
{
    public interface IBasketItemReadRepository : IReadRepository<BasketItem>
    {
        Task<int> GetBasketItemBookQuantity(Guid bookId);
    }
}
