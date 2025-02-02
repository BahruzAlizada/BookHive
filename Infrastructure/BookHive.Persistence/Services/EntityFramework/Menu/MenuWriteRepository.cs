using BookHive.Application.Abstracts.Configuration;
using BookHive.Application.Abstracts.Services.EntityFramework;
using BookHive.Domain.Entities;
using BookHive.Persistence.Concrete;
using BookHive.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;

namespace BookHive.Persistence.Services.EntityFramework;

public class MenuWriteRepository : WriteRepository<Menu>, IMenuWriteRepository
{
    private readonly Context context;
    private readonly IApplicationService applicationService;
    public MenuWriteRepository(Context context, IApplicationService applicationService) : base(context)
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