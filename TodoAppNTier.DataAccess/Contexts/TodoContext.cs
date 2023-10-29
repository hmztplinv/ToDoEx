using Microsoft.EntityFrameworkCore;

public class TodoContext : DbContext
{
    public TodoContext(DbContextOptions<TodoContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new WorkConfiguration());
        base.OnModelCreating(modelBuilder);
    }

    public DbSet<Work> Works { get; set; }
}