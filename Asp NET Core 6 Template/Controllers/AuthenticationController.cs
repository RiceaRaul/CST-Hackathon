using BusinessLayer.Interfaces;
using Common.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Models.Authentification;

namespace Asp_NET_Core_6_Template.Controllers
{
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IAuthentificationService _authentificationService;
        public AuthenticationController(IAuthentificationService authentificationService)
        {
            _authentificationService = authentificationService;
        }

        [HttpPost]
        [AllowAnonymous]
        [Route("Authentification/Auth")]
        public async Task<ActionResult<AuthentificationResponse>> Auth([FromBody] AuthentificationRequest request)
        {
            var response = await _authentificationService.Authentificate(request);

            return Ok(response);
        }

        [HttpGet]
        [Authorize]
        [Route("Authentification/GetUser")]
        public ActionResult GetUser()
        {
            var response = HttpContext.GetUser();
            return Ok( new { username = response});
        }

        [HttpPost]
        [AllowAnonymous]
        [Route("Authentification/CreateUser")]
        public async Task<ActionResult<User>> CreateUser([FromBody] RegisterRequest request)
        {
            var response = await _authentificationService.CreateUser(request);

            return Ok(response);
        }
    }
}
