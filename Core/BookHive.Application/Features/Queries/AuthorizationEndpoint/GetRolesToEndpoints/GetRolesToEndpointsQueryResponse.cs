using BookHive.Application.Parametres.ResponseParametres;

namespace BookHive.Application.Features.Queries.AuthorizationEndpoint.GetRolesToEndpoints
{
    public class GetRolesToEndpointsQueryResponse
    {
        public List<string> Roles {  get; set; }
        public Result Result { get; set; }
    }
}