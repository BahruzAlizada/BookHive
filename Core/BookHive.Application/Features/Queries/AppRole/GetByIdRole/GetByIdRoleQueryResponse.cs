using BookHive.Application.DTOs;
using BookHive.Application.Parametres.ResponseParametres;

namespace BookHive.Application.Features.Queries.AppRole.GetByIdRole
{
    public class GetByIdRoleQueryResponse
    {
        public RoleDto? RoleDto { get; set; }
        public Result Result { get; set; }
    }
}