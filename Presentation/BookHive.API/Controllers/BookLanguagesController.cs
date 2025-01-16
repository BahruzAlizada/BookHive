using BookHive.Application.Abstracts.Services;
using BookHive.Application.CustomAttributes;
using BookHive.Application.Features.Commands.BookLanguage;
using BookHive.Application.Features.Queries.BookLanguage;
using BookHive.Application.Features.Queries.BookLanguage.GetByIdBookLanguage;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookHive.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookLanguagesController : ControllerBase
    {
        private readonly IBookLanguageReadRepository bookLanguageReadRepository;
        private readonly IBookLanguageWriteRepository bookLanguageWriteRepository;
        private readonly IMediator mediator;
        public BookLanguagesController(IBookLanguageReadRepository bookLanguageReadRepository, IBookLanguageWriteRepository bookLanguageWriteRepository,
            IMediator mediator)
        {
            this.bookLanguageReadRepository = bookLanguageReadRepository;   
            this.bookLanguageWriteRepository = bookLanguageWriteRepository;
            this.mediator = mediator;
        }

        #region GetAllBookLanguages
        [HttpGet("GetAllBookLanguages")]
        [SleepMode(startHour:24, endHour:6)]
        [IPBlacklist]
        public async Task<IActionResult> GetAllBookLanguages()
        {
            GetAllBookLanguageQueryResponse getAllBookLanguageQueryResponse = await mediator.Send(new GetAllBookLanguageQueryRequest());
            return Ok(getAllBookLanguageQueryResponse);
        }
        #endregion

        #region GetByIdBookLanguage
        [HttpGet("GetByIdBookLanguage")]
        public async Task<IActionResult> GetByIdBookLanguage([FromQuery]GetByIdBookLanguageQueryRequest getByIdBookLanguageQueryRequest)
        {
            GetByIdBookLanguageQueryResponse getByIdBookLanguageQueryResponse = await mediator.Send(getByIdBookLanguageQueryRequest);
            return Ok(getByIdBookLanguageQueryResponse);
        }
        #endregion

        #region AddBookLanguage
        [HttpPost("AddBookLanguage")]
        public async Task<IActionResult> AddBookLanguage([FromBody] CreateBookLanguageCommandRequest createBookLanguageCommandRequest)
        {
            CreateBookLanguageCommandResponse createBookLanguageCommandResponse = await mediator.Send(createBookLanguageCommandRequest);
            return Ok(createBookLanguageCommandResponse);
        }
        #endregion

        #region UpdateBookLanguage
        [HttpPut("UpdateBookLanguage")]
        public async Task<IActionResult> UpdateBookLanguage([FromBody] UpdateBookLanguageCommandRequest updateBookLanguageCommandRequest)
        {
            UpdateBookLanguageCommandResponse updateBookLanguageCommandResponse = await mediator.Send(updateBookLanguageCommandRequest);
            return Ok(updateBookLanguageCommandResponse);
        }
        #endregion

        #region DeleteBookLanguage
        [HttpDelete("DeleteBookLanguage")]
        public async Task<IActionResult> DeleteBookLanguage([FromQuery] DeleteBookLanguageCommandRequest deleteBookLanguageCommandRequest)
        {
            DeleteBookLanguageCommandResponse deleteBookLanguageCommandResponse = await mediator.Send(deleteBookLanguageCommandRequest);
            return Ok(deleteBookLanguageCommandResponse);
        }
        #endregion

    }
}
