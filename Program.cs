using System.Reflection;
using Microsoft.EntityFrameworkCore;
using ProjetoBase.Data;
using ProjetoBase.Interfaces;
using ProjetoBase.Services;

var builder = WebApplication.CreateBuilder(args);

ConfigurationManager configuration = builder.Configuration;

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<EntityContext>(
    options =>
    {
        options.UseSqlite(configuration.GetConnectionString("ProjetoBaseDB")
         ?? throw new InvalidOperationException("Connection string not found."),
        sqlite =>
             {
                 sqlite.MigrationsAssembly(Assembly.GetExecutingAssembly().FullName);
             }
        );
    });

//Dependencias
builder.Services.AddScoped<IUserService, UserService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
