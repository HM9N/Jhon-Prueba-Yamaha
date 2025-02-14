using FidelizacionBackend.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FidelizacionBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private IClientService _clientService;

        public ClientController(IClientService clientService)
        {
            _clientService = clientService;
        }

        [HttpGet("getClients")]
        public async Task<IActionResult> GetClients()
        {
            try
            {
                var clients = await _clientService.GetClientsAsync();

                if (clients == null || !clients.Any())
                    return NotFound(new
                    {
                        is_success = false,
                        Message = "No se encontraron Clientes con los criterios especificados."
                    });

                return Ok(new
                {
                    is_success = true,
                    Message = "Clientes encontrados",
                    Data = clients
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

        [HttpPost("saveClient")]
        public async Task<ActionResult<IActionResult>> SaveClient([FromBody] ClientDTO client)
        {
            if (client == null || !ModelState.IsValid)
            {
                return BadRequest(new
                {
                    is_success = false,
                    Message = "La información del cliente es inválida o incompleta",
                });
            }

            try
            {
                var result = await _clientService.SaveClientAsync(client);

                if (result)
                {
                    return Ok(new
                    {
                        is_success = true,
                        Message = "Cliente creado correctamente",
                    });
                }

                return StatusCode(StatusCodes.Status500InternalServerError, new
                {
                    is_success = false,
                    Message = "No se pudo crear el lciente debido a un error interno",
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
