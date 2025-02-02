using BookHive.Application.DTOs;
using BookHive.Application.Repositories;
using BookHive.Domain.Entities;

namespace BookHive.Application.Abstracts.Services.EntityFramework
{
    public interface IBasketItemWriteRepository : IWriteRepository<BasketItem>
    {
        Task UpdateBasketItemQuantityAsync(BasketItemUpdateDto basketItemUpdateDto);
        Task DeleteBasketItem(BasketItem item);
    }
}
