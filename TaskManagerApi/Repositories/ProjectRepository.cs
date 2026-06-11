using System.Data;
using TaskManagerApi.Repositories.Interfaces;
using TaskManagerApi.Models;
using Dapper;
using TaskManagerApi.DTOs;

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

    public async Task<int> CreateAsync(CreateProjectDto projectDto)
    {
        const string sql = """
            INSERT INTO general_schema.projects (name, description)
            VALUES (@Name, @Description)
            RETURNING id;
            """;

        return await _connection.ExecuteScalarAsync<int>(sql, projectDto);
    }

    public async Task<Project?> GetByIdAsync(int id)
    {
        const string sql = "SELECT * FROM general_schema.projects WHERE Id = @Id";
        return await _connection.QuerySingleOrDefaultAsync<Project>(sql, new { Id = id });
    }
}