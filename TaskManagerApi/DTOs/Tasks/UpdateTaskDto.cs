namespace TaskManagerApi.DTOs.Tasks
{
    public class UpdateTaskDto
    {
        public int ProjectId { get; set; }
        public string Description { get; set; } = string.Empty;
        public DateTime DueDate { get; set; }
        public string Status { get; set; } = string.Empty;
    }
}
