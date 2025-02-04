

using BookHive.Application.DTOs;
using BookHive.Domain.Entities;

namespace BookHive.Application.Abstracts.Services.Dapper
{
    public interface ICategoryWriteDapper
    {
        Task AddCategory(Category category);
        Task UpdateCategory(Category category);
        Task DeleteCategory(Category category);
    }
}
