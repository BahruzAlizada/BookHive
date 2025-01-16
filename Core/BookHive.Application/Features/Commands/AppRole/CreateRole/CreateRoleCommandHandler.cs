

using AutoMapper;
using BookHive.Application.ConstMessages;
using BookHive.Application.Extensions.FluentValidationExtension;
using BookHive.Application.Validation.FluentValidation.RoleValidator;
using BookHive.Domain.Identity;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace BookHive.Application.Features.Commands.AppRole.CreateRole
{
    public class CreateRoleCommandHandler : IRequestHandler<CreateRoleCommandRequest, CreateRoleCommandResponse>
    {
        private readonly RoleManager<BookHive.Domain.Identity.AppRole> roleManager;
        private readonly IMapper mapper;
        public CreateRoleCommandHandler(RoleManager<BookHive.Domain.Identity.AppRole> roleManager, IMapper mapper)
        {
            this.roleManager = roleManager;
            this.mapper = mapper;
        }


        public async Task<CreateRoleCommandResponse> Handle(CreateRoleCommandRequest request, CancellationToken cancellationToken)
        {
            var validationResult = await new RoleAddValidator().ValidateAsync(request.RoleAddDto);
            if(!validationResult.IsValid)
            {
                return new CreateRoleCommandResponse
                {
                    Result = new Parametres.ResponseParametres.Result
                    {
                        Success = false,
                        Message = validationResult.ValidationErrorString()
                    }
                };
            }
            BookHive.Domain.Identity.AppRole appRole = mapper.Map<BookHive.Domain.Identity.AppRole>(request.RoleAddDto);
            IdentityResult result = await roleManager.CreateAsync(appRole);
            if (!result.Succeeded)
            {
                return new CreateRoleCommandResponse
                {
                    Result = new Parametres.ResponseParametres.Result
                    {
                        Success = true,
                        Message = string.Join(", ", result.Errors.Select(e => e.Description))
                    }
                };
            }

            return new CreateRoleCommandResponse
            {
                Result = new Parametres.ResponseParametres.Result
                {
                    Success = true,
                    Message = Messages.SuccessAdded
                }
            };


        }
    }


}
