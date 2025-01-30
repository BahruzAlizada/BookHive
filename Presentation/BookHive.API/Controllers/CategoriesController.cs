using BookHive.Application.Abstracts.Services;
using BookHive.Application.CustomAttributes;
using BookHive.Application.Features.Commands.Category.CreateCategory;
using BookHive.Application.Features.Commands.Category.DeleteCategory;
using BookHive.Application.Features.Commands.Category.UpdateCategory;
using BookHive.Application.Features.Queries.Category.GetAllCategory;
using BookHive.Application.Features.Queries.Category.GetByIdCategory;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BookHive.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly IMediator mediator;
        public CategoriesController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        #region GetAllCategory
        [HttpGet("GetAllCategory")]
        public async Task<IActionResult> GetAllCategory()
        {
            GetAllCategoryQueryResponse getAllCategoryQueryResponse = await mediator.Send(new GetAllCategoryQueryRequest());
            return Ok(getAllCategoryQueryResponse);
        }
        #endregion

        #region GetCategory
        [HttpGet("GetCategory")]
        public async Task<IActionResult> GetCategory([FromQuery] GetByIdCategoryQueryRequest getByIdCategoryQueryRequest)
        {
            GetByIdCategoryQueryResponse getByIdCategoryQueryResponse = await mediator.Send(getByIdCategoryQueryRequest);
            return Ok(getByIdCategoryQueryResponse);
        }
        #endregion

        #region AddCategory
        [HttpPost("AddCategory")]
        public async Task<IActionResult> AddCategory([FromBody] CreateCategoryCommandRequest createCategoryCommandRequest)
        {
            CreateCategoryCommandResponse createCategoryCommandResponse = await mediator.Send(createCategoryCommandRequest);
            return Ok(createCategoryCommandResponse);
        }
        #endregion

        #region UpdateCategory
        [HttpPut("UpdateCategory")]
        public async Task<IActionResult> UpdateCategory([FromBody] UpdateCategoryCommandRequest updateCategoryCommandRequest)
        {
            UpdateCategoryCommandResponse updateCategoryCommandResponse = await mediator.Send(updateCategoryCommandRequest);
            return Ok(updateCategoryCommandResponse);
        }
        #endregion

        #region DeleteCategory
        [HttpDelete("DeleteCategory")]
        public async Task<IActionResult> DeleteCategory([FromQuery] DeleteCategoryCommandRequest deleteCategoryCommandRequest)
        {
            DeleteCategoryCommandResponse deleteCategoryCommandResponse = await mediator.Send(deleteCategoryCommandRequest);
            return Ok(deleteCategoryCommandResponse);
        }
        #endregion
    }
}
