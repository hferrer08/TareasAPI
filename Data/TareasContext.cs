using Microsoft.EntityFrameworkCore;
using TareasAPI.Models;

namespace TareasAPI.Data
{
    public class TareasContext : DbContext
    {
        public TareasContext(DbContextOptions<TareasContext> options) : base(options) { }

        public DbSet<Tarea> Tareas => Set<Tarea>();
    }
}