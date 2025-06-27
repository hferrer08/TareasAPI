using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TareasAPI.Data;
using TareasAPI.Models;

namespace TareasAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TareasController : ControllerBase
    {
        private readonly TareasContext _context;

        public TareasController(TareasContext context)
        {
            _context = context;
        }

        // GET: api/tareas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Tarea>>> GetTareas()
        {
            return await _context.Tareas.ToListAsync();
        }

       // GET: api/tareas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Tarea>> GetTarea(int id)
        {
            var tarea = await _context.Tareas.FindAsync(id);

            if (tarea == null)
                return NotFound();

            return tarea;
        } 

        [HttpGet("buscar")]
        public async Task<ActionResult<IEnumerable<Tarea>>> Buscar(
    int? id = null,
    string? nombre = null,
    bool? completada = null)
        {
            var query = _context.Tareas.AsQueryable();

            if (id.HasValue)
                query = query.Where(t => t.Id == id.Value);

            if (!string.IsNullOrWhiteSpace(nombre))
                query = query.Where(t => t.Nombre.Contains(nombre));

            if (completada.HasValue)
                query = query.Where(t => t.Completada == completada.Value);

            var resultados = await query.ToListAsync();
            return Ok(resultados);
        }

        // POST: api/tareas
        [HttpPost]
        public async Task<ActionResult<Tarea>> PostTarea(Tarea tarea)
        {
            _context.Tareas.Add(tarea);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetTarea), new { id = tarea.Id }, tarea);
        }

        // PUT: api/tareas/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTarea(int id, Tarea tarea)
        {
            if (id != tarea.Id)
                return BadRequest();

            _context.Entry(tarea).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.Tareas.Any(e => e.Id == id))
                    return NotFound();
                else
                    throw;
            }

            return NoContent();
        }

        // DELETE: api/tareas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTarea(int id)
        {
            var tarea = await _context.Tareas.FindAsync(id);

            if (tarea == null)
                return NotFound();

            _context.Tareas.Remove(tarea);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}