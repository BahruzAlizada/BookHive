using BookHive.Application.Constants;
using BookHive.Application.Extensions.FluentValidationExtension;
using BookHive.Application.Parametres.ResponseParametres;
using BookHive.Application.Validation.FluentValidation.RoleValidator;
using BookHive.Domain.Identity;
using Mapster;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace BookHive.Application.Features.Commands.AppRole.CreateRole
{
    public class CreateRoleCommandHandler : IRequestHandler<CreateRoleCommandRequest, CreateRoleCommandResponse>
    {
        private readonly RoleManager<BookHive.Domain.Identity.AppRole> roleManager;
        public CreateRoleCommandHandler(RoleManager<BookHive.Domain.Identity.AppRole> roleManager)
        {
            this.roleManager = roleManager;
        }


        public async Task<CreateRoleCommandResponse> Handle(CreateRoleCommandRequest request, CancellationToken cancellationToken)
        {
            var validationResult = await ValidationExtension.ValidatorResult(new RoleAddValidator(), request.RoleAddDto);
            if(!validationResult.Success) return new() { Result = validationResult };
            
            BookHive.Domain.Identity.AppRole appRole = request.RoleAddDto.Adapt<BookHive.Domain.Identity.AppRole>();
            IdentityResult result = await roleManager.CreateAsync(appRole);
            if (!result.Succeeded)
            {
                return new() { Result = new ErrorResult(string.Join(", ",result.Errors.Select(x => x.Description))) };
            }

            return new CreateRoleCommandResponse { Result = new SuccessResult(Messages.SuccessAdded) };
        }
    }


}
