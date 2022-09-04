using Microsoft.EntityFrameworkCore;
using Microsoft.Net.Http.Headers;
using WebShop.Models;
using WebShop.Repositories;

var builder = WebApplication.CreateBuilder(args);

// connection DB from JSON
string connection = builder.Configuration.GetConnectionString("DefaultConnection");

// добавляем контекст ApplicationContext в качестве сервиса в приложение
builder.Services.AddDbContext<ApplicationContext>(options => options.UseSqlServer(connection));

builder.Services.AddScoped<IProductRepository, ProductRepository>();//
builder.Services.AddScoped<IFileRepository, FileRepository>();//

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

var fileOptions = new StaticFileOptions
{
    OnPrepareResponse = (context) => context.Context.Response.Headers[HeaderNames.CacheControl] = "public, max-age=604800"
};

app.UseStaticFiles(fileOptions);

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
