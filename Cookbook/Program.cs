using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Cookbook.Data;
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<CookbookContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("CookbookContext") ?? throw new InvalidOperationException("Connection string 'CookbookContext' not found.")));

// if (builder.Environment.IsDevelopment())
// {
//     builder.Services.AddDbContext<CookbookContext>(options =>
//         options.UseSqlite(builder.Configuration.GetConnectionString("CookbookContext")));
// }
// else
// {
//     builder.Services.AddDbContext<CookbookContext>(options =>
//         options.UseSqlServer(builder.Configuration.GetConnectionString("ProductionCookbookContext")));
// }

// Add services to the container.
builder.Services.AddControllersWithViews();

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
