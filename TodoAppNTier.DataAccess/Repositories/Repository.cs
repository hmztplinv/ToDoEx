using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

public class Repository<T> : IRepository<T> where T : class, new()
{
    private readonly TodoContext _context;
    // private readonly DbSet<T> _dbSet;

    public Repository(TodoContext context)
    {
        _context = context;
        // _dbSet = _context.Set<T>();
    }

    public async Task CreateAsync(T entity)
    {
        await _context.Set<T>().AddAsync(entity);
    }

    public async Task<List<T>> GetAllAsync()
    {
        return await _context.Set<T>().AsNoTracking().ToListAsync();
    }

    public async Task<T?> GetByFilterAsync(Expression<Func<T, bool>> filter, bool asNoTracking = false)
    {
        return asNoTracking
            ? await _context.Set<T>().FirstOrDefaultAsync(filter)
            : await _context.Set<T>().AsNoTracking().FirstOrDefaultAsync(filter);
            
    }

    public async Task<T?> GetByIdAsync(object id)
    {
        return await _context.Set<T>().FindAsync(id);
    }

    public IQueryable<T> GetQuery()
    {
        return _context.Set<T>().AsQueryable();
    }

    public void Remove(T entity)
    {
        _context.Set<T>().Remove(entity);
    }

    public void Update(T entity)
    {
        _context.Set<T>().Update(entity);
    }
}
