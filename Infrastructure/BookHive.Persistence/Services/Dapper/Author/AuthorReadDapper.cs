using System.Data.Common;
using BookHive.Application.Abstracts.Services.Dapper;
using BookHive.Domain.Entities;
using Dapper;

namespace BookHive.Persistence.Services.Dapper
{
    public class AuthorReadDapper : IAuthorReadDapper
    {
        private readonly DbConnection connection;
        public AuthorReadDapper(DbConnection connection)
        {
            this.connection = connection;
        }

        public async Task<Author> GetAuthorAsync(Guid id)
        {
            var query = $"SELECT Id, Name, Bio, ProfilePictureUrl, Status From Authors WHERE Id=@Id";
            var author = await connection.QuerySingleOrDefaultAsync<Author>(query, new {Id = id});
            return author;
        }

        public async Task<List<Author>> GetAuthorsAsync()
        {
            var query = "SELECT Id, Name, Bio, ProfilePictureUrl, Status From Authors";
            var authors = await connection.QueryAsync<Author>(query);
            return authors.ToList();
        }
    }
}
