using Asp_NET_Core_6_Template.Attributes;
using BusinessLayer.Implementation;
using BusinessLayer.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Models.Jdoodle;

namespace Asp_NET_Core_6_Template.Controllers
{
    [ApiController]
    public class JDoodleController : ControllerBase
    {
        private readonly IJdoodleService _jdoodleService;
        public JDoodleController(IJdoodleService jdoodleService)
        {
            _jdoodleService = jdoodleService;
        }

        [HttpPost]
        [Authorize]
        [Route("JDoodle/Execute")]
        public async Task<ActionResult<JdoodleResponse>> Execute([FromBody] JdoodleRequest request)
        {
            var response = await _jdoodleService.Execute(request);

            return Ok(response);
        }
    }
}
