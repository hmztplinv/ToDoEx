public interface IWorkService
{
    Task<List<WorkListDto>> GetAllAsync();

    Task CreateAsync(WorkCreateDto dto);

    Task<WorkListDto?> GetByIdAsync(int id);

    Task Remove(object id);

    Task Update(WorkUpdateDto dto);


}