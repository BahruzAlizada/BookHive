using System.Data.Common;
using BookHive.Application.Abstracts.Services.Dapper;
using BookHive.Application.DTOs;
using BookHive.Domain.Entities;
using Dapper;

namespace BookHive.Persistence.Services.Dapper
{
    public class CategoryWriteDapper : ICategoryWriteDapper
    {
        private readonly DbConnection connection;
        public CategoryWriteDapper(DbConnection connection)
        {
            this.connection=connection;
        }


        public async Task AddCategory(Category category)
        {
            category.Id = Guid.NewGuid();
            var query = $"INSERT INTO Categories  (Id, Name, Status) VALUES (@Id, @Name, @Status)";
            var result = await connection.ExecuteAsync(query,category);
        }

        public async Task DeleteCategory(Category category)
        {
            var query = "DELETE From Categories WHERE Id=@Id";
            var result = await connection.ExecuteAsync(query, category);
        }

        public async Task UpdateCategory(Category category)
        {
            var query = "UPDATE Categories SET Name = @Name WHERE Id = @Id";
            var result = await connection.ExecuteAsync(query, new { category.Name, category.Id });
        }
    }
}
