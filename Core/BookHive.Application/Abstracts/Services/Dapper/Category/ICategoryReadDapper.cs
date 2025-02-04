using BookHive.Domain.Entities;

namespace BookHive.Application.Abstracts.Services.Dapper
{
    public interface ICategoryReadDapper
    {
        Task<List<Category>> GetCategoriesAsync();
        Task<Category> GetCategoryAsync(Guid id);
    }
}
