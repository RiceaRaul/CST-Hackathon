using Asp_NET_Core_6_Template.Attributes;
using BusinessLayer.Implementation;
using BusinessLayer.Interfaces;
using Common.Extensions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models.Projects;
using Models.Tasks;

namespace Asp_NET_Core_6_Template.Controllers
{
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

        [HttpGet]
        [Authorize]
        [Route("Task/GetByProject/{id}")]
        public async Task<ActionResult<IEnumerable<TaskModel>>> GetByUser(int id)
        {
            string username = HttpContext.GetUser();
            var response = await _taskService.GetByProject(id);

            return Ok(response);
        }
    }
}
