namespace TaskManagerApi.Repositories;

public class ProjectRepository : IProjectRepository
{
    private readonly IDbConnection _connection;

    public ProjectRepository(IDbConnection connection)
    {
        _connection = connection;
    }

    public async Task<IEnumerable<Project>> GetAllProjectsAsync()
    {
        var sql = "SELECT * FROM Projects";
        return await _connection.QueryAsync<Project>(sql);
    }
}