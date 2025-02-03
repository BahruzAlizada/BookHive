using BookHive.Application.DTO;
using BookHive.Application.DTOs;
using BookHive.Application.Repositories;
using BookHive.Domain.Entities;

namespace BookHive.Application.Abstracts.Services.EntityFramework
{
    public interface IBasketWriteRepository : IWriteRepository<Basket>
    {
        Task AddItemToBasketAsync(BasketItemAddDto basketItemAddDto);
        Task ApplyCouponAsync(ApplyCouponToBasketDto applyCouponToBasketDto);
        Task ClearBasket();
    }
}
