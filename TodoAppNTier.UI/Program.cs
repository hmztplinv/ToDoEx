using Microsoft.Extensions.FileProviders;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDependencies();
builder.Services.AddControllersWithViews();

var app = builder.Build();

app.MapDefaultControllerRoute();

// app.UseStaticFiles();
app.UseStaticFiles(new StaticFileOptions
{
    FileProvider = new PhysicalFileProvider(
        Path.Combine(Directory.GetCurrentDirectory(), "node_modules")),
    RequestPath = "/node_modules"
});

app.Run();
