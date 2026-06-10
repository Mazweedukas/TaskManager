using TaskManagerApi.Models;

namespace TaskManagerApi.Services.Interfaces

{
    public interface IProjectService
    {
        Task<IEnumerable<Project>> GetAllAsync();
    }
}
