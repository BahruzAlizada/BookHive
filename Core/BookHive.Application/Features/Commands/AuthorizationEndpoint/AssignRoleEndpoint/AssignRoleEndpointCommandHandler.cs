
using BookHive.Application.Abstracts.Services;
using BookHive.Application.Constants;
using MediatR;

namespace BookHive.Application.Features.Commands.AuthorizationEndpoint.AssignRoleEndpoint
{
    public class AssignRoleEndpointCommandHandler : IRequestHandler<AssignRoleEndpointCommandRequest, AssignRoleEndpointCommandResponse>
    {
        private readonly IMenuWriteRepository menuWriteRepository;
        public AssignRoleEndpointCommandHandler(IMenuWriteRepository menuWriteRepository)
        {
           this.menuWriteRepository = menuWriteRepository;
        }

        public async Task<AssignRoleEndpointCommandResponse> Handle(AssignRoleEndpointCommandRequest request, CancellationToken cancellationToken)
        {
            await menuWriteRepository.AssignRoleEndpointAsync(request.Roles, request.Menu, request.Code, request.Type);
            return new AssignRoleEndpointCommandResponse
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
