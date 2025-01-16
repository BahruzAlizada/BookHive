using MediatR;

namespace BookHive.Application.Features.Queries.AuthorizationEndpoint.GetRolesToEndpoints
{
    public class GetRolesToEndpointsQueryRequest : IRequest<GetRolesToEndpointsQueryResponse>
    {
        public string Code { get; set; }
        public string Name { get; set; }
    }
}