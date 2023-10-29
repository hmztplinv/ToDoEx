using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

public class TodoContextFactory : IDesignTimeDbContextFactory<TodoContext>
{
    public TodoContext CreateDbContext(string[] args)
    {
        var builder = new DbContextOptionsBuilder<TodoContext>();
        builder.UseSqlServer("Server=localhost;Database=TodoAppDb;Trusted_Connection=True;TrustServerCertificate=true;");
        return new TodoContext(builder.Options);
    }
}