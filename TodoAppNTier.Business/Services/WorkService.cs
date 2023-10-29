public class WorkService : IWorkService
{
    private readonly IUow _uow;

    public WorkService(IUow uow)
    {
        _uow = uow;
    }

    public async Task CreateAsync(WorkCreateDto dto)
    {
        await _uow.GetRepository<Work>().CreateAsync(new Work
        {
            Definition = dto.Definition,
            IsCompleted = dto.IsCompleted
        });
        await _uow.SaveChanges();
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

    public async Task<WorkListDto?> GetByIdAsync(int id)
    {
        var work = await _uow.GetRepository<Work>().GetByIdAsync(id);
        if (work == null)
        {
            return null;
        }

        return new WorkListDto
        {
            Id = work.Id,
            Definition = work.Definition,
            IsCompleted = work.IsCompleted
        };
    }

    public async Task Remove(object id)
    {
        var work = await _uow.GetRepository<Work>().GetByIdAsync(id);
        if (work == null)
        {
            return;
        }

        _uow.GetRepository<Work>().Remove(work);
        await _uow.SaveChanges();
    }

    public async Task Update(WorkUpdateDto dto)
    {
        var work = await _uow.GetRepository<Work>().GetByIdAsync(dto.Id);
        if (work == null)
        {
            return;
        }

        work.Definition = dto.Definition;
        work.IsCompleted = dto.IsCompleted;
        await _uow.SaveChanges();
    }
}