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
                // Handle different register types and map to appropriate response format
                switch (request.RegisterType.ToLower())
                {
                    case "ganado":
                        var ganado = _context.SpamslReporteGanado
                        .FromSqlInterpolated(
                            $"EXEC dbo.SPAMSLReporte @TipoRegistro = {request.RegisterType}, @TipoReporte = {request.ReportType}, @StartDate = {request.StartDate}, @EndDate = {request.EndDate ?? DateTime.Now}"
                        )
                        .ToList(); 

                        var ganadoList = ganado.Select(g => new GanadoReport
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

                    case "suministros":
                        var suministros = _context.SpamselReporteSuministros
                        .FromSqlInterpolated(
                            $"EXEC dbo.SPAMSELReporte @TipoRegistro = {request.RegisterType}, @TipoReporte = {request.ReportType}, @StartDate = {request.StartDate}, @EndDate = {request.EndDate ?? DateTime.Now}"
                        )
                        .ToList();

                        var suministroList = suministros.Select(s => new SuministrosReport
                        {
                            SuministroId = s.SuministroId,
                            Cantidad = s.Cantidad,
                            Descripcion = s.Descripcion,
                            TipoSuministro = s.TipoSuministro,
                            FechaCreacion = s.FechaCreacion
                        }).ToList();

                        response.Data.Add(suministroList.Count > 0 ? suministroList : new List<SuministrosReport>());
                        break;
                    case "apartamentos":
                        var apartamentos = _context.SpamselReporteApartamentos
                        .FromSqlInterpolated(
                            $"EXEC dbo.SPAMSELReporte @TipoRegistro = {request.RegisterType}, @TipoReporte = {request.ReportType}, @StartDate = {request.StartDate}, @EndDate = {request.EndDate ?? DateTime.Now}"
                        )
                        .ToList();

                        var apartamentosList = apartamentos.Select(a => new ApartamentosReport
                        {
                            ApartamentoId = a.ApartamentoId,
                            TamanoArea = a.TamanoArea,
                            TipoPastoId = a.TipoPastoId,
                            TipoTierraId = a.TipoTierraId,
                            ExpoSolarId = a.ExpoSolarId,
                            DrenajeId = a.DrenajeId,
                            CapaCargaId = a.CapaCargaId,
                            FrecuenciaUsoId = a.FrecuenciaUsoId,
                            FechaCreacion = a.FechaCreacion
                        }).ToList();

                        response.Data.Add(apartamentosList.Count > 0 ? apartamentosList : new List<ApartamentosReport>());
                        break;
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
