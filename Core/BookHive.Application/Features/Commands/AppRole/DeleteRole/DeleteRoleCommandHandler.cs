﻿using BookHive.Application.Constants;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace BookHive.Application.Features.Commands.AppRole.DeleteRole
{
    public class DeleteRoleCommandHandler : IRequestHandler<DeleteRoleCommandRequest, DeleteRoleCommandResponse>
    {
        private readonly RoleManager<BookHive.Domain.Identity.AppRole> roleManager;
        public DeleteRoleCommandHandler(RoleManager<BookHive.Domain.Identity.AppRole> roleManager)
        {
            this.roleManager = roleManager;
        }


        public async Task<DeleteRoleCommandResponse> Handle(DeleteRoleCommandRequest request, CancellationToken cancellationToken)
        {
            BookHive.Domain.Identity.AppRole? role = await roleManager.Roles.FirstOrDefaultAsync(x => x.Id == request.Id);
            if (role == null)
            {
                return new DeleteRoleCommandResponse
                {
                    Result = new Parametres.ResponseParametres.Result
                    {
                        Success = false,
                        Message = Messages.IdNull
                    }
                };
            }

            await roleManager.DeleteAsync(role);
            return new DeleteRoleCommandResponse
            {
                Result = new Parametres.ResponseParametres.Result
                {
                    Success = true,
                    Message = Messages.SuccessDeleted
                }
            };
        }
    }
}
