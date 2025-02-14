using System.ComponentModel.DataAnnotations;

namespace FidelizacionBackend.Models
{
    public class Client
    {
        
        public int ClienteId { get; set; }
        [Required]
        public string? Cedula { get; set; }
        [Required]
        public string? Nombres { get; set; }
        [Required]
        public string? Apellidos { get; set; }
        public string? Direccion { get; set; }

        public DateTime? FechaNacimiento { get; set; }
        [Required]
        public string? Genero { get; set; } 

        public string? Celular { get; set; }
        [Required]
        public string? Email { get; set; }
    }
}
