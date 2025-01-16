using BookHive.Application.Abstracts.Services;
using BookHive.Application.CustomAttributes;
using BookHive.Application.Features.Commands.Genre.CreateGenre;
using BookHive.Application.Features.Commands.Genre.DeleteGenre;
using BookHive.Application.Features.Commands.Genre.UpdateGenre;
using BookHive.Application.Features.Queries.Genre.GetAllGenre;
using BookHive.Application.Features.Queries.Genre.GetByIdGenre;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookHive.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenresController : ControllerBase
    {
        private readonly IGenreReadRepository genreReadRepository;
        private readonly IGenreWriteRepository genreWriteRepository;
        private readonly IMediator mediator;
        public GenresController(IGenreReadRepository genreReadRepository, IGenreWriteRepository genreWriteRepository, IMediator mediator)
        {
            this.genreReadRepository = genreReadRepository;
            this.genreWriteRepository = genreWriteRepository;
            this.mediator = mediator;
        }

        #region GetGenres
        [HttpGet("GetGenres")]
        [ExecutionTimeLogger]
        public async Task<IActionResult> GetGenres([FromQuery] GetAllGenreQueryRequest getAllGenreQueryRequest)
        {
            GetAllGenreQueryResponse getAllGenreQueryResponse = await mediator.Send(getAllGenreQueryRequest);
            return Ok(getAllGenreQueryResponse);
        }
        #endregion

        #region GetGenre
        [HttpGet("GetGenre")]
        public async Task<IActionResult> GetGenre([FromQuery] GetByIdGenreQueryRequest getByIdGenreQueryRequest)
        {
            GetByIdGenreQueryResponse getByIdGenreQueryResponse = await mediator.Send(getByIdGenreQueryRequest);
            return Ok(getByIdGenreQueryResponse);
        }
        #endregion

        #region AddGenre
        [HttpPost("AddGenre")]
        public async Task<IActionResult> AddGenre([FromBody] CreateGenreCommandRequest createGenreCommandRequest)
        {
            CreateGenreCommandResponse createGenreCommandResponse = await mediator.Send(createGenreCommandRequest);
            return Ok(createGenreCommandResponse);
        }
        #endregion

        #region UpdateGenre
        [HttpPut("UpdateGenre")]
        public async Task<IActionResult> UpdateGenre([FromBody] UpdateGenreCommandRequest updateGenreCommandRequest)
        {
            UpdateGenreCommandResponse updateGenreCommandResponse = await mediator.Send(updateGenreCommandRequest);
            return Ok(updateGenreCommandResponse);
        }
        #endregion

        #region DeleteGenre
        [HttpDelete("DeleteGenre")]
        public async Task<IActionResult> DeleteGenre([FromQuery] DeleteGenreCommandRequest deleteGenreCommandRequest)
        {
            DeleteGenreCommandResponse deleteGenreCommandResponse = await mediator.Send(deleteGenreCommandRequest);
            return Ok(deleteGenreCommandResponse);
        }
        #endregion

    }
}
