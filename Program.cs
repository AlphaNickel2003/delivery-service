using DeliveryApi.Models;
using DeliveryApi.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using DeliveryApi.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlite(connectionString));

builder.Services.AddScoped<IDeliveryService, DeliveryApi.Services.DeliveryService>();

var app = builder.Build();

app.UseRouting();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();