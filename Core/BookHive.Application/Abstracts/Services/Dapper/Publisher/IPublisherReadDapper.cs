
using System.Security.Policy;

namespace BookHive.Application.Abstracts.Services.Dapper
{
    public interface IPublisherReadDapper
    { 
        Task<List<Domain.Entities.Publisher>> GetPublishersAsync();
        Task<Domain.Entities.Publisher> GetPublisherAsync(Guid id);
    }
}
