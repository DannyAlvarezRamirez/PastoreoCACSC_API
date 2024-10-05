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
                var cantidadGanado = _context.Tbammaeganados.Count();

                // Get the latest 'EficPast' value from the 'Pastoreo' table (ordered by creation date)
                var eficPast = _context.Tbamrelrotacions
                    .OrderByDescending(p => p.FechaCreacion)
                    .Select(p => p.EficPast)
                    .FirstOrDefault();

                // Determine 'EstadoPastoreo' based on 'EficPast' value
                string estadoPastoreo = DetermineEstadoPastoreo(eficPast);

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

        // Helper method to determine 'Estado del Pastoreo' based on 'EficPast' value
        private string DetermineEstadoPastoreo(decimal? eficPast)
        {
            if (!eficPast.HasValue)
                return "Unknown"; // Handle null values or missing data

            if (eficPast > 80)
                return "Excellent";
            else if (eficPast > 60)
                return "Good";
            else if (eficPast > 40)
                return "Moderate";
            else if (eficPast > 20)
                return "Poor";
            else
                return "Critical";
        }
    }
}
