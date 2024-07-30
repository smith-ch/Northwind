using Microsoft.EntityFrameworkCore;
using Northwind.Orders.Domain.Interfaces;
using Northwind.Orders.Persistence.Repositories;
using Northwind.Orders.IOC.Dependencies;
using NorthwindContext.Web.BL.Services;
using Northwind.Data.Context; // Add this to reference the correct namespace for MyNorthwindContext

var builder = WebApplication.CreateBuilder(args);

// Configuración del connection string
var connstring = builder.Configuration.GetConnectionString("NorthwindContext");

// Registrar DbContext con el nombre correcto
builder.Services.AddDbContext<MyNorthwindContext>(options =>
    options.UseSqlServer(connstring));

// Registro de dependencias
builder.Services.AddScoped<InstNwnd.Web.BL.Interfaces.IOrdersService, OrdersService>();
builder.Services.AddScoped<IOrdersRepository, OrdersRepository>();

builder.Services.AddOrdersDependency();

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
