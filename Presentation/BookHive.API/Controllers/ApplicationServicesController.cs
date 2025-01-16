using BookHive.Application.Configurations;
using BookHive.Application.ConstMessages;
using BookHive.Application.CustomAttributes;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookHive.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes ="Admin")]
    public class ApplicationServicesController : ControllerBase
    {
        private readonly IApplicationService applicationService;
        public ApplicationServicesController(IApplicationService applicationService)
        {
            this.applicationService = applicationService;
        }

        [HttpGet("GetAuthorizeDefinitionEndpoints")]
        [AuthorizeDefinition(Menu = AuthorizeDefinitionConstants.ApplicationServices, ActionType = Application.Enums.ActionType.Reading, Definition = "Methods that can be called by logging in")]
        public IActionResult GetAuthorizeDefinitionEndpoints()
        {
            var datas = applicationService.GetAuthorizeDefinitionEndpoints(typeof(Program));
            return Ok(datas);
        }
    }
}
