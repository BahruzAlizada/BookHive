using BookHive.Application.Abstracts.Services;
using BookHive.Domain.Entities;
using BookHive.Persistence.Context;
using BookHive.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;

namespace BookHive.Persistence.Concrete
{
    public class MenuReadRepository : ReadRepository<Menu>, IMenuReadRepository
    {
        private readonly AppDbContext context;
        public MenuReadRepository(AppDbContext context) : base(context)
        {
            this.context = context;
        }


        public async Task<List<string>> GetRolesToEndpointAsync(string code, string menu)
        {
            Endpoint? endpoint = await context.Endpoints.Include(e => e.Roles).Include(e => e.Menu).FirstOrDefaultAsync(e => e.Code == code && e.Menu.Name == menu);
            if (endpoint != null)
                return endpoint.Roles.Select(r => r.Name).ToList();
            return null;

        }
    }
}
