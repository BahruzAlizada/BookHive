using BookHive.Application.DTO;
using BookHive.Application.DTOs;
using BookHive.Application.Repositories;
using BookHive.Domain.Entities;

namespace BookHive.Application.Abstracts.Services
{
    public interface IBasketWriteRepository : IWriteRepository<Basket>
    {
        Task AddItemToBasketAsync(BasketItemAddDto basketItemAddDto);
        Task ApplyCouponAsync(ApplyCouponToBasketDto applyCouponToBasketDto);
        Task CalculateTotalPrice(Basket basket);
        Task ClearBasket();
    }
}
