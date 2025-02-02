using BookHive.Application.Repositories;
using BookHive.Domain.Entities;

namespace BookHive.Application.Abstracts.Services.EntityFramework
{
    public interface IMenuReadRepository : IReadRepository<Menu>
    {
        public Task<List<string>> GetRolesToEndpointAsync(string code, string menu);
    }
}
