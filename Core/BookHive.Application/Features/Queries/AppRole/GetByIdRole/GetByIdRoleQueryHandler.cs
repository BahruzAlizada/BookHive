using AutoMapper;
using BookHive.Application.ConstMessages;
using BookHive.Application.DTOs;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace BookHive.Application.Features.Queries.AppRole.GetByIdRole
{
    public class GetByIdRoleQueryHandler : IRequestHandler<GetByIdRoleQueryRequest, GetByIdRoleQueryResponse>
    {
        private readonly RoleManager<BookHive.Domain.Identity.AppRole> roleManager;
        private readonly IMapper mapper;
        public GetByIdRoleQueryHandler(RoleManager<BookHive.Domain.Identity.AppRole> roleManager,IMapper mapper)
        {
            this.roleManager = roleManager;
            this.mapper = mapper;
        }


        public async Task<GetByIdRoleQueryResponse> Handle(GetByIdRoleQueryRequest request, CancellationToken cancellationToken)
        {
            var role = await roleManager.Roles.FirstOrDefaultAsync(x=>x.Id == request.Id);
            if (role==null)
            {
                return new GetByIdRoleQueryResponse
                {
                    Result = new Parametres.ResponseParametres.Result
                    {
                        Success = false,
                        Message = Messages.IdNull
                    }
                };
            }

            RoleDto roleDto = mapper.Map<RoleDto>(role);

            return new GetByIdRoleQueryResponse
            {
                RoleDto = roleDto,
                Result = new Parametres.ResponseParametres.Result
                {
                    Success = true,
                    Message = Messages.SuccessGetFiltered
                }
            };

        }
    }
}
