using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

public static class DependencyExtension
{
    public static void AddDependencies(this IServiceCollection services)
    {
        services.AddDbContext<TodoContext>(options =>
        {
            options.UseSqlServer("Server=localhost;Database=TodoAppDb;Trusted_Connection=True;TrustServerCertificate=true;");
        });
        // services.AddScoped<IWorkDal, EfWorkDal>();
        // services.AddScoped<IWorkService, WorkManager>();
    }
}