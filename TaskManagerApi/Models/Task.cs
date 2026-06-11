namespace TaskManagerApi.Models
{
    public class Task
    {
        public int Id { get; set; }
        public int ProjectId { get; set; }
        public string Description { get; set; } = string.Empty;
        public DateTime DueDate { get; set; }
        public string Status { get; set; } = string.Empty;
    }
}
