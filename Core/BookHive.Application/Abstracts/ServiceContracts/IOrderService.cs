using BookHive.Domain.Entities;

namespace BookHive.Application.Abstracts.ServiceContracts
{
    public interface IOrderService
    {
        Task<Basket> GetUserActiveBasket();
    }
}
