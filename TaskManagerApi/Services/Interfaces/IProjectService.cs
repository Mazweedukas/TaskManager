using TaskManagerApi.DTOs;
using TaskManagerApi.Models;

namespace TaskManagerApi.Services.Interfaces

{
    public interface IProjectService
    {
        Task<IEnumerable<Project>> GetAllAsync();
        Task<int> CreateAsync(CreateProjectDto project);
        Task<Project?> GetByIdAsync(int id);
    }
}
