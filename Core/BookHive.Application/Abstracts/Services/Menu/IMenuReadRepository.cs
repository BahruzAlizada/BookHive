using BookHive.Application.Repositories;
using BookHive.Domain.Entities;

namespace BookHive.Application.Abstracts.Services
{
    public interface IMenuReadRepository : IReadRepository<Menu>
    {
        public Task<List<string>> GetRolesToEndpointAsync(string code, string menu);
    }
}
