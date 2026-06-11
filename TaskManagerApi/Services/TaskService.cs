using TaskManagerApi.DTOs.Tasks;
using TaskManagerApi.Repositories.Interfaces;
using TaskManagerApi.Services.Interfaces;

namespace TaskManagerApi.Services;

public class TaskService : ITaskService
{
    private readonly ITaskRepository _taskRepository;
    public TaskService(ITaskRepository taskRepository)
    {
        _taskRepository = taskRepository;
    }
    public async Task<IEnumerable<Models.Task>> GetAllAsync()
    {
        return await _taskRepository.GetAllAsync();
    }
    public async Task<int> CreateAsync(CreateTaskDto task)
    {
        return await _taskRepository.CreateAsync(task);
    }
    public async Task<Models.Task?> GetByIdAsync(int id)
    {
        return await _taskRepository.GetByIdAsync(id);
    }
    public async Task<bool> UpdateAsync(int id, UpdateTaskDto task)
    {
        return await _taskRepository.UpdateAsync(id, task);
    }
    public async Task<bool> DeleteAsync(int id)
    {
        return await _taskRepository.DeleteAsync(id);
    }
}
