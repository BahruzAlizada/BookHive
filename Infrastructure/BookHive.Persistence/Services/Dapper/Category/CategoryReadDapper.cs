using System.Data.Common;
using BookHive.Application.Abstracts.Services.Dapper;
using BookHive.Domain.Entities;
using Dapper;

namespace BookHive.Persistence.Services.Dapper
{
    public class CategoryReadDapper : ICategoryReadDapper
    {
        private readonly DbConnection connection;
        public CategoryReadDapper(DbConnection connection)
        {
            this.connection = connection;
        }


        public async Task<List<Category>> GetCategoriesAsync()
        {
            var query = "SELECT Id, Name, Status From Categories";
            var categories = await connection.QueryAsync<Category>(query);
            return categories.ToList();
        }

        public async Task<Category> GetCategoryAsync(Guid id)
        {
            var query = $"SELECT Id, Name, Status From Categories WHERE Id=@Id";
            var category = await connection.QuerySingleOrDefaultAsync<Category>(query, new { Id = id });
            return category;
        }
    }
}
