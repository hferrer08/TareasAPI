using Microsoft.EntityFrameworkCore;
using TareasAPI.Data;

var builder = WebApplication.CreateBuilder(args);

// Agregar conexión a base de datos SQLite
builder.Services.AddDbContext<TareasContext>(options =>
    options.UseSqlite("Data Source=Tareas.db"));

// Agregar servicios de controllers y endpoints
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseMiddleware<TareasAPI.Middlewares.ErrorMiddleware>();
app.MapControllers();

app.Run();