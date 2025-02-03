using BookHive.Application.Abstracts.Services.EntityFramework;
using BookHive.Application.Features.Commands.Book.CreateBook;
using BookHive.Application.Features.Commands.Book.DeleteBook;
using BookHive.Application.Features.Commands.Book.UpdateBook;
using BookHive.Application.Features.Queries.Book.GetAllBook;
using BookHive.Application.Features.Queries.Book.GetByIdBook;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookHive.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IMediator mediator;
        public BooksController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        #region GetAllBooks
        [HttpGet("GetAllBooks")]
        public async Task<IActionResult> GetAllBooks()
        {
            GetAllBookQueryResponse getAllBookQueryResponse = await mediator.Send(new GetAllBookQueryRequest());
            return Ok(getAllBookQueryResponse);
        }
        #endregion

        #region GetBook
        [HttpGet("GetBook")]
        public async Task<IActionResult> GetBook([FromQuery] GetByIdBookQueryRequest getByIdBookQueryRequest)
        {
            GetByIdBookQueryResponse getByIdBookQueryResponse = await mediator.Send(getByIdBookQueryRequest);
            return Ok(getByIdBookQueryResponse);
        }
        #endregion

        #region AddBook
        [HttpPost("AddBook")]
        public async Task<IActionResult> AddBook([FromBody] CreateBookCommandRequest createBookCommandRequest)
        {
            CreateBookCommandResponse createBookCommandResponse = await mediator.Send(createBookCommandRequest);
            return Ok(createBookCommandResponse);
        }
        #endregion

        #region UpdateBook
        [HttpPut("UpdateBook")]
        public async Task<IActionResult> UpdateBook([FromBody] UpdateBookCommandRequest updateBookCommandRequest)
        {
            UpdateBookCommandResponse updateBookCommandResponse = await mediator.Send(updateBookCommandRequest);
            return Ok(updateBookCommandResponse);
        }
        #endregion

        #region DeleteBook
        [HttpDelete("DeleteBook")]
        public async Task<IActionResult> DeleteBook([FromQuery] DeleteBookCommandRequest deleteBookCommandRequest)
        {
            DeleteBookCommandResponse deleteBookCommandResponse = await mediator.Send(deleteBookCommandRequest);
            return Ok(deleteBookCommandResponse);
        }
        #endregion
    }
}
