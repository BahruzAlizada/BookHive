using BookHive.Application.Abstracts.Services;
using BookHive.Application.Features.Commands.Publisher.CreatePublisher;
using BookHive.Application.Features.Commands.Publisher.DeletePublisher;
using BookHive.Application.Features.Commands.Publisher.UpdatePublisher;
using BookHive.Application.Features.Queries.Publisher.GetAllPublisher;
using BookHive.Application.Features.Queries.Publisher.GetByIdPublisher;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookHive.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PublishersController : ControllerBase
    {
        private readonly IPublisherReadRepository publisherReadRepository;
        private readonly IPublisherWriteRepository publisherWriteRepository;
        private readonly IMediator mediator;
        public PublishersController(IPublisherReadRepository publisherReadRepository, IPublisherWriteRepository publisherWriteRepository, IMediator mediator)
        {
            this.publisherReadRepository = publisherReadRepository;
            this.publisherWriteRepository = publisherWriteRepository;
            this.mediator = mediator;
        }

        #region GetAllPublishers
        [HttpGet("GetAllPublishers")]
        public async Task<IActionResult> GetAllPublishers()
        {
            GetAllPublisherQueryResponse getAllPublisherQueryResponse = await mediator.Send(new GetAllPublisherQueryRequest());
            return Ok(getAllPublisherQueryResponse);
        }
        #endregion

        #region GetPublisher
        [HttpGet("GetPublisher")]
        public async Task<IActionResult> GetPublisher([FromQuery] GetByIdPublisheQueryRequest getByIdPublisheQueryRequest)
        {
            GetByIdPublisherQueryResponse getByIdPublisherQueryResponse = await mediator.Send(getByIdPublisheQueryRequest);
            return Ok(getByIdPublisherQueryResponse);
        }
        #endregion

        #region AddPublisher
        [HttpPost("AddPublisher")]
        public async Task<IActionResult> AddPublisher([FromBody] CreatePublisherCommandRequest createPublisherCommandRequest)
        {
            CreatePublisherCommandResponse createPublisherCommandResponse = await mediator.Send(createPublisherCommandRequest);
            return Ok(createPublisherCommandResponse);
        }
        #endregion

        #region UpdatePublisher
        [HttpPut("UpdatePublisher")]
        public async Task<IActionResult> UpdatePublisher([FromBody] UpdatePublisherCommandRequest updatePublisherCommandRequest)
        {
            UpdatePublisherCommandResponse updatePublisherCommandResponse = await mediator.Send(updatePublisherCommandRequest);
            return Ok(updatePublisherCommandResponse);
        }
        #endregion

        #region DeletePublisher
        [HttpDelete("DeletePublisher")]
        public async Task<IActionResult> DeletePublisher([FromQuery] DeletePublisherCommandRequest deletePublisherCommandRequest)
        {
            DeletePublisherCommandResponse deletePublisherCommandResponse = await mediator.Send(deletePublisherCommandRequest);
            return Ok(deletePublisherCommandResponse);
        }
        #endregion
    }
}
