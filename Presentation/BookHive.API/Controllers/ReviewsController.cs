using BookHive.Application.Features.Commands.Review.CreateReply;
using BookHive.Application.Features.Commands.Review.CreateReview;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookHive.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReviewsController : ControllerBase
    {
        private readonly IMediator mediator;
        public ReviewsController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        #region AddReview
        [HttpPost("AddReview")]
        public async Task<IActionResult> AddReview([FromBody] CreateReviewCommandRequest createReviewCommandRequest)
        {
            CreateReviewCommandResponse createReviewCommandResponse = await mediator.Send(createReviewCommandRequest);
            return Ok(createReviewCommandResponse);
        }
        #endregion

        #region AddReply
        [HttpPost("AddReply")]
        public async Task<IActionResult> AddReply([FromBody] CreateReplyCommandRequest createReplyCommandRequest)
        {
            CreateReplyCommandResponse createReplyCommandResponse = await mediator.Send(createReplyCommandRequest);
            return Ok(createReplyCommandResponse);
        }
        #endregion
    }
}
