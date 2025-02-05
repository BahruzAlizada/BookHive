using BookHive.Application.Features.Commands.Friendship.ResponseRequestFriend;
using BookHive.Application.Features.Commands.Friendship.SendRequestFriend;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookHive.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FriendshipsController : ControllerBase
    {
        private readonly IMediator mediator;
        public FriendshipsController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        #region SendFriendRequest
        [HttpPost("SendFriendRequest")]
        public async Task<IActionResult> SendFriendRequest([FromBody] SendRequestFriendCommandRequest sendRequestFriendCommandRequest)
        {
            SendRequestFriendCommandResponse sendRequestFriendCommandResponse = await mediator.Send(sendRequestFriendCommandRequest);
            return Ok(sendRequestFriendCommandResponse);
        }
        #endregion

        #region RespondToFriendRequest
        [HttpPost("RespondToFriendRequest")]
        public async Task<IActionResult> RespondToFriendRequest([FromBody] ResponseRequestFriendCommandRequest responseRequestFriendCommandRequest)
        {
            ResponseRequestFriendCommandResponse responseRequestFriendCommandResponse = await mediator.Send(responseRequestFriendCommandRequest);
            return Ok(responseRequestFriendCommandResponse);
        }
        #endregion
    }
}
