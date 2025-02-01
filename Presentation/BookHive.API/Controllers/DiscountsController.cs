using BookHive.Application.Features.Commands.Discount.ApplyDiscountToBook;
using BookHive.Application.Features.Commands.Discount.ApplyDiscountToGenre;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookHive.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DiscountsController : ControllerBase
    {
        private readonly IMediator mediator;
        public DiscountsController(IMediator mediator)
        {
            this.mediator = mediator;
        }


        #region DiscountToBook
        [HttpPost("DiscountToBook")]
        public async Task<IActionResult> DiscountToBook([FromBody] ApplyDiscountToBookCommandRequest applyDiscountToBookCommandRequest)
        {
            ApplyDiscountToBookCommandResponse applyDiscountToBookCommandResponse = await mediator.Send(applyDiscountToBookCommandRequest);
            return Ok(applyDiscountToBookCommandResponse);
        }
        #endregion

        #region DiscountToGenre
        [HttpPost("DiscountToGenre")]
        public async Task<IActionResult> DiscountToGenre([FromBody] ApplyDiscountToGenreCommandRequest applyDiscountToGenreCommandRequest)
        {
            ApplyDiscountToGenreCommandResponse applyDiscountToGenreCommandResponse = await mediator.Send(applyDiscountToGenreCommandRequest);
            return Ok(applyDiscountToGenreCommandResponse);
        }
        #endregion
    }
}
