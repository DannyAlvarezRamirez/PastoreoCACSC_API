using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PastoreoCACSC_API.Classes;
using PastoreoCACSC_API.Models;

namespace PastoreoCACSC_API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ReporteController : ControllerBase
    {
        private readonly PastoreoContext _context;

        public ReporteController(PastoreoContext context)
        {
            _context = context;
        }

        // POST: api/Reporte/generate
        [HttpPost("generate")]
        public IActionResult GenerateReport([FromBody] ReporteRequest request)
        {
            var response = new ApiResponse();

            try
            {
                // Execute the stored procedure based on the registerType (ganado, suministro, departamento)
                var reportData = _context.SpamselReporteGanado
                    .FromSqlInterpolated(
                        $"EXEC dbo.SPAMSELReporteGanado @TipoRegistro = {request.RegisterType}, @TipoReporte = {request.ReportType}, @StartDate = {request.StartDate}, @EndDate = {request.EndDate ?? DateTime.Now}"
                    )
                    .ToList();

                // Handle different register types and map to appropriate response format
                switch (request.RegisterType.ToLower())
                {
                    case "ganado":
                        var ganadoList = reportData.Select(g => new GanadoReport
                        {
                            GanadoId = g.GanadoId,
                            RazaId = g.RazaId,
                            Peso = g.Peso,
                            FechaNacimiento = g.FechaNacimiento,
                            TratamientoId = g.TratamientoId,
                            ProductividadId = g.ProductividadId,
                            UltimoChequeo = g.UltimoChequeo,
                            EstadoSaludId = g.EstadoSaludId,
                            Edad = g.Edad,
                            SexoId = g.SexoId,
                            FechaCreacion = g.FechaCreacion
                        }).ToList(); 

                        response.Data.Add(ganadoList.Count > 0 ? ganadoList : new List<GanadoReport>());
                        break;

                    case "suministro":
                        // Logic to handle suministro when added to the stored procedure
                        response.SetResponse(false, ExitCode.ErrorNotFound, "Suministro report type not yet implemented.");
                        return Ok(response);

                    case "departamento":
                        // Logic to handle departamento when added to the stored procedure
                        response.SetResponse(false, ExitCode.ErrorNotFound, "Departamento report type not yet implemented.");
                        return Ok(response);

                    default:
                        response.SetResponse(false, ExitCode.ErrorInvalidRequest, "Invalid registerType specified.");
                        return BadRequest(response);
                }

                // Set the response
                response.SetResponse(true, ExitCode.Success, $"{request.RegisterType} report generated successfully.");
            }
            catch (Exception ex)
            {
                response.SetResponse(false, ExitCode.ErrorServer, "Error generating report.", ex.Message);
                return StatusCode(500, response);
            }

            return Ok(response);
        }
    }
}
