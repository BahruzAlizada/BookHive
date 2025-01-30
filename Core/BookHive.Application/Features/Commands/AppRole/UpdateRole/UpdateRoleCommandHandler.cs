using AutoMapper;
using BookHive.Application.Constants;
using BookHive.Application.Extensions.FluentValidationExtension;
using BookHive.Application.Rule;
using BookHive.Application.Validation.FluentValidation.RoleValidator;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace BookHive.Application.Features.Commands.AppRole.UpdateRole
{
    public class UpdateRoleCommandHandler : IRequestHandler<UpdateRoleCommandRequest, UpdateRoleCommandResponse>
    {
        private readonly RoleManager<BookHive.Domain.Identity.AppRole> roleManager;
        private readonly IMapper mapper;

        public UpdateRoleCommandHandler(RoleManager<BookHive.Domain.Identity.AppRole> roleManager,IMapper mapper)
        {
            this.roleManager = roleManager;
            this.mapper = mapper;
        }


        public async Task<UpdateRoleCommandResponse> Handle(UpdateRoleCommandRequest request, CancellationToken cancellationToken)
        {
            var validationResult = await new RoleUpdateValidator().ValidateAsync(request.RoleUpdateDto);
            if (!validationResult.IsValid)
            {
                return new UpdateRoleCommandResponse
                {
                    Result = new Parametres.ResponseParametres.Result
                    {
                        Success = false,
                        Message = validationResult.ValidationErrorString()
                    }
                };
            }

            bool result = roleManager.Roles.ToList().Any(x=>x.Name == request.RoleUpdateDto.Name && x.Id != request.RoleUpdateDto.Id);
            if (result)
            {
                return new UpdateRoleCommandResponse
                {
                    Result = new Parametres.ResponseParametres.Result
                    {
                        Success = false,
                        Message = Messages.CheckIfNameExisted
                    }
                };
            }


            var existingRole = await roleManager.FindByIdAsync(request.RoleUpdateDto.Id.ToString());
            if (existingRole == null)
            {
                return new UpdateRoleCommandResponse
                {
                    Result = new Parametres.ResponseParametres.Result
                    {
                        Success = false,
                        Message = Messages.IdNull
                    }
                };
            }

            // Mövcud rolu yeniləyin
            mapper.Map(request.RoleUpdateDto, existingRole); // Mövcud obyektin üzərində dəyişiklik

            await roleManager.UpdateAsync(existingRole);

            return new UpdateRoleCommandResponse
            {
                Result = new Parametres.ResponseParametres.Result
                {
                    Success = true,
                    Message = Messages.SuccessUpdated
                }
            };
        }
    }
}
