using BookHive.Application.Features.Commands.AppRole.CreateRole;
using BookHive.Application.Features.Commands.AppRole.DeleteRole;
using BookHive.Application.Features.Commands.AppRole.UpdateRole;
using BookHive.Application.Features.Queries.AppRole.GetAllRoles;
using BookHive.Application.Features.Queries.AppRole.GetByIdRole;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookHive.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RolesController : ControllerBase
    {
        private readonly IMediator mediator;
        public RolesController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        #region GetRoles
        [HttpGet("GetRoles")]
        public async Task<IActionResult> GetRoles()
        {
            GetAllRoleQueryResponse getAllRoleQueryResponse = await mediator.Send(new GetAllRoleQueryRequest());
            return Ok(getAllRoleQueryResponse);
        }
        #endregion

        #region GetRole
        [HttpGet("GetRole")]
        public async Task<IActionResult> GetRole([FromQuery] GetByIdRoleQueryRequest getByIdRoleQueryRequest)
        {
            GetByIdRoleQueryResponse getByIdRoleQueryResponse = await mediator.Send(getByIdRoleQueryRequest);
            return Ok(getByIdRoleQueryResponse);
        }
        #endregion

        #region AddRole
        [HttpPost("AddRole")]
        public async Task<IActionResult> AddRole([FromBody] CreateRoleCommandRequest createRoleCommandRequest)
        {
            CreateRoleCommandResponse createRoleCommandResponse = await mediator.Send(createRoleCommandRequest);
            return Ok(createRoleCommandResponse);
        }
        #endregion

        #region UpdateRole
        [HttpPut("UpdateRole")]
        public async Task<IActionResult> UpdateRole([FromBody] UpdateRoleCommandRequest updateRoleCommandRequest)
        {
            UpdateRoleCommandResponse updateRoleCommandResponse = await mediator.Send(updateRoleCommandRequest);
            return Ok(updateRoleCommandResponse);
        }
        #endregion

        #region DeleteRole
        [HttpDelete("DeleteRole")]
        public async Task<IActionResult> DeleteRole([FromQuery] DeleteRoleCommandRequest deleteRoleCommandRequest)
        {
            DeleteRoleCommandResponse deleteRoleCommandResponse = await mediator.Send(deleteRoleCommandRequest);
            return Ok(deleteRoleCommandResponse);
        }
        #endregion
    }
}
