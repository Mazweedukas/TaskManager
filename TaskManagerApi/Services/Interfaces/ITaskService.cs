using TaskManagerApi.DTOs.Tasks;

namespace TaskManagerApi.Services.Interfaces
{
    public interface ITaskService
    {
        Task<IEnumerable<Models.Task>> GetAllAsync();
        Task<int> CreateAsync(CreateTaskDto task);
        Task<Models.Task?> GetByIdAsync(int id);
        Task<bool> DeleteAsync(int id);
        Task<bool> UpdateAsync(int id, UpdateTaskDto task);
    }
}
