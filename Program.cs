using DeliveryApi.Models;
using DeliveryApi.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using DeliveryApi.Data;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlite(connectionString));

builder.Services.AddScoped<IDeliveryService, DeliveryService>();

var app = builder.Build();