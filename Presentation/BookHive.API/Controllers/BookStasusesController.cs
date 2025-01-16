using BookHive.Application.Abstracts.Services;
using BookHive.Application.Features.Commands.BookStatus.CreateBookStatus;
using BookHive.Application.Features.Commands.BookStatus.DeleteBookStatus;
using BookHive.Application.Features.Commands.BookStatus.UpdateBookStatus;
using BookHive.Application.Features.Queries.BookStatus.GetAllBookStatus;
using BookHive.Application.Features.Queries.BookStatus.GetByIdBookStatus;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookHive.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookStasusesController : ControllerBase
    {
        private readonly IBookStatusReadRepository bookStatusReadRepository;
        private readonly IBookStatusWriteRepository bookStatusWriteRepository;
        private readonly IMediator mediator;
        public BookStasusesController(IBookStatusReadRepository bookStatusReadRepository,IBookStatusWriteRepository bookStatusWriteRepository, IMediator mediator)
        {
            this.bookStatusReadRepository = bookStatusReadRepository;
            this.bookStatusWriteRepository = bookStatusWriteRepository;
            this.mediator = mediator;
        }

        #region GetAllBookStatuses
        [HttpGet("GetAllBookStatuses")]
        public async Task<IActionResult> GetAllBookStatuses()
        {
            GetAllBookStatusQueryResponse getAllBookStatusQueryResponse = await mediator.Send(new GetAllBookStatusQueryRequest());
            return Ok(getAllBookStatusQueryResponse);
        }
        #endregion

        #region GetByIdBookStatus
        [HttpGet("GetByIdBookStatus")]
        public async Task<IActionResult> GetByIdBookStatus([FromQuery] GetByIdBookStatusQueryRequest getByIdBookStatusQueryRequest)
        {
            GetByIdBookStatusQueryResponse getByIdBookStatusQueryResponse = await mediator.Send(getByIdBookStatusQueryRequest);
            return Ok(getByIdBookStatusQueryResponse);
        }
        #endregion

        #region AddBookStatus
        [HttpPost("AddBookStatus")]
        public async Task<IActionResult> AddBookStatus([FromBody] CreateBookStatusCommandRequest createBookStatusCommandRequest)
        {
            CreateBookStatusCommandResponse createBookStatusCommandResponse = await mediator.Send(createBookStatusCommandRequest);
            return Ok(createBookStatusCommandResponse);
        }
        #endregion

        #region UpdateBookStatus
        [HttpPut("UpdateBookStatus")]
        public async Task<IActionResult> UpdateBookStatus([FromBody] UpdateBookStatusCommandRequest updateBookStatusCommandRequest)
        {
            UpdateBookStatusCommandResponse updateBookStatusCommandResponse = await mediator.Send(updateBookStatusCommandRequest);
            return Ok(updateBookStatusCommandResponse);
        }
        #endregion

        #region DeleteBookStatus
        [HttpDelete("DeleteBookStatus")]
        public async Task<IActionResult> DeleteBookStatus([FromQuery] DeleteBookStatusCommandRequest deleteBookStatusCommandRequest)
        {
            DeleteBookStatusCommandResponse deleteBookStatusCommandResponse = await mediator.Send(deleteBookStatusCommandRequest);
            return Ok(deleteBookStatusCommandResponse);
        }
        #endregion
    }
}
