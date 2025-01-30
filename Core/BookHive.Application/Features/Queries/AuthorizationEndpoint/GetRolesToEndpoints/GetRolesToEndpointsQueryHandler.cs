

using BookHive.Application.Abstracts.Services;
using BookHive.Application.Constants;
using MediatR;

namespace BookHive.Application.Features.Queries.AuthorizationEndpoint.GetRolesToEndpoints
{
    public class GetRolesToEndpointsQueryHandler : IRequestHandler<GetRolesToEndpointsQueryRequest, GetRolesToEndpointsQueryResponse>
    {
        private readonly IMenuReadRepository menuReadRepository;
        public GetRolesToEndpointsQueryHandler(IMenuReadRepository menuReadRepository)
        {
            this.menuReadRepository = menuReadRepository;
        }


        public async Task<GetRolesToEndpointsQueryResponse> Handle(GetRolesToEndpointsQueryRequest request, CancellationToken cancellationToken)
        {
            List<string> roles = await menuReadRepository.GetRolesToEndpointAsync(request.Code,request.Name);
            return new GetRolesToEndpointsQueryResponse
            {
                Roles = roles,
                Result = new Parametres.ResponseParametres.Result
                {
                    Success = true,
                    Message = Messages.SuccessListed
                }
            };
        }
    }
}
