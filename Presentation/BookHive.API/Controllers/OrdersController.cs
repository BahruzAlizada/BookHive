using BookHive.Application.Features.Commands.Order.CreateOrder;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookHive.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IMediator mediator;
        public OrdersController(IMediator mediator)
        {
            this.mediator = mediator;
        }


        #region CreateOrder
        [HttpPost("CreateOrder")]
        public async Task<IActionResult> CreateOrder()
        {
            CreateOrderCommandResponse createOrderCommandResponse = await mediator.Send(new CreateOrderCommandRequest());
            return Ok(createOrderCommandResponse);
        }
        #endregion
    }
}
