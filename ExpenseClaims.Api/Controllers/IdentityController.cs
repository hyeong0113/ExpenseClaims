using AspNetCoreHero.Results;
using ExpenseClaims.Application.DTOs.Identity;
using ExpenseClaims.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ExpenseClaims.Api.Controllers
{
    [Route("api/identity")]
    [ApiController]
    public class IdentityController : ControllerBase
    {
        private readonly IIdentityService _identityService;

        public IdentityController(IIdentityService identityService)
        {
            this._identityService = identityService;
        }

        /// <summary>
        /// Generates a JSON Web Token for a valid combination of emailId and password.
        /// </summary>
        /// <param name="tokenRequest"></param>
        /// <returns></returns>
        [HttpPost("token", Name = "GetToken")]
        [AllowAnonymous]
        public async Task<ActionResult<Result<TokenResponse>>> GetTokenAsync(TokenRequest tokenRequest)
        {
            var ipAddress = GenerateIPAddress();
            var token = await _identityService.GetTokenAsync(tokenRequest, ipAddress);
            return Ok(token);
        }

        [HttpPost("register", Name = "Register")]
        public async Task<IActionResult> RegisterAsync(RegisterRequest request)
        {
            var origin = Request.Headers["origin"];
            return Ok(await _identityService.RegisterAsync(request, origin));
        }

        [HttpGet("confirm-email", Name = "ConfirmEmail")]
        [AllowAnonymous]
        public async Task<IActionResult> ConfirmEmailAsync([FromQuery] string userId, [FromQuery] string code)
        {
            return Ok(await _identityService.ConfirmEmailAsync(userId, code));
        }

        [HttpPost("forgot-password", Name = "ForgotPassword")]
        [AllowAnonymous]
        public async Task<IActionResult> ForgotPassword(ForgotPasswordRequest model)
        {
            await _identityService.ForgotPassword(model, Request.Headers["origin"]);
            return Ok();
        }

        [HttpPost("reset-password", Name = "ResetPassword")]
        [AllowAnonymous]
        public async Task<IActionResult> ResetPassword(ResetPasswordRequest model)
        {
            return Ok(await _identityService.ResetPassword(model));
        }

        private string GenerateIPAddress()
        {
            if (Request.Headers.ContainsKey("X-Forwarded-For"))
                return Request.Headers["X-Forwarded-For"];
            else
                return HttpContext.Connection.RemoteIpAddress.MapToIPv4().ToString();
        }
    }
}