using BookHive.Domain.Entities;

namespace BookHive.Application.Abstracts.ServiceContracts
{
    public interface IBasketService
    {
        Task<Basket?> GetBasket();
        Task CalculateTotalPrice(Basket basket);
    }
}
