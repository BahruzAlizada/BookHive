using BookHive.Application.Features.Commands.AppUser.LoginUser;
using BookHive.Application.Features.Commands.AppUser.PasswordReset;
using BookHive.Application.Features.Commands.AppUser.RefreshTokenLogin;
using BookHive.Application.Features.Commands.AppUser.RegisterUser;
using BookHive.Application.Features.Commands.AppUser.VerifyResetToken;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookHive.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IMediator mediator;
        public AuthController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        #region Register
        [HttpPost("Register")]
        public async Task<IActionResult> Register(RegisterUserCommandRequest registerUserCommandRequest)
        {
            RegisterUserCommandResponse registerUserCommandResponse = await mediator.Send(registerUserCommandRequest);
            return Ok(registerUserCommandResponse);
        }
        #endregion

        #region Login
        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody] LoginUserCommandRequest loginUserCommandRequest)
        {
            LoginUserCommandResponse loginUserCommandResponse = await mediator.Send(loginUserCommandRequest);
            return Ok(loginUserCommandResponse);
        }
        #endregion

        #region RefreshTokenLogin
        [HttpGet("RefreshTokenLogin")]
        public async Task<IActionResult> RefreshTokenLogin([FromQuery] RefreshTokenLoginCommandRequest refreshTokenLoginCommandRequest)
        {
            RefreshTokenLoginCommandResponse refreshTokenLoginCommandResponse = await mediator.Send(refreshTokenLoginCommandRequest);
            return Ok(refreshTokenLoginCommandResponse);
        }
        #endregion

        #region ResetPassword
        [HttpPost("ResetPassword")]
        public async Task<IActionResult> ResetPassword([FromQuery] PasswordResetCommandRequest passwordResetCommandRequest)
        {
            PasswordResetCommandResponse passwordResetCommandResponse = await mediator.Send(passwordResetCommandRequest);
            return Ok(passwordResetCommandResponse);
        }
        #endregion

        #region VerifyResetToken
        [HttpPost("VerifyResetToken")]
        public async Task<IActionResult> VerifyResetToken(VerifyResetTokenCommandRequest verifyResetTokenCommandRequest)
        {
            VerifyResetTokenCommandResponse verifyResetTokenCommandResponse = await mediator.Send(verifyResetTokenCommandRequest);
            return Ok(verifyResetTokenCommandResponse);
        }
        #endregion
    }
}
