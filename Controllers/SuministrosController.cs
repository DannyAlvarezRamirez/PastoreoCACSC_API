using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using PastoreoCACSC_API.Classes;
using PastoreoCACSC_API.Models;

namespace PastoreoCACSC_API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SuministrosController : ControllerBase
    {
        private readonly PastoreoContext _context;

        public SuministrosController(PastoreoContext context)
        {
            _context = context;
        }

        // POST: api/Suministros/search
        [HttpPost("search")]
        public IActionResult SearchSuministros([FromBody] SuministrosFilterRequest filters)
        {
            var response = new ApiResponse();

            try
            {
                // Execute the stored procedure with the provided filters 
                var suministrosList = _context.SpamslSuministros
                    .FromSqlInterpolated(
                        $"EXEC dbo.SPAMSLSuministros @Cantidad = {filters.Cantidad}, @Descripcion = {filters.Descripcion}, @TipoSuministroId = {filters.TipoSuministroId}"
                    )
                    .ToList();

                // If no results, set a "no results found" response
                if (suministrosList.Count == 0)
                {
                    response.SetResponse(true, ExitCode.Success, "No se encontraron resultados.");
                }
                else
                {
                    response.Data.AddRange(suministrosList);
                    response.SetResponse(true, ExitCode.Success, "Resultados de búsqueda de suministros obtenidos correctamente.");
                }
            }
            catch (Exception ex)
            {
                response.SetResponse(false, ExitCode.ErrorServer, "Error retrieving Suministros search results.", ex.Message);
                return StatusCode(500, response);
            }

            return Ok(response);
        }


        // POST: api/Suministros/create
        [HttpPost("create")]
        public IActionResult Create([FromBody] SuministrosCreateRequest newSuministro)
        {
            var response = new ApiResponse();

            try
            {
                // Execute the stored procedure to insert a new Suministro record
                var id = _context.Database
                    .ExecuteSqlInterpolated($@"
                        EXEC dbo.SPAMINSuministros 
                            @Cantidad = {newSuministro.Cantidad},
                            @Descripcion = {newSuministro.Descripcion},
                            @TipoSuministroId = {newSuministro.TipoSuministroId},
                            @CreadoPor = {newSuministro.CreadoPor}
                    ");

                // Set success response after the update
                response.SetResponse(true, ExitCode.Success, "Suministro created successfully.");
            }
            catch (Exception ex)
            {
                // Handle any errors that occur during the creation process
                response.SetResponse(false, ExitCode.ErrorServer, "Error creating Suministro.", ex.Message);
                return StatusCode(500, response);
            }

            return Ok(response);
        }


        // PUT: api/Suministros/update/{id}
        [HttpPut("update/{id}")]
        public IActionResult Update(decimal id, [FromBody] SuministrosUpdateRequest updatedSuministro)
        {
            var response = new ApiResponse();

            try
            {
                // Check if the Suministro exists before attempting to update
                var suministroExists = _context.Tbammaesuministros.Any(s => s.Id == id);
                if (!suministroExists)
                {
                    response.SetResponse(false, ExitCode.ErrorNotFound, "Suministro not found.");
                    return NotFound(response);
                }

                // Execute the stored procedure to update the Suministro record
                _context.Database.ExecuteSqlInterpolated($@"
                    EXEC dbo.SPAMUPSuministros 
                        @Id = {id},
                        @Cantidad = {updatedSuministro.Cantidad}, 
                        @Descripcion = {updatedSuministro.Descripcion}, 
                        @TipoSuministroId = {updatedSuministro.TipoSuministroId},
                        @ModificadoPor = {updatedSuministro.ModificadoPor}
                ");

                // Set success response after the update
                response.SetResponse(true, ExitCode.Success, "Suministro updated successfully.");
            }
            catch (Exception ex)
            {
                // Handle any errors that occur during the update
                response.SetResponse(false, ExitCode.ErrorServer, "Error updating Suministro.", ex.Message);
                return StatusCode(500, response);
            }

            return Ok(response);
        }

        // DELETE: api/Suministros/delete/{id}
        [HttpDelete("delete/{id}")]
        public IActionResult Delete(decimal id)
        {
            var response = new ApiResponse();

            try
            {
                // Check if the Suministro exists before attempting to delete
                var suministroExists = _context.Tbammaesuministros.Any(s => s.Id == id);
                if (!suministroExists)
                {
                    response.SetResponse(false, ExitCode.ErrorNotFound, "Suministro not found.");
                    return NotFound(response);
                }

                // Execute the stored procedure to delete the Suministro
                _context.Database.ExecuteSqlInterpolated($@"
                    EXEC dbo.SPAMDLSuministros @Id = {id}
                ");

                // Set the success response after deletion
                response.SetResponse(true, ExitCode.Success, "Suministro deleted successfully.");
            }
            catch (Exception ex)
            {
                // Handle any errors that occur during the delete operation
                response.SetResponse(false, ExitCode.ErrorServer, "Error deleting Suministro.", ex.Message);
                return StatusCode(500, response);
            }

            return Ok(response);
        }

        // GET: api/Suministros/dropdownsSuministros 
        [HttpGet("dropdownsSuministros")]
        public IActionResult GetDropdownOptions()
        {
            var response = new ApiResponse();

            try
            {
                // Assuming there are lookup tables or hardcoded values for dropdowns
                var tiposSuministro = _context.TbamdettipoSuministros
                    .Select(ts => new { ts.TipoSuministroId, ts.Descripcion })
                    .ToList();

                response.Data.Add(new
                {
                    TiposSuministro = tiposSuministro
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
