using TaskManagerApi.DTOs.Tasks;
using TaskManagerApi.Models;

namespace TaskManagerApi.Repositories.Interfaces
{
    public interface ITaskRepository
    {
        Task<IEnumerable<Models.Task>> GetAllAsync();
        Task<int> CreateAsync(CreateTaskDto task);
        Task<Models.Task?> GetByIdAsync(int id);
        Task<bool> DeleteAsync(int id);
        Task<bool> UpdateAsync(int id, UpdateTaskDto task);
        Task<IEnumerable<Models.Task>> GetByProjectIdAsync(int projectId);

    }
}
