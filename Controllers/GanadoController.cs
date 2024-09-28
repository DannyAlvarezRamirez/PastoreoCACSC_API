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
                // Start by querying the Ganado table
                var query = _context.Tbammaeganados.AsQueryable();

                // Apply filters if they are present

                if (filters.RazaId.HasValue)
                    query = query.Where(g => g.RazaId == filters.RazaId);

                if (filters.Peso.HasValue)
                    query = query.Where(g => g.Peso == filters.Peso.Value);

                if (filters.SexoId.HasValue)
                    query = query.Where(g => g.SexoId == filters.SexoId);

                if (filters.Edad.HasValue)
                    query = query.Where(g => g.Edad == filters.Edad.Value);

                if (filters.EstadoSaludId.HasValue)
                    query = query.Where(g => g.EstadoSaludId == filters.EstadoSaludId);

                if (filters.FechaChequeo.HasValue)
                    query = query.Where(g => g.UltimoChequeo == filters.FechaChequeo.Value.Date);

                if (filters.ProductividadId.HasValue)
                    query = query.Where(g => g.ProductividadId == filters.ProductividadId);

                if (filters.TratamientosId.HasValue)
                    query = query.Where(g => g.TratamientoId == filters.TratamientosId);

                if (filters.FechaNacimiento.HasValue)
                    query = query.Where(g => g.FechaNacimiento == filters.FechaNacimiento.Value.Date);

                // Execute the query and get the filtered list of Ganado
                var ganadoList = query.ToList();

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
        public IActionResult Create([FromBody] Tbammaeganado ganado)
        {
            var response = new ApiResponse();

            try
            {
                _context.Tbammaeganados.Add(ganado); 
                _context.SaveChanges();

                response.Data.Add(ganado);
                response.SetResponse(true, ExitCode.Success, "Ganado created successfully.");
            }
            catch (Exception ex)
            {
                response.SetResponse(false, ExitCode.ErrorServer, "Error creating Ganado.", ex.Message);
                return StatusCode(500, response);
            }

            return Ok(response);
        }

        // PUT: api/Ganado/update/{id}
        [HttpPut("update/{id}")]
        public IActionResult Update(decimal id, [FromBody] Tbammaeganado updatedGanado)
        {
            var response = new ApiResponse();

            try
            {
                var ganado = _context.Tbammaeganados.Find(id);
                if (ganado == null)
                {
                    response.SetResponse(false, ExitCode.ErrorNotFound, "Ganado not found.");
                    return NotFound(response);
                }

                ganado.Raza = updatedGanado.Raza;
                ganado.Peso = updatedGanado.Peso;
                ganado.Sexo = updatedGanado.Sexo;
                ganado.Edad = updatedGanado.Edad;
                ganado.EstadoSalud = updatedGanado.EstadoSalud;
                ganado.Productividad = updatedGanado.Productividad;
                ganado.Tratamiento = updatedGanado.Tratamiento;
                ganado.UltimoChequeo = updatedGanado.UltimoChequeo;
                ganado.FechaNacimiento = updatedGanado.FechaNacimiento;

                _context.SaveChanges();

                response.Data.Add(ganado);
                response.SetResponse(true, ExitCode.Success, "Ganado updated successfully.");
            }
            catch (Exception ex)
            {
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
                var ganado = _context.Tbammaeganados.Find(id);
                if (ganado == null)
                {
                    response.SetResponse(false, ExitCode.ErrorNotFound, "Ganado not found.");
                    return NotFound(response);
                }

                _context.Tbammaeganados.Remove(ganado);
                _context.SaveChanges();

                response.SetResponse(true, ExitCode.Success, "Ganado deleted successfully.");
            }
            catch (Exception ex)
            {
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
