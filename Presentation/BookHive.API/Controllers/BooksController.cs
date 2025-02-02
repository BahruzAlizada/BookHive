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



//Author - 7b0d6156-76d6-4360-b530-08dd2f698902
//Publisher - 2a73a6bb-7a72-4cc6-aed7-08dd2f3fb736
//Book Language - bf734254-87df-42bb-5035-08dd2b620e14
//Book Status - dbeb1c7e-0a00-44f7-ec14-08dd2bf5c4fc
//Genre - 7ecec695-31b3-4f7c-cc76-08dd2fdb1e9a