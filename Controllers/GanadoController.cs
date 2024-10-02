using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using PastoreoCACSC_API.Classes;
using PastoreoCACSC_API.Models;

namespace PastoreoCACSC_API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GanadoController : ControllerBase
    {
        private readonly PastoreoContext _context;

        public GanadoController(PastoreoContext context)
        {
            _context = context;
        }

        // POST: api/Ganado/search
        [HttpPost("search")]
        public IActionResult SearchGanado([FromBody] GanadoFilterRequest filters)
        {
            var response = new ApiResponse();

            try
            {
                // Execute the stored procedure with the provided filters 
                var ganadoList = _context.SpamslGanado
                    .FromSqlInterpolated(
                        $"EXEC dbo.SPAMSLGanado @RazaId = {filters.RazaId}, @Peso = {filters.Peso}, @SexoId = {filters.SexoId}, @Edad = {filters.Edad}, @EstadoSaludId = {filters.EstadoSaludId}, @UltimoChequeo = {filters.FechaChequeo}, @ProductividadId = {filters.ProductividadId}, @TratamientoId = {filters.TratamientosId}, @FechaNacimiento = {filters.FechaNacimiento}"
                    )
                    .ToList();

                // If no results, set a "no results found" response
                if (ganadoList.Count == 0)
                {
                    response.SetResponse(true, ExitCode.Success, "No se encontraron resultados.");
                }
                else
                {
                    response.Data.AddRange(ganadoList);
                    response.SetResponse(true, ExitCode.Success, "Resultados de búsqueda de ganado obtenidos correctamente.");
                }
            }
            catch (Exception ex)
            {
                response.SetResponse(false, ExitCode.ErrorServer, "Error retrieving Ganado search results.", ex.Message);
                return StatusCode(500, response);
            }

            return Ok(response);
        }


        // POST: api/Ganado/create
        [HttpPost("create")]
        public IActionResult Create([FromBody] GanadoCreateRequest newGanado)
        {
            var response = new ApiResponse();

            try
            {
                // Execute the stored procedure to insert a new Ganado record
                var ganadoId = _context.Tbammaeganados
                    .FromSqlInterpolated($@"
                        EXEC dbo.SPAMINGanado 
                            @RazaId = {newGanado.RazaId},
                            @Peso = {newGanado.Peso},
                            @SexoId = {newGanado.SexoId},
                            @Edad = {newGanado.Edad},
                            @EstadoSaludId = {newGanado.EstadoSaludId},
                            @UltimoChequeo = {newGanado.UltimoChequeo},
                            @ProductividadId = {newGanado.ProductividadId},
                            @TratamientoId = {newGanado.TratamientoId},
                            @FechaNacimiento = {newGanado.FechaNacimiento},
                            @CreadoPor = {newGanado.CreadoPor}
                    ")
                    .AsEnumerable() // Retrieve the inserted Ganado ID from the result set
                    .FirstOrDefault()?.GanadoId;

                // Check if the Ganado was successfully created
                if (ganadoId != null)
                {
                    response.SetResponse(true, ExitCode.Success, "Ganado created successfully.");
                    response.Data.Add(new { GanadoId = ganadoId });
                }
                else
                {
                    response.SetResponse(false, ExitCode.ErrorServer, "Error creating Ganado.");
                }
            }
            catch (Exception ex)
            {
                // Handle any errors that occur during the creation process
                response.SetResponse(false, ExitCode.ErrorServer, "Error creating Ganado.", ex.Message);
                return StatusCode(500, response);
            }

            return Ok(response);
        }


        // PUT: api/Ganado/update/{id}
        [HttpPut("update/{id}")]
        public IActionResult Update(decimal id, [FromBody] GanadoUpdateRequest updatedGanado)
        {
            var response = new ApiResponse();

            try
            {
                // Check if the Ganado exists before attempting to update
                var ganadoExists = _context.Tbammaeganados.Any(g => g.GanadoId == id);
                if (!ganadoExists)
                {
                    response.SetResponse(false, ExitCode.ErrorNotFound, "Ganado not found.");
                    return NotFound(response);
                }

                // Execute the stored procedure to update the Ganado record
                _context.Database.ExecuteSqlInterpolated($@"
                    EXEC dbo.SPAMUPGanado 
                        @GanadoId = {id},
                        @RazaId = {updatedGanado.RazaId}, 
                        @Peso = {updatedGanado.Peso}, 
                        @SexoId = {updatedGanado.SexoId}, 
                        @Edad = {updatedGanado.Edad}, 
                        @EstadoSaludId = {updatedGanado.EstadoSaludId}, 
                        @UltimoChequeo = {updatedGanado.UltimoChequeo}, 
                        @ProductividadId = {updatedGanado.ProductividadId}, 
                        @TratamientoId = {updatedGanado.TratamientoId}, 
                        @FechaNacimiento = {updatedGanado.FechaNacimiento}, 
                        @ModificadoPor = {updatedGanado.ModificadoPor}
                ");

                // Set success response after the update
                response.SetResponse(true, ExitCode.Success, "Ganado updated successfully.");
            }
            catch (Exception ex)
            {
                // Handle any errors that occur during the update
                response.SetResponse(false, ExitCode.ErrorServer, "Error updating Ganado.", ex.Message);
                return StatusCode(500, response);
            }

            return Ok(response);
        }

        // DELETE: api/Ganado/delete/{id}
        [HttpDelete("delete/{id}")]
        public IActionResult Delete(decimal id)
        {
            var response = new ApiResponse();

            try
            {
                // Check if the Ganado exists before attempting to delete
                var ganadoExists = _context.Tbammaeganados.Any(g => g.GanadoId == id);
                if (!ganadoExists)
                {
                    response.SetResponse(false, ExitCode.ErrorNotFound, "Ganado not found.");
                    return NotFound(response);
                }

                // Execute the stored procedure to delete the Ganado
                _context.Database.ExecuteSqlInterpolated($@"
                    EXEC dbo.SPAMDLGanado @GanadoId = {id}
                ");

                // Set the success response after deletion
                response.SetResponse(true, ExitCode.Success, "Ganado deleted successfully.");
            }
            catch (Exception ex)
            {
                // Handle any errors that occur during the delete operation
                response.SetResponse(false, ExitCode.ErrorServer, "Error deleting Ganado.", ex.Message);
                return StatusCode(500, response);
            }

            return Ok(response);
        }

        // GET: api/Ganado/dropdownsGanado
        [HttpGet("dropdownsGanado")]
        public IActionResult GetDropdownOptions()
        {
            var response = new ApiResponse();

            try
            {
                // Assuming there are lookup tables or hardcoded values for dropdowns
                var razas = _context.Tbamdetrazas
                    .Select(r => new { r.RazaId, r.Descripcion })
                    .ToList();

                var sexos = _context.Tbamdetsexos
                    .Select(s => new { s.SexoId, s.Descripcion })
                    .ToList();

                var estadosSalud = _context.TbamdetestadoSaluds
                    .Select(es => new { es.EstadoSaludId, es.Descripcion })
                    .ToList();

                var productividades = _context.Tbamdetproductividads
                    .Select(p => new { p.ProductividadId, p.Descripcion })
                    .ToList();

                var tratamientos = _context.Tbamdettratamientos
                    .Select(t => new { t.TratamientoId, t.Descripcion })
                    .ToList();

                response.Data.Add(new
                {
                    Razas = razas,
                    Sexos = sexos,
                    EstadosSalud = estadosSalud,
                    Productividades = productividades,
                    Tratamientos = tratamientos
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
