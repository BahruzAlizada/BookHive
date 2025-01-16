using AutoMapper;
using BookHive.Application.ConstMessages;
using BookHive.Application.DTOs;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace BookHive.Application.Features.Queries.AppRole.GetAllRoles
{
    public class GetAllRoleQueryHandler : IRequestHandler<GetAllRoleQueryRequest, GetAllRoleQueryResponse>
    {
        private readonly RoleManager<BookHive.Domain.Identity.AppRole> roleManager;
        private readonly IMapper mapper;
        public GetAllRoleQueryHandler(RoleManager<BookHive.Domain.Identity.AppRole> roleManager,IMapper mapper)
        {
            this.roleManager = roleManager;
            this.mapper = mapper;
        }


        public async Task<GetAllRoleQueryResponse> Handle(GetAllRoleQueryRequest request, CancellationToken cancellationToken)
        {
            var roles = await roleManager.Roles.ToListAsync();
            List<RoleDto> roleDtos = mapper.Map<List<RoleDto>>(roles);

            return new GetAllRoleQueryResponse
            {
                Roles = roleDtos,
                Result = new Parametres.ResponseParametres.Result
                {
                    Success = true,
                    Message = Messages.SuccessListed
                }
            };
        }
    }
}
