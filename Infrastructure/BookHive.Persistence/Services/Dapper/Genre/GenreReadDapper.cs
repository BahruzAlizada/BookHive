using System.Data.Common;
using BookHive.Application.Abstracts.Services.Dapper;
using BookHive.Domain.Entities;
using Dapper;

namespace BookHive.Persistence.Services.Dapper
{
    public class GenreReadDapper : IGenreReadDapper
    {
        private readonly DbConnection connection;
        public GenreReadDapper(DbConnection connection)
        {
            this.connection = connection; 
        }

        public async Task<Genre> GetGenreAsync(Guid id)
        {
            var query = $"SELECT Id, Name, CategoryId, Status From Genres WHERE Id=@Id";
            var genre = await connection.QuerySingleOrDefaultAsync<Genre>(query, new { Id = id });
            return genre;
        }

        public async Task<List<Genre>> GetGenresAsync(Guid? categoryId)
        {
            var query = "SELECT Id, Name, CategoryId, Status From Genres";
            if (categoryId != null)
                query += " WHERE CategoryId = @CategoryId";

            var genres = await connection.QueryAsync<Genre>(query, new {CategoryId=categoryId});
            return genres.ToList();
        }
    }
}
