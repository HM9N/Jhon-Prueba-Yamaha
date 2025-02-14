using System.ComponentModel.DataAnnotations;

namespace FidelizacionBackend.DTOs
{
    public class SaleDTO
    {
        public int VentaId { get; set; }

        public DateTime Fecha { get; set; }

        public string? NumeroFactura { get; set; }

        public int ClienteId { get; set; }

        public int VehiculoId { get; set; }

        public int TiendaId { get; set; }

        public int VendedorId { get; set; }

        public string Ciudad { get; set; }

        public decimal Precio { get; set; }

        public DateTime FechaRegistro { get; set; }
    }
}
