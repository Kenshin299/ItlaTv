using Application.Repositories;
using Application.Services;
using Database.Contexts;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ItlaTvDbContext>(options => options.UseSqlServer(connectionString));

builder.Services.AddTransient<SeriesRepository>();
builder.Services.AddTransient<ProducerRepository>();
builder.Services.AddTransient<GenreRepository>();

builder.Services.AddScoped<SeriesService>();
builder.Services.AddScoped<ProducerService>();
builder.Services.AddScoped<GenreService>();


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
