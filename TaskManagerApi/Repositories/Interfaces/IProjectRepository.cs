using TaskManagerApi.DTOs;
using TaskManagerApi.Models;

namespace TaskManagerApi.Repositories.Interfaces;

public interface IProjectRepository
{
    Task<IEnumerable<Project>> GetAllAsync();
    Task<int> CreateAsync(CreateProjectDto project);
    Task<Project?> GetByIdAsync(int id);
}