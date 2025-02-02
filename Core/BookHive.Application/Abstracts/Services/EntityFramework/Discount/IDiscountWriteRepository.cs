using BookHive.Application.DTOs;
using BookHive.Application.DTOs.Discount;
using BookHive.Application.Repositories;
using BookHive.Domain.Entities;

namespace BookHive.Application.Abstracts.Services.EntityFramework
{
    public interface IDiscountWriteRepository : IWriteRepository<BookDiscount>
    {
        Task DiscountApplyGenre(DiscountGenreDto discountGenreDto);
        Task DiscountApplyBook(DiscountBookDto discountBookDto);
    }
}
