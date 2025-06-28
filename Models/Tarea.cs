using System.ComponentModel.DataAnnotations;
namespace TareasAPI.Models
{
    public class Tarea
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El nombre es obligatorio")]
        [StringLength(100, ErrorMessage = "El nombre no puede tener más de 100 caracteres")]
        public string Nombre { get; set; } = string.Empty;

        [StringLength(250, ErrorMessage = "La descripción no puede tener más de 250 caracteres")]
        public string Descripcion { get; set; } = string.Empty;
        public bool Completada { get; set; } = false;
    }
}