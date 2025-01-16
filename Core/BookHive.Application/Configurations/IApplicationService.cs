using BookHive.Application.DTOs.Configuration;

namespace BookHive.Application.Configurations
{
    public interface IApplicationService
    {
        List<MenuDto> GetAuthorizeDefinitionEndpoints(Type type);
    }
}
