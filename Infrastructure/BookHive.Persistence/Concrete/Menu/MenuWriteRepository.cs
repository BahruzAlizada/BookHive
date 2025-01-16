using BookHive.Application.Abstracts.Services;
using BookHive.Application.Configurations;
using BookHive.Domain.Entities;
using BookHive.Persistence.Context;
using BookHive.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;

namespace BookHive.Persistence.Concrete;

public class MenuWriteRepository : WriteRepository<Menu>, IMenuWriteRepository
{
    private readonly AppDbContext context;
    private readonly IApplicationService applicationService;
    public MenuWriteRepository(AppDbContext context,IApplicationService applicationService) : base(context)
    {
        this.context = context;
        this.applicationService = applicationService;
    }


    public async Task AssignRoleEndpointAsync(string[] roles, string menu, string code, Type type)
    {
        Menu menuEntity = await context.Menus.FirstOrDefaultAsync(x => x.Name == menu);
        if (menuEntity == null)
        {
            menuEntity = new Menu
            {
                Name = menu,
            };
            await context.Menus.AddAsync(menuEntity);
            await context.SaveChangesAsync();
        }

        Endpoint? endpoint = await context.Endpoints.Include(e => e.Menu).Include(e => e.Roles).FirstOrDefaultAsync(e => e.Code == code && e.Menu.Name == menu);

        if (endpoint == null)
        {
            var action = applicationService.GetAuthorizeDefinitionEndpoints(type)
                    .FirstOrDefault(m => m.Name == menu)
                    ?.Actions.FirstOrDefault(e => e.Code == code);

            endpoint = new()
            {
                Code = action.Code,
                ActionType = action.ActionType,
                HttpType = action.HttpType,
                Definition = action.Definition,
                Id = Guid.NewGuid(),
                Menu = menuEntity
            };

            await context.Endpoints.AddAsync(endpoint);
            await context.SaveChangesAsync();
        }
    }
}