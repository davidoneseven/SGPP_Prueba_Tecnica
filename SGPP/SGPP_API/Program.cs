using Microsoft.EntityFrameworkCore;
using SGPP.Application;
using SGPP.Application.Implementation;
using SGPP.Domain.Entities;
using SGPP.Domain.Repositories;
using SGPP.Infrastructure;
using SGPP.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<SGPPDbContext>(options =>
	options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<IProveedoresRepository, ProveedoresRepository>();
builder.Services.AddScoped<IProveedoresService, ProveedoresService>();

builder.Services.AddScoped<IProductosRepository, ProductosRepository>();
builder.Services.AddScoped<IProductosService, ProductosService>();

builder.Services.AddScoped<IProveedorTieneProductoRepository, ProveedorTieneProductoRepository>();
builder.Services.AddScoped<IProveedorTieneProductoService, ProveedorTieneProductoService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
