using TaskManagerApi.DTOs.Projects;
using TaskManagerApi.Models;

namespace TaskManagerApi.Services.Interfaces

{
    public interface IProjectService
    {
        Task<IEnumerable<Project>> GetAllAsync();
        Task<int> CreateAsync(CreateProjectDto project);
        Task<Project?> GetByIdAsync(int id);
        Task<bool> DeleteAsync(int id);
        Task<bool> UpdateAsync(int id, UpdateProjectDto project);
    }
}
