namespace TareasAPI.Models
{
    public class Tarea
    {
        public int Id { get; set; }
         public required string Nombre { get; set; } 
        public string Descripcion { get; set; } = string.Empty;
        public bool Completada { get; set; } = false;
    }
}