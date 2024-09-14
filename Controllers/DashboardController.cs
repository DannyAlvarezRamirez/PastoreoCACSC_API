using Microsoft.AspNetCore.Mvc;
using PastoreoCACSC_API.Classes;
using PastoreoCACSC_API.Models;

namespace PastoreoCACSC_API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DashboardController : ControllerBase
    {
        private readonly PastoreoContext _context;

        public DashboardController(PastoreoContext context)
        {
            _context = context;
        }

        // Endpoint to get "Cantidad de Ganado" and "Estado del Pastoreo"
        [HttpGet("getEstadoGanadoPastoreo")]
        public IActionResult GetEstadoGanadoPastoreo()
        {
            var response = new ApiResponse();

            try
            {
                // Assuming "Cantidad de Ganado" comes from a 'Ganado' table, summing or counting the records
                var cantidadGanado = _context.Tbamdetganados.Count();

                // Assuming "Estado del Pastoreo" comes from a 'Pastoreo' table, querying the current status
                var estadoPastoreo = _context.Tbamrelrotacions
                    .OrderByDescending(p => p.FechaCreacion)
                    .Select(p => p.EficienciaPastoreo)
                    .FirstOrDefault(); // Assuming 'Estado' is a string field representing the status

                // Prepare the response data
                response.Data.Add(new { Ganado = cantidadGanado, EstadoPastoreo = estadoPastoreo });
                response.SetResponse(true, ExitCode.Success, "Data retrieved successfully");
            }
            catch (Exception ex)
            {
                // Log the exception (not shown here for brevity)
                response.SetResponse(false, ExitCode.ErrorServer, "Error retrieving data", ex.Message);
                return StatusCode(500, response); // Return server error if something goes wrong
            }

            return Ok(response); // Return success response with data
        }
    }
}
