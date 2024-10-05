using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PastoreoCACSC_API.Classes;
using PastoreoCACSC_API.Models;

namespace PastoreoCACSC_API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RotacionController : ControllerBase
    {
        private readonly PastoreoContext _context;

        public RotacionController(PastoreoContext context)
        {
            _context = context;
        }

        // POST: api/Rotacion/search
        [HttpPost("search")]
        public IActionResult SearchRotacion([FromBody] RotacionFilterRequest filters)
        {
            var response = new ApiResponse();

            try
            {
                // Execute the stored procedure with the provided filters 
                var rotacionList = _context.SpamslRotacion
                    .FromSqlInterpolated(
                        $"EXEC dbo.SPAMSLRotacion @ApartamentoId = {filters.ApartamentoId}, @TiempoInicio = {filters.TiempoInicio}, @TiempoFin = {filters.TiempoFin}, @Temporada = {filters.Temporada}, @TipoGanadoId = {filters.TipoGanadoId}"
                    )
                    .ToList();

                // If no results, set a "no results found" response
                if (rotacionList.Count == 0)
                {
                    response.SetResponse(true, ExitCode.Success, "No se encontraron resultados.");
                }
                else
                {
                    response.Data.AddRange(rotacionList);
                    response.SetResponse(true, ExitCode.Success, "Resultados de búsqueda de rotación obtenidos correctamente.");
                }
            }
            catch (Exception ex)
            {
                response.SetResponse(false, ExitCode.ErrorServer, "Error retrieving Rotacion search results.", ex.Message);
                return StatusCode(500, response);
            }

            return Ok(response);
        }

        // POST: api/Rotacion/create
        [HttpPost("create")]
        public IActionResult Create([FromBody] RotacionCreateRequest newRotacion)
        {
            var response = new ApiResponse();

            try
            {
                // Execute the stored procedure to insert a new Rotacion record
                var id = _context.Database
                    .ExecuteSqlInterpolated($@"
                        EXEC dbo.SPAMINRotacion 
                            @ApartamentoId = {newRotacion.ApartamentoId},
                            @TiempoInicio = {newRotacion.TiempoInicio},
                            @TiempoFin = {newRotacion.TiempoFin},
                            @Temporada = {newRotacion.Temporada},
                            @CantGanadoAct = {newRotacion.CantGanadoAct},
                            @CantMaxRec = {newRotacion.CantMaxRec},
                            @TipoGanadoId = {newRotacion.TipoGanadoId},
                            @RegistroEventos = {newRotacion.RegistroEventos},
                            @EficPast = {newRotacion.EficPast},
                            @Observaciones = {newRotacion.Observaciones},
                            @CreadoPor = {newRotacion.CreadoPor}
                    ");

                // Set success response after the creation
                response.SetResponse(true, ExitCode.Success, "Rotacion created successfully.");
            }
            catch (Exception ex)
            {
                // Handle any errors that occur during the creation process
                response.SetResponse(false, ExitCode.ErrorServer, "Error creating Rotacion.", ex.Message);
                return StatusCode(500, response);
            }

            return Ok(response);
        }

        // PUT: api/Rotacion/update/{id}
        [HttpPut("update/{id}")]
        public IActionResult Update(decimal id, [FromBody] RotacionUpdateRequest updatedRotacion)
        {
            var response = new ApiResponse();

            try
            {
                // Check if the Rotacion exists before attempting to update
                var rotacionExists = _context.Tbamrelrotacions.Any(r => r.Id == id);
                if (!rotacionExists)
                {
                    response.SetResponse(false, ExitCode.ErrorNotFound, "Rotacion not found.");
                    return NotFound(response);
                }

                // Execute the stored procedure to update the Rotacion record
                _context.Database.ExecuteSqlInterpolated($@"
                    EXEC dbo.SPAMUPRotacion 
                        @Id = {id},
                        @ApartamentoId = {updatedRotacion.ApartamentoId}, 
                        @TiempoInicio = {updatedRotacion.TiempoInicio}, 
                        @TiempoFin = {updatedRotacion.TiempoFin}, 
                        @Temporada = {updatedRotacion.Temporada}, 
                        @CantGanadoAct = {updatedRotacion.CantGanadoAct}, 
                        @CantMaxRec = {updatedRotacion.CantMaxRec},
                        @TipoGanadoId = {updatedRotacion.TipoGanadoId},
                        @RegistroEventos = {updatedRotacion.RegistroEventos},
                        @EficPast = {updatedRotacion.EficPast},
                        @Observaciones = {updatedRotacion.Observaciones},
                        @ModificadoPor = {updatedRotacion.ModificadoPor}
                ");

                // Set success response after the update
                response.SetResponse(true, ExitCode.Success, "Rotacion updated successfully.");
            }
            catch (Exception ex)
            {
                // Handle any errors that occur during the update
                response.SetResponse(false, ExitCode.ErrorServer, "Error updating Rotacion.", ex.Message);
                return StatusCode(500, response);
            }

            return Ok(response);
        }

        // DELETE: api/Rotacion/delete/{id}
        [HttpDelete("delete/{id}")]
        public IActionResult Delete(decimal id)
        {
            var response = new ApiResponse();

            try
            {
                // Check if the Rotacion exists before attempting to delete
                var rotacionExists = _context.Tbamrelrotacions.Any(r => r.Id == id);
                if (!rotacionExists)
                {
                    response.SetResponse(false, ExitCode.ErrorNotFound, "Rotacion not found.");
                    return NotFound(response);
                }

                // Execute the stored procedure to delete the Rotacion
                _context.Database.ExecuteSqlInterpolated($@"
                    EXEC dbo.SPAMDLRotacion @Id = {id}
                ");

                // Set the success response after deletion
                response.SetResponse(true, ExitCode.Success, "Rotacion deleted successfully.");
            }
            catch (Exception ex)
            {
                // Handle any errors that occur during the delete operation
                response.SetResponse(false, ExitCode.ErrorServer, "Error deleting Rotacion.", ex.Message);
                return StatusCode(500, response);
            }

            return Ok(response);
        }

        // GET: api/Rotacion/dropdownsRotacion
        [HttpGet("dropdownsRotacion")]
        public IActionResult GetDropdownOptions()
        {
            var response = new ApiResponse();

            try
            {
                // Assuming there are lookup tables or hardcoded values for dropdowns
                var apartamentos = _context.Tbammaeapartamentos
                    .Select(a => new { a.Id, a.Descripcion })
                    .ToList();

                var tiposGanado = _context.TbamcattipoGanado
                    .Select(t => new { t.Id, t.Descripcion })
                    .ToList();

                response.Data.Add(new
                {
                    Apartamentos = apartamentos,
                    TiposGanado = tiposGanado
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
