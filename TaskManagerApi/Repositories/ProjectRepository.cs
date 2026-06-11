using System.Data;
using TaskManagerApi.Repositories.Interfaces;
using TaskManagerApi.Models;
using Dapper;
using TaskManagerApi.DTOs.Projects;

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

    public async Task<bool> UpdateAsync(int id, UpdateProjectDto project)
    {
        const string sql = """
            UPDATE general_schema.projects
            SET name = @Name, description = @Description
            WHERE id = @Id
            """;

        var affectedRows = await _connection.ExecuteAsync(sql, new { Id = id, Name = project.Name, Description = project.Description });
        return affectedRows > 0;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        const string sql = "DELETE FROM general_schema.projects WHERE id = @Id";
        var affectedRows = await _connection.ExecuteAsync(sql, new { Id = id });
        return affectedRows > 0;
    }
}