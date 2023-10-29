public class WorkService : IWorkService
{
    private readonly IUow _uow;

    public WorkService(IUow uow)
    {
        _uow = uow;
    }

    public async Task<List<WorkListDto>> GetAllAsync()
    {
        var works = await _uow.GetRepository<Work>().GetAllAsync();
        var mappedWorks=new List<WorkListDto>();
        if (works !=null && works.Count>0)
        {
            foreach (var work in works)
            {
                mappedWorks.Add(new WorkListDto
                {
                    Id = work.Id,
                    Definition = work.Definition,
                    IsCompleted = work.IsCompleted
                });
            }
        }
        return mappedWorks;

        // return works.Select(x => new WorkListDto
        // {
        //     Id = x.Id,
        //     Definition = x.Definition,
        //     IsCompleted = x.IsCompleted
        // }).ToList();
    }
}