using System.ComponentModel.DataAnnotations;

namespace FidelizacionBackend.DTOs
{
    public class ClientDTO
    {
        public int ClienteId { get; set; }
        public string Cedula { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string Direccion { get; set; }
        public DateTime? FechaNacimiento { get; set; }
        public string Genero { get; set; }
        public string Celular { get; set; }
        public string Email { get; set; }
    }
}
