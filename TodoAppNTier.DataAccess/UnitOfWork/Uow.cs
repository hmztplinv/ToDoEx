
public class Uow : IUow
{
    private readonly TodoContext _context;

    public Uow(TodoContext context)
    {
        _context = context;
    }

    public IRepository<T> GetRepository<T>() where T : class, new()
    {
        return new Repository<T>(_context);
    }

    public async Task SaveChangesAsync()
    {
        await _context.SaveChangesAsync();
    }
}