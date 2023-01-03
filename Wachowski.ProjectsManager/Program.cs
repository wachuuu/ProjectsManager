using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Wachowski.ProjectsManager.Data;
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<WachowskiProjectsManagerContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("WachowskiProjectsManagerContext") ?? throw new InvalidOperationException("Connection string 'WachowskiProjectsManagerContext' not found.")));

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Projects/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Projects}/{action=Index}/{id?}");

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    try
    {
        var context = services.GetRequiredService<WachowskiProjectsManagerContext>();
        SeedData.Initialize(context);
    } 
    catch (Exception e)
    {
        var logger = services.GetRequiredService<ILogger<Program>>();
        logger.LogError(e, "An error occurred creating the DB.");
    }
}

app.Run();
