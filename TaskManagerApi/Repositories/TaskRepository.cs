using Dapper;
using System.Data;
using TaskManagerApi.DTOs.Tasks;
using TaskManagerApi.Repositories.Interfaces;

namespace TaskManagerApi.Repositories
{
    public class TaskRepository : ITaskRepository
    {
        private readonly IDbConnection _connection;

        public TaskRepository(IDbConnection connection)
        {
            _connection = connection;
        }

        public async Task<int> CreateAsync(CreateTaskDto task)
        {
            const string sql = """
                INSERT INTO general_schema.tasks (projectId, description, dueDate, status)
                VALUES (@ProjectId, @Description, @DueDate, @Status)
                RETURNING id;
                """;
            return await _connection.ExecuteScalarAsync<int>(sql, task);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            const string sql = """DELETE FROM general_schema.tasks WHERE id = @Id""";
                 
            var affectedRows = await _connection.ExecuteAsync(sql, new { Id = id });
            return affectedRows > 0;
        }

        public async Task<IEnumerable<Models.Task>> GetAllAsync()
        {
            var sql = """
                SELECT * FROM general_schema.tasks;
                """;
            return await _connection.QueryAsync<Models.Task>(sql);
        }

        public async Task<Models.Task?> GetByIdAsync(int id)
        {
            var sql = """
                SELECT * FROM general_schema.tasks 
                WHERE id = @id;
                """;
            return await _connection.QueryFirstOrDefaultAsync<Models.Task>(sql, new { id });
        }

        public async Task<bool> UpdateAsync(int id, UpdateTaskDto task)
        {
            const string sql = """
                UPDATE general_schema.tasks
                SET projectId = @ProjectId,
                    description = @Description,
                    dueDate = @DueDate,
                    status = @Status
                WHERE id = @Id;
                """;
            var affectedRows = await _connection.ExecuteAsync(sql, new { 
                Id = id, 
                ProjectId = task.ProjectId, 
                Description = task.Description, 
                DueDate = task.DueDate, 
                Status = task.Status 
            });

            return affectedRows > 0;
        }

        public async Task<IEnumerable<Models.Task>> GetByProjectIdAsync(int projectId)
        {
            const string sql = """
                SELECT * FROM general_shcema.tasks
                WHERE projectId = @ProjectId;
                """;

            return await _connection.QueryAsync<Models.Task>(sql, new { ProjectId = projectId });
        }
    }
}
