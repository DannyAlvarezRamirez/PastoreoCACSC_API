using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using PastoreoCACSC_API.Classes;
using PastoreoCACSC_API.Models;

namespace PastoreoCACSC_API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ApartamentosController : ControllerBase
    {
        private readonly PastoreoContext _context;

        public ApartamentosController(PastoreoContext context)
        {
            _context = context;
        }

        // POST: api/Apartamentos/search
        [HttpPost("search")]
        public IActionResult SearchApartamentos([FromBody] ApartamentosFilterRequest filters)
        {
            var response = new ApiResponse();

            try
            {
                // Execute the stored procedure with the provided filters 
                var apartamentosList = _context.SpamslApartamentos
                    .FromSqlInterpolated(
                        $"EXEC dbo.SPAMSLApartamentos @TamanoArea = {filters.TamanoArea}, @Descripcion = {filters.Descripcion}, @TipoPastoId = {filters.TipoPastoId}, @TipoTierraId = {filters.TipoTierraId}, @DrenajeId = {filters.DrenajeId}, @ExpoSolarId = {filters.ExpoSolarId}, @CapaCargaId = {filters.CapaCargaId}, @FrecuenciaUsoId = {filters.FrecuenciaUsoId}"
                    )
                    .ToList();

                // If no results, set a "no results found" response
                if (apartamentosList.Count == 0)
                {
                    response.SetResponse(true, ExitCode.Success, "No se encontraron resultados.");
                }
                else
                {
                    response.Data.AddRange(apartamentosList);
                    response.SetResponse(true, ExitCode.Success, "Resultados de búsqueda de apartamentos obtenidos correctamente.");
                }
            }
            catch (Exception ex)
            {
                response.SetResponse(false, ExitCode.ErrorServer, "Error retrieving Apartamentos search results.", ex.Message);
                return StatusCode(500, response);
            }

            return Ok(response);
        }


        // POST: api/Apartamentos/create
        [HttpPost("create")]
        public IActionResult Create([FromBody] ApartamentosCreateRequest newApartamento)
        {
            var response = new ApiResponse();

            try
            {
                // Execute the stored procedure to insert a new Apartamento record
                var id = _context.Database
                    .ExecuteSqlInterpolated($@"
                        EXEC dbo.SPAMINApartamentos 
                            @TamanoArea = {newApartamento.TamanoArea},
                            @Descripcion = {newApartamento.Descripcion},
                            @TipoPastoId = {newApartamento.TipoPastoId},
                            @TipoTierraId = {newApartamento.TipoTierraId},
                            @DrenajeId = {newApartamento.DrenajeId},
                            @ExpoSolarId = {newApartamento.ExpoSolarId},
                            @CapaCargaId = {newApartamento.CapaCargaId},
                            @FrecuenciaUsoId = {newApartamento.FrecuenciaUsoId},
                            @CreadoPor = {newApartamento.CreadoPor}
                    ");

                // Set success response after the update
                response.SetResponse(true, ExitCode.Success, "Apartamento created successfully.");
            }
            catch (Exception ex)
            {
                // Handle any errors that occur during the creation process
                response.SetResponse(false, ExitCode.ErrorServer, "Error creating Apartamento.", ex.Message);
                return StatusCode(500, response);
            }

            return Ok(response);
        }


        // PUT: api/Apartamentos/update/{id}
        [HttpPut("update/{id}")]
        public IActionResult Update(decimal id, [FromBody] ApartamentosUpdateRequest updatedApartamento)
        {
            var response = new ApiResponse();

            try
            {
                // Check if the Apartamento exists before attempting to update
                var apartamentoExists = _context.Tbammaeapartamentos.Any(a => a.Id == id);
                if (!apartamentoExists)
                {
                    response.SetResponse(false, ExitCode.ErrorNotFound, "Apartamento not found.");
                    return NotFound(response);
                }

                // Execute the stored procedure to update the Apartamento record
                _context.Database.ExecuteSqlInterpolated($@"
                    EXEC dbo.SPAMUPApartamentos 
                        @Id = {id},
                        @TamanoArea = {updatedApartamento.TamanoArea},
                        @Descripcion = {updatedApartamento.Descripcion}, 
                        @TipoPastoId = {updatedApartamento.TipoPastoId}, 
                        @TipoTierraId = {updatedApartamento.TipoTierraId}, 
                        @DrenajeId = {updatedApartamento.DrenajeId}, 
                        @ExpoSolarId = {updatedApartamento.ExpoSolarId}, 
                        @CapaCargaId = {updatedApartamento.CapaCargaId}, 
                        @FrecuenciaUsoId = {updatedApartamento.FrecuenciaUsoId}, 
                        @ModificadoPor = {updatedApartamento.ModificadoPor}
                ");

                // Set success response after the update
                response.SetResponse(true, ExitCode.Success, "Apartamento updated successfully.");
            }
            catch (Exception ex)
            {
                // Handle any errors that occur during the update
                response.SetResponse(false, ExitCode.ErrorServer, "Error updating Apartamento.", ex.Message);
                return StatusCode(500, response);
            }

            return Ok(response);
        }

        // DELETE: api/Apartamentos/delete/{id}
        [HttpDelete("delete/{id}")]
        public IActionResult Delete(decimal id)
        {
            var response = new ApiResponse();

            try
            {
                // Check if the Apartamento exists before attempting to delete
                var apartamentoExists = _context.Tbammaeapartamentos.Any(a => a.Id == id);
                if (!apartamentoExists)
                {
                    response.SetResponse(false, ExitCode.ErrorNotFound, "Apartamento not found.");
                    return NotFound(response);
                }

                // Execute the stored procedure to delete the Apartamento
                _context.Database.ExecuteSqlInterpolated($@"
                    EXEC dbo.SPAMDLApartamentos @Id = {id}
                ");

                // Set the success response after deletion
                response.SetResponse(true, ExitCode.Success, "Apartamento deleted successfully.");
            }
            catch (Exception ex)
            {
                // Handle any errors that occur during the delete operation
                response.SetResponse(false, ExitCode.ErrorServer, "Error deleting Apartamento.", ex.Message);
                return StatusCode(500, response);
            }

            return Ok(response);
        }

        // GET: api/Apartamentos/dropdownsApartamentos
        [HttpGet("dropdownsApartamentos")]
        public IActionResult GetDropdownOptions()
        {
            var response = new ApiResponse();

            try
            {
                // Assuming there are lookup tables or hardcoded values for dropdowns
                var tiposPasto = _context.TbamdettipoPastos
                    .Select(tp => new { tp.TipoPastoId, tp.Descripcion })
                    .ToList();

                var tiposTierra = _context.TbamdettipoTierras
                    .Select(tt => new { tt.TipoTierraId, tt.Descripcion })
                    .ToList();

                var drenajes = _context.Tbamdetdrenajes
                    .Select(d => new { d.DrenajeId, d.Descripcion })
                    .ToList();

                var exposSolar = _context.TbamdetexpoSolars
                    .Select(es => new { es.ExpoSolarId, es.Descripcion })
                    .ToList();

                var capasCarga = _context.TbamdetcapaCargas
                    .Select(cc => new { cc.CapaCargaId, cc.Descripcion })
                    .ToList();

                var frecuenciasUso = _context.TbamdetfrecuenciaUsos
                    .Select(fu => new { fu.FrecuenciaUsoId, fu.Descripcion })
                    .ToList();

                response.Data.Add(new
                {
                    TiposPasto = tiposPasto,
                    TiposTierra = tiposTierra,
                    Drenajes = drenajes,
                    ExposSolar = exposSolar,
                    CapasCarga = capasCarga,
                    FrecuenciasUso = frecuenciasUso
                });

                response.SetResponse(true, ExitCode.Success, "Dropdown options retrieved successfully.");
            }
            catch (Exception ex)
            {
                response.SetResponse(false, ExitCode.ErrorServer, "Error retrieving dropdown options.", ex.Message);
                return StatusCode(500, response);
            }

            return Ok(response);
        }
    }
}
