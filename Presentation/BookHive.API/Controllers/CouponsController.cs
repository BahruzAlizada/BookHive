using BookHive.Application.Features.Commands.Coupon.CreateCoupon;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookHive.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CouponsController : ControllerBase
    {
        private readonly IMediator mediator;
        public CouponsController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        #region CreateCoupon
        [HttpPost("CreateCoupon")]
        public async Task<IActionResult> CreateCoupon([FromBody]CreateCouponCommandRequest createCouponCommandRequest)
        {
            CreateCouponCommandResponse createCouponCommandResponse = await mediator.Send(createCouponCommandRequest);
            return Ok(createCouponCommandResponse);
        }
        #endregion
    }
}
