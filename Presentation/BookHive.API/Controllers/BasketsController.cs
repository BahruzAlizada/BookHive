using BookHive.Application.Features.Commands.Basket.AddItemToBasket;
using BookHive.Application.Features.Commands.Basket.ApplyCouponToBasket;
using BookHive.Application.Features.Commands.Basket.ClearBasket;
using BookHive.Application.Features.Commands.Basket.DeleteBasketItem;
using BookHive.Application.Features.Commands.Basket.UpdateQuantity;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookHive.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BasketsController : ControllerBase
    {
        private readonly IMediator mediator;
        public BasketsController(IMediator mediator)
        {
            this.mediator = mediator;
        }


        #region AddItemToBasket
        [HttpPost("AddItemToBasket")]
        public async Task<IActionResult> AddItemToBasket([FromBody] AddItemToBasketCommandRequest addItemToBasketCommandRequest)
        {
            AddItemToBasketCommandResponse addItemToBasketCommandResponse = await mediator.Send(addItemToBasketCommandRequest);
            return Ok(addItemToBasketCommandResponse);
        }
        #endregion

        #region UpdateQuantity
        [HttpPut("UpdateQuantity")]
        public async Task<IActionResult> UpdateQuantity([FromBody] UpdateQuantityCommandRequest updateQuantityCommandRequest)
        {
            UpdateQuantityCommandResponse updateQuantityCommandResponse = await mediator.Send(updateQuantityCommandRequest);
            return Ok(updateQuantityCommandResponse);
        }
        #endregion

        #region ApplyCouponToBasket
        [HttpPost("ApplyCouponToBasket")]
        public async Task<IActionResult> ApplyCouponToBasket([FromBody] ApplyCouponToBasketCommandRequest applyCouponToBasketCommandRequest)
        {
            ApplyCouponToBasketCommandResponse applyCouponToBasketCommandResponse = await mediator.Send(applyCouponToBasketCommandRequest);
            return Ok(applyCouponToBasketCommandResponse);
        }
        #endregion

        #region DeleteBasketItem
        [HttpDelete("DeleteBasketItem")]
        public async Task<IActionResult> DeleteBasketItem([FromQuery] DeleteBasketItemCommandRequest deleteBasketItemCommandRequest)
        {
            DeleteBasketItemCommandResponse deleteBasketItemCommandResponse = await mediator.Send(deleteBasketItemCommandRequest);
            return Ok(deleteBasketItemCommandResponse);
        }
        #endregion

        #region ClearBasket
        [HttpDelete("ClearBasket")]
        public async Task<IActionResult> ClearBasket()
        {
            ClearBasketCommandResponse clearBasketCommandResponse = await mediator.Send(new ClearBasketCommandRequest());
            return Ok(clearBasketCommandResponse);
        }
        #endregion

    }
}
