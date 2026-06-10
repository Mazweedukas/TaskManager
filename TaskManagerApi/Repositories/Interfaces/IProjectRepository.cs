interface IRepository
{
    Task<IEnumerable<Project>> GetAllAsync();
}