using TaskManagerApi.Repositories.Interfaces;
using TaskManagerApi.Models;

namespace TaskManagerApi.Repositories;

public class ProjectRepository : IProjectRepository
{
    private readonly IDbConnection _connection;

    public ProjectRepository(IDbConnection connection)
    {
        _connection = connection;
    }

    public async Task<IEnumerable<Project>> GetAllAsync()
    {
        var sql = "SELECT * FROM general_schema.projects";
        return await _connection.QueryAsync<Project>(sql);
    }
}