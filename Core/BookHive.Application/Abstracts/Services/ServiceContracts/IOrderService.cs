

using BookHive.Domain.Entities;

namespace BookHive.Application.Abstracts.Services.ServiceContracts
{
    public interface IOrderService
    {
        Task<Basket> GetUserActiveBasket();
    }
}
