using Asp_NET_Core_6_Template.Attributes;
using BusinessLayer.Interfaces;
using Common.Extensions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models.Tasks;

namespace Asp_NET_Core_6_Template.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskController : ControllerBase
    {

        private readonly ITaskService _taskService;
        public TaskController(ITaskService taskService)
        {
            _taskService = taskService;
        }

        [HttpPost]
        [Authorize]
        [Route("Task/CreateTask")]
        public async Task<ActionResult<TaskModel>> CreateTask([FromBody] TaskCreateRequest request)
        {
            request.Author = HttpContext.GetUser();
            var response = await _taskService.CreateTask(request);

            return Ok(response);
        }
    }
}
