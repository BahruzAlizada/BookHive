using BookHive.Application.Abstracts.Services;
using BookHive.Application.Constants;
using BookHive.Application.CustomAttributes;
using BookHive.Application.Features.Commands.Author.CreateAuthor;
using BookHive.Application.Features.Commands.Author.DeleteAuthor;
using BookHive.Application.Features.Commands.Author.UpdateAuthor;
using BookHive.Application.Features.Queries.Author.GetAllAuthor;
using BookHive.Application.Features.Queries.Author.GetAuthorById;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookHive.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    
    public class AuthorsController : ControllerBase
    {
        private readonly IAuthorReadRepository authorReadRepository;
        private readonly IAuthorWriteRepository authorWriteRepository;
        private readonly IMediator mediator;
        public AuthorsController(IAuthorReadRepository authorReadRepository, IAuthorWriteRepository authorWriteRepository, IMediator mediator)
        {
            this.authorReadRepository = authorReadRepository;  
            this.authorWriteRepository = authorWriteRepository;
            this.mediator = mediator;
        }

        #region GetAllAuthors
        [HttpGet("GetAllAuthors")]
        public async Task<IActionResult> GetAllAuthors()
        {
            GetAllAuthorQueryResponse getAllAuthorQueryResponse = await mediator.Send(new GetAllAuthorQueryRequest());
            return Ok(getAllAuthorQueryResponse);
        }
        #endregion

        #region GetAuthor
        [HttpGet("GetAuthor")]
        public async Task<IActionResult> GetAuthor([FromQuery] GetAuthorByIdQueryRequest getAuthorByIdQueryRequest)
        {
            GetAuthorByIdQueryResponse getAuthorByIdQueryResponse = await mediator.Send(getAuthorByIdQueryRequest);
            return Ok(getAuthorByIdQueryResponse);
        }
        #endregion

        #region AddAuthor
        [HttpPost("AddAuthor")]
        //[Authorize(AuthenticationSchemes = "Admin")]
        //[AuthorizeDefinition(Menu = AuthorizeDefinitionConstants.Authors, ActionType = Application.Enums.ActionType.Writing,Definition = "Add Author")]
        public async Task<IActionResult> AddAuthor([FromBody] CreateAuthorCommandRequest createAuthorCommandRequest)
        {
            CreateAuthorCommandResponse createAuthorCommandResponse = await mediator.Send(createAuthorCommandRequest);
            return Ok(createAuthorCommandResponse);
        }
        #endregion

        #region UpdateAuthor
        [HttpPut("UpdateAuthor")]
        [Authorize(AuthenticationSchemes = "Admin")]
        [AuthorizeDefinition(Menu = AuthorizeDefinitionConstants.Authors, ActionType = Application.Enums.ActionType.Updateing, Definition = "Update Author")]
        public async Task<IActionResult> UpdateAuthor([FromBody] UpdateAuthorCommandRequest updateAuthorCommandRequest)
        {
            UpdateAuthorCommandResponse updateAuthorCommandResponse = await mediator.Send(updateAuthorCommandRequest);
            return Ok(updateAuthorCommandResponse);
        }
        #endregion

        #region DeleteAuthor
        [HttpDelete("DeleteAuthor")]
        [Authorize(AuthenticationSchemes = "Admin")]
        [AuthorizeDefinition(Menu = AuthorizeDefinitionConstants.Authors, ActionType = Application.Enums.ActionType.Deleting, Definition = "Delete Author")]
        public async Task<IActionResult> DeleteAuthor([FromQuery] DeleteAuthorCommandRequest deleteAuthorCommandRequest)
        {
            DeleteAuthorCommandResponse deleteAuthorCommandResponse = await mediator.Send(deleteAuthorCommandRequest);
            return Ok(deleteAuthorCommandResponse);
        }
        #endregion
    }
}
