using Microsoft.EntityFrameworkCore;
using TareasAPI.Data;

var builder = WebApplication.CreateBuilder(args);

// Agregar conexión a base de datos SQLite
builder.Services.AddDbContext<TareasContext>(options =>
    options.UseSqlite("Data Source=Tareas.db"));

// Agregar servicios de controllers y endpoints
builder.Services.AddControllers();

var app = builder.Build();

app.MapControllers();

app.Run();