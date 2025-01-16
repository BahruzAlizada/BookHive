using BookHive.Application.DTOs;
using BookHive.Application.Parametres.ResponseParametres;

namespace BookHive.Application.Features.Queries.AppRole.GetAllRoles
{
    public class GetAllRoleQueryResponse
    {
        public Result Result { get; set; }
        public List<RoleDto> Roles { get; set; }
    }
}