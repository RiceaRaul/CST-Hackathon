using Asp_NET_Core_6_Template.Attributes;
using BusinessLayer.Interfaces;
using Common.Extensions;
using Microsoft.AspNetCore.Mvc;
using Models.Projects;
using Models.Tasks;

namespace Asp_NET_Core_6_Template.Controllers
{
    [ApiController]
    public class ProjectController : ControllerBase
    {
        private readonly IProjectService _projectService;
        public ProjectController(IProjectService projectService)
        {
            _projectService = projectService;
        }

        [HttpPost]
        [Authorize]
        [Route("Project/CreateProject")]
        public async Task<ActionResult<Project>> CreateProject([FromBody] CreateProjectRequest request)
        {
            request.Author = HttpContext.GetUser();
            var response = await _projectService.CreateProject(request);

            return Ok(response);
        }

        [HttpGet]
        [Authorize]
        [Route("Project/GetByUser")]
        public async Task<ActionResult<IEnumerable<Project>>> GetByUser()
        {
            string username = HttpContext.GetUser();
            var response = await _projectService.GetByUser(username);

            return Ok(response);
        }

        [HttpGet]
        [Authorize]
        [Route("Project/GetById/{id}")]
        public async Task<ActionResult<IEnumerable<TaskModel>>> GetByUser(int id)
        {
            var response = await _projectService.GetById(id);

            return Ok(response);
        }
    }
}
