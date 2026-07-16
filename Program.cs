using DeliveryApi.Models;
using Microsoft.AspNetCore.Localization;
using System.Globalization;
using DeliveryApi.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using DeliveryApi.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

// Настройка культуры для корректного парсинга десятичных чисел
builder.Services.Configure<RequestLocalizationOptions>(options =>
{
    var invariantCulture = new CultureInfo("en-US");
    options.DefaultRequestCulture = new RequestCulture(invariantCulture);
    options.SupportedCultures = new[] { invariantCulture };
    options.SupportedUICultures = new[] { invariantCulture };
});

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlite(connectionString));

builder.Services.AddScoped<IDeliveryService, DeliveryApi.Services.DeliveryService>();

var app = builder.Build();

app.UseRouting();
app.UseRequestLocalization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();