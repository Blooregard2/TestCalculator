using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using TextCalculator.Application.Dtos;
using TextCalculator.Application.Queries;

namespace TextCalculator.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OperacionController : ControllerBase
    {
        private readonly IOperacionesQuery _operacionesQuery;

        public OperacionController(IOperacionesQuery operacionesQuery)
        {
            _operacionesQuery = operacionesQuery;
        }

        [HttpPost("Operaciones")]
        public async Task<ActionResult<OperacionResponse>> RealizarOperacion([FromBody] OperacionRequest request)
        {
            if (request == null)
            {
                return BadRequest(new { Mensaje = "Datos de solicitud no proporcionados." });
            }

            try
            {
                
                var validationResponse = ValidarSolicitud(request);
                if (validationResponse != null)
                {
                    return BadRequest(validationResponse);
                }

                var response = await _operacionesQuery.RealizarOperacion(request);

                if (double.IsNaN(response.Total) && response.Factores == null)
                {
                  
                    return BadRequest(new { Mensaje = response.Mensaje });
                }
               
                return Ok(response);
            }
            catch (DivideByZeroException ex)
            {
              
                return BadRequest(new { Mensaje = ex.Message });
            }
            catch (Exception ex)
            {
               
                return StatusCode(500, new { Mensaje = $"Error interno del servidor: {ex.Message}" });
            }
        }

       
        private object ValidarSolicitud(OperacionRequest request)
        {
            if (string.IsNullOrWhiteSpace(request.Operacion) ||
                (request.Operacion != "+" && request.Operacion != "-" && request.Operacion != "*" && request.Operacion != "/" && request.Operacion != "!"))
            {
                return new { Mensaje = "Operación no válida. Las operaciones permitidas son: +, -, *, /, !." };
            }

            if (request.Operacion != "!" && (double.IsNaN(request.Valor1) || double.IsNaN(request.Valor2)))
            {
                return new { Mensaje = "Los valores proporcionados deben ser números válidos." };
            }

            return null;
        }
    }
}
