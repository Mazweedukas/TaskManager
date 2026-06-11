using TaskManagerApi.DTOs.Projects;
using TaskManagerApi.Models;

namespace TaskManagerApi.Repositories.Interfaces
{
    public interface ITaskRepository
    {
        Task<IEnumerable<Models.Task>> GetAllAsync();
        Task<int> CreateAsync(CreateProjectDto project);
        Task<Models.Task?> GetByIdAsync(int id);
        Task<bool> DeleteAsync(int id);
        Task<bool> UpdateAsync(int id, UpdateProjectDto project);
    }
}
