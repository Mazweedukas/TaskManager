using Microsoft.AspNetCore.Mvc;
using TaskManagerApi.Services.Interfaces;

namespace TaskManagerApi.Controllers;

[ApiController]
[Route("[controller]")]
public class ProjectsController : ControllerBase
{
    private readonly IProjectService _service;

    public ProjectsController(IProjectService service)
    {
        _service = service;
    }

    [HttpGet(Name = "GetProjects")]
    public async Task<IActionResult> Get()
    {
        var projects = await _service.GetAllAsync();
        return Ok(projects);
    }
}
