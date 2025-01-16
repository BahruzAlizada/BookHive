using BookHive.Application.CustomAttributes;
using BookHive.Application.Features.Commands.AppUser.DeleteUser;
using BookHive.Application.Features.Commands.AppUser.LoginUser;
using BookHive.Application.Features.Commands.AppUser.PasswordReset;
using BookHive.Application.Features.Commands.AppUser.RefreshTokenLogin;
using BookHive.Application.Features.Commands.AppUser.RegisterUser;
using BookHive.Application.Features.Commands.AppUser.UpdateUser;
using BookHive.Application.Features.Commands.AppUser.VerifyResetToken;
using BookHive.Application.Features.Queries.AppUser.GetAllUser;
using BookHive.Application.Features.Queries.AppUser.GetByIdUser;
using BookHive.Domain.Identity;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BookHive.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly UserManager<AppUser> userManager;
        private readonly IMediator mediator;
        public UsersController(UserManager<AppUser> userManager, IMediator mediator)
        {
            this.userManager = userManager;
            this.mediator = mediator;
        }

        #region GetAllUser
        [HttpGet("GetAllUser")]
        [Authorize(AuthenticationSchemes ="Admin")]
        [ContextualUserLogging]
        public async Task<IActionResult> GetAllUser()
        {
            GetAllUserQueryResponse getAllUserQueryResponse = await mediator.Send(new GetAllUserQueryRequest());
            return Ok(getAllUserQueryResponse);
        }
        #endregion

        #region GetByIdUser
        [HttpGet("GetByIdUser")]
        public async Task<IActionResult> GetByIdUser([FromQuery] GetByIdUserQueryRequest getByIdUserQueryRequest)
        {
            GetByIdUserQueryResponse getByIdUserQueryResponse = await mediator.Send(getByIdUserQueryRequest);
            return Ok(getByIdUserQueryResponse);
        }
        #endregion

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

        #region UpdateUser
        [HttpPut("UpdateUser")]
        public async Task<IActionResult> UpdateUser([FromBody] UpdateUserCommandRequest updateUserCommandRequest)
        {
            UpdateUserCommandResponse updateUserCommandResponse = await mediator.Send(updateUserCommandRequest);
            return Ok(updateUserCommandResponse);
        }
        #endregion

        #region DeleteUser
        [HttpDelete("DeleteUser")]
        public async Task<IActionResult> DeleteUser([FromQuery] DeleteUserCommandRequest deleteUserCommandRequest)
        {
            DeleteUserCommandResponse deleteUserCommandResponse = await mediator.Send(deleteUserCommandRequest);
            return Ok(deleteUserCommandResponse);
        }
        #endregion

    }
}
