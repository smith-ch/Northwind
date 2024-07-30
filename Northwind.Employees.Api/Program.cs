using Microsoft.EntityFrameworkCore;
using Northwind.Employees.IOC.Dependencies;
using Northwind.Data.Context;
using Northwind.Employees.Application.Contracts;
using Northwind.Employees.Application.Services;


var builder = WebApplication.CreateBuilder(args);

// Configuración del connection string
var connstring = builder.Configuration.GetConnectionString("NorthwindContext");

// Registrar DbContext con el nombre correcto
builder.Services.AddDbContext<NorthwindDbContext>(options =>
    options.UseSqlServer(connstring));

// Registro de dependencias
builder.Services.AddScoped<IEmployeesService, EmployeesService>();


builder.Services.AddEmployeesDependency();

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
