using System.Linq.Expressions;

public interface IRepository<T> where T : class,new()
{
    Task<List<T>> GetAllAsync();
    Task<T?> GetByIdAsync(object id);
    Task<T?> GetByFilterAsync(Expression<Func<T, bool>> filter,bool asNoTracking = false);
    Task CreateAsync(T entity);
    void Update(T entity);
    void Remove(T entity);
    IQueryable<T> GetQuery();
}
