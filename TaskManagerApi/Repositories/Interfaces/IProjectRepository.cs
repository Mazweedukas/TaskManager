using TaskManagerApi.Models;

namespace TaskManagerApi.Repositories.Interfaces;

public interface IProjectRepository
{
    Task<IEnumerable<Project>> GetAllAsync();
}