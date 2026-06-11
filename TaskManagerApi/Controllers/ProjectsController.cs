using Microsoft.AspNetCore.Mvc;
using TaskManagerApi.DTOs;
using TaskManagerApi.Services;
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

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var project = await _service.GetByIdAsync(id);
        if (project is null)
            return NotFound();
        return Ok(project);
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateProjectDto dto)
    {
        var id = await _service.CreateAsync(dto);

        return CreatedAtAction(
            nameof(GetById),
            new { id },
            null);
    }
}
