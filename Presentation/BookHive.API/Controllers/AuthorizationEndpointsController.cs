using BookHive.Application.Features.Commands.AuthorizationEndpoint.AssignRoleEndpoint;
using BookHive.Application.Features.Queries.AuthorizationEndpoint.GetRolesToEndpoints;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookHive.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorizationEndpointsController : ControllerBase
    {
        private readonly IMediator mediator;
        public AuthorizationEndpointsController(IMediator mediator)
        {
            this.mediator = mediator;
        }


        #region AssignRoleEndpoint
        [HttpPost]
        public async Task<IActionResult> AssignRoleEndpoint(AssignRoleEndpointCommandRequest assignRoleEndpointCommandRequest)
        {
            AssignRoleEndpointCommandResponse assignRoleEndpointCommandResponse = await mediator.Send(assignRoleEndpointCommandRequest);
            return Ok(assignRoleEndpointCommandResponse);
        }
        #endregion

        #region GetRolesToEndpoint
        [HttpGet("GetRolesToEndpoint")]
        public async Task<IActionResult> GetRolesToEndpoint([FromRoute]GetRolesToEndpointsQueryRequest getRolesToEndpointsQueryRequest)
        {
            GetRolesToEndpointsQueryResponse getRolesToEndpointsQueryResponse = await mediator.Send(getRolesToEndpointsQueryRequest);
            return Ok(getRolesToEndpointsQueryResponse);
        }
        #endregion
    }
}
