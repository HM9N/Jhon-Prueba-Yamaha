using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace FidelizacionBackend.Models
{
    public class Sale
    {
        public int VentaId { get; set; }

        [Required]
        public DateTime Fecha { get; set; }

        [Required]
        [StringLength(50)]
        public string? NumeroFactura { get; set; }

        [Required]
        public int ClienteId { get; set; }

        [Required]
        public int VehiculoId { get; set; }

        [Required]
        public int TiendaId { get; set; }

        [Required]
        public int VendedorId { get; set; }

        [Required]
        public string Ciudad { get; set; }

        [Required]
        public decimal Precio { get; set; }

        public DateTime FechaRegistro { get; set; }
    }
}
