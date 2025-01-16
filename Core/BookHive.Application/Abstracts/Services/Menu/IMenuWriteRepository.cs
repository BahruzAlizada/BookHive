using BookHive.Application.Repositories;
using BookHive.Domain.Entities;

namespace BookHive.Application.Abstracts.Services
{
    public interface IMenuWriteRepository : IWriteRepository<Menu>
    {
        Task AssignRoleEndpointAsync(string[] roles, string menu, string code, Type type);
    }
}
