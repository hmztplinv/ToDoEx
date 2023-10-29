public interface IWorkService
{
    Task<List<WorkListDto>> GetAllAsync();
}