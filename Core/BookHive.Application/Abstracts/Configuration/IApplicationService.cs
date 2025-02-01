using BookHive.Application.DTOs.Configuration;

namespace BookHive.Application.Abstracts.Configuration
{
    public interface IApplicationService
    {
        List<MenuDto> GetAuthorizeDefinitionEndpoints(Type type);
    }
}
