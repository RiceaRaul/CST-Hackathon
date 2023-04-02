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
        
        [HttpGet]
        [Authorize]
        [Route("Authentification/GetUserDetails")]
        public async Task<ActionResult<User>> GetUserDetails()
        {
            var user = HttpContext.GetUser();
            var response = await _authentificationService.GetUserDetails(user);

            return Ok(response);
        }    
        
        [HttpGet]
        [Authorize]
        [Route("Authentification/GetLeaderBoard")]
        public async Task<ActionResult<IEnumerable<User>>> GetLeaderBoard()
        {
            var user = HttpContext.GetUser();
            var response = await _authentificationService.GetLeaderBoard();

            return Ok(response);
        }


        [HttpPost]
        [AllowAnonymous]
        [Route("Authentification/CreateUser")]
        public async Task<ActionResult<User>> CreateUser([FromBody] RegisterRequest request)
        {
            var response = await _authentificationService.CreateUser(request);

            return Ok(response);
        }
        
        [HttpPost]
        [Authorize]
        [Route("Authentification/UpdateExp")]
        public async Task<ActionResult<bool>> UpdateExp([FromBody] UpdateExpRequest  request)
        {
            request.user = HttpContext.GetUser();
            var response = await _authentificationService.UpdateExp(request);

            return Ok(response);
        }
    }
}
