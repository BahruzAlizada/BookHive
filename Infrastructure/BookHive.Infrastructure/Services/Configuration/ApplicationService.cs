using System.Reflection;
using BookHive.Application.Configurations;
using BookHive.Application.CustomAttributes;
using BookHive.Application.DTOs.Configuration;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.AspNetCore.Mvc;
using BookHive.Application.Enums;

namespace BookHive.Infrastructure.Services.Configuration
{
    public class ApplicationService : IApplicationService
    {
        public List<MenuDto> GetAuthorizeDefinitionEndpoints(Type type)
        {
            Assembly assembly = Assembly.GetAssembly(type);
            var controllers = assembly.GetTypes().Where(x => x.IsAssignableTo(typeof(ControllerBase)));
            List<MenuDto> menus = new List<MenuDto>();

            if (controllers is not null)
            {
                foreach (var controller in controllers)
                {
                    var actions = controller.GetMethods().Where(x => x.IsDefined(typeof(AuthorizeDefinitionAttribute)));
                    if (actions is not null)
                    {
                        foreach (var action in actions)
                        {
                            var attributes = action.GetCustomAttributes(true);
                            if (attributes is not null)
                            {
                                MenuDto menu = null;

                                var authorizeDefinitionAttribute = attributes.FirstOrDefault(x => x.GetType() == typeof(AuthorizeDefinitionAttribute)) as AuthorizeDefinitionAttribute;
                                if (!menus.Any(x => x.Name == authorizeDefinitionAttribute.Menu))
                                {
                                    menu = new() { Name = authorizeDefinitionAttribute.Menu };
                                    menus.Add(menu);
                                }
                                else
                                    menu = menus.FirstOrDefault(x => x.Name == authorizeDefinitionAttribute.Menu);

                                ActionDto actionDto = new ActionDto()
                                {
                                    ActionType = Enum.GetName(typeof(ActionType), authorizeDefinitionAttribute.ActionType),
                                    Definition = authorizeDefinitionAttribute.Definition
                                };

                                var httpAttribute = attributes.FirstOrDefault(a => a.GetType().IsAssignableTo(typeof(HttpMethodAttribute))) as HttpMethodAttribute;
                                if (httpAttribute != null)
                                    actionDto.HttpType = httpAttribute.HttpMethods.First();
                                else
                                    actionDto.HttpType = HttpMethods.Get;

                                actionDto.Code = $"{actionDto.HttpType}.{actionDto.ActionType}.{actionDto.Definition.Replace(" ", "")}";

                                menu.Actions.Add(actionDto);
                            }
                        }
                    }
                }
            }

            return menus;
        }
    }
}
