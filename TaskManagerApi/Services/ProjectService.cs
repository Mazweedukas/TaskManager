using TaskManagerApi.Repositories.Interfaces;
using TaskManagerApi.Models;
using TaskManagerApi.Services.Interfaces;
using TaskManagerApi.DTOs.Projects;

namespace TaskManagerApi.Services;

public class ProjectService : IProjectService
{
    private readonly IProjectRepository _projectRepository;

    public ProjectService(IProjectRepository projectRepository)
    {
        _projectRepository = projectRepository;
    }

    public async Task<IEnumerable<Project>> GetAllAsync()
    {
        return await _projectRepository.GetAllAsync();
    }

    public async Task<int> CreateAsync(CreateProjectDto project)
    {
        return await _projectRepository.CreateAsync(project);
    }

    public async Task<Project?> GetByIdAsync(int id)
    {
        return await _projectRepository.GetByIdAsync(id);
    }

    public async Task<bool> UpdateAsync(int id, UpdateProjectDto project)
    {
        return await _projectRepository.UpdateAsync(id, project);
    }

    public async Task<bool> DeleteAsync(int id)
    {
        return await _projectRepository.DeleteAsync(id);
    }
}