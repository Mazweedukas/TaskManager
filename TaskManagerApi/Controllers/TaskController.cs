using Microsoft.AspNetCore.Mvc;
using TaskManagerApi.DTOs.Tasks;
using TaskManagerApi.Models;
using TaskManagerApi.Services.Interfaces;

namespace TaskManagerApi.Controllers;

[ApiController]
[Route("[controller]")]
public class TasksController : ControllerBase
{
    private readonly ITaskService _taskService;
    private readonly IProjectService _projectService;

    public TasksController(ITaskService service, IProjectService projectService)
    {
        _taskService = service;
        _projectService = projectService;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var tasks = await _taskService.GetAllAsync();
        return Ok(tasks);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var task = await _taskService.GetByIdAsync(id);
        if (task is null)
            return NotFound();
        return Ok(task);
    }

    [HttpGet("projects/{projectId}/tasks")]
    public async Task<IActionResult> GetTasksByProjectId(int projectId)
    {
        var project = await _projectService.GetByIdAsync(projectId);
        if (project is null)
            return NotFound();

        var tasks = await _taskService.GetByProjectIdAsync(projectId);
        return Ok(tasks);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateTaskDto taskDto)
    {
        var id = await _taskService.CreateAsync(taskDto);
        
        return CreatedAtAction(nameof(GetById), new { id }, null);
    }

    [HttpPut]
    public async Task<IActionResult> Update(int id, [FromBody] UpdateTaskDto taskDto)
    {
        var success = await _taskService.UpdateAsync(id, taskDto);
        if (!success)
            return NotFound();
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var success = await _taskService.DeleteAsync(id);
        if (!success)
            return NotFound();
        return NoContent();
    }
}
