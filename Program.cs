using Microsoft.EntityFrameworkCore;
using TareasAPI.Data;
using System.IO;

var builder = WebApplication.CreateBuilder(args);

// Conexión base de datos
var baseDir = AppDomain.CurrentDomain.BaseDirectory;
var dbPath = Path.Combine(baseDir, "Tareas.db");
var connectionString = $"Data Source={dbPath}";

builder.Services.AddDbContext<TareasContext>(options =>
    options.UseSqlite(connectionString));

// Configurar CORS antes de construir la app
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll",
        builder => builder.AllowAnyOrigin()
                          .AllowAnyMethod()
                          .AllowAnyHeader());
});

// Servicios
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Middlewares en orden correcto
app.UseCors("AllowAll");

app.UseSwagger();
app.UseSwaggerUI();

app.MapControllers();

app.Run();
