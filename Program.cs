using Microsoft.EntityFrameworkCore;
using TareasAPI.Data;
 using System.IO;

var builder = WebApplication.CreateBuilder(args);
//Conexión base de datos
var baseDir = AppDomain.CurrentDomain.BaseDirectory;
var dbPath = Path.Combine(baseDir, "Tareas.db");
var connectionString = $"Data Source={dbPath}";

builder.Services.AddDbContext<TareasContext>(options =>
    options.UseSqlite(connectionString));

// Agregar servicios de controllers y endpoints
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

//if (app.Environment.IsDevelopment())
//{
    app.UseSwagger();
    app.UseSwaggerUI();
//}

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll",
        builder => builder.AllowAnyOrigin()
                          .AllowAnyMethod()
                          .AllowAnyHeader());
});

app.UseCors("AllowAll");

app.MapControllers();

app.Run();