
using System.Data.Common;
using BookHive.Application.Abstracts.Services.Dapper;
using BookHive.Domain.Entities;
using Dapper;

namespace BookHive.Persistence.Services.Dapper
{
    public class PublisherReadDapper : IPublisherReadDapper
    {
        private readonly DbConnection connection;
        public PublisherReadDapper(DbConnection connection)
        {
            this.connection = connection;
        }


        public async Task<Publisher> GetPublisherAsync(Guid id)
        {
            var query = $"SELECT Id, Name, ContactNumber, Status From Publishers WHERE Id=@Id";
            var publisher = await connection.QuerySingleOrDefaultAsync<Publisher>(query, new { Id = id });
            return publisher;
        }

        public async Task<List<Publisher>> GetPublishersAsync()
        {
            var query = "SELECT Id, Name, ContactNumber, Status From Publishers";
            var publishers = await connection.QueryAsync<Publisher>(query);
            return publishers.ToList();
        }
    }
}
