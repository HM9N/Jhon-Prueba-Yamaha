using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FidelizacionBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SalesController : ControllerBase
    {
        private ISaleService _saleService;

        public SaleController(ISaleService saleService)
        {
            _saleService = saleService;
        }

        [HttpGet("GetSales")]
        public async Task<IActionResult> GetSales()
        {
            try
            {
                var sales = await _saleService.GetSalesAsync();

                if (sales == null || !sales.Any())
                    return NotFound(new
                    {
                        is_success = false,
                        Message = "No se encontraron ventas"
                    });

                return Ok(new
                {
                    is_success = true,
                    Message = "Ventas encontrados",
                    Data = sales
                });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new
                {
                    is_success = false,
                    Message = "Ocurrió un error inesperado: " + ex.Message
                });
            }
        }

        [HttpPost("saveSale")]
        public async Task<ActionResult<IActionResult>> SaveSale([FromBody] SaleDTO sale)
        {
            if (sale == null || !ModelState.IsValid)
            {
                return BadRequest(new
                {
                    is_success = false,
                    Message = "La información de la venta es inválida o incompleta",
                });
            }

            try
            {
                var result = await _saleService.SaveSaleAsync(sale);

                if (result)
                {
                    return Ok(new
                    {
                        is_success = true,
                        Message = "Venta creada correctamente",
                    });
                }

                return StatusCode(StatusCodes.Status500InternalServerError, new
                {
                    is_success = false,
                    Message = "No se pudo crear la venta debido a un error interno",
                });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new
                {
                    is_success = false,
                    ex.Message,
                });
            }
        }
    }
}
