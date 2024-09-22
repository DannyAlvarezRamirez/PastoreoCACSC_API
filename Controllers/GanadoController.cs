using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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

        //// POST: api/Ganado/search
        //[HttpPost("search")]
        //public IActionResult SearchGanado([FromBody] GanadoFilterRequest filters)
        //{
        //    var response = new ApiResponse();

        //    try
        //    {
        //        // Start by querying the Ganado table
        //        var query = _context.Tbamdetganados.AsQueryable();

        //        // Apply filters if they are present

        //        if (!string.IsNullOrEmpty(filters.Raza))
        //            query = query.Where(g => g.Raza == filters.Raza);

        //        if (filters.Peso.HasValue)
        //            query = query.Where(g => g.Peso == filters.Peso.Value);

        //        if (!string.IsNullOrEmpty(filters.Sexo))
        //            query = query.Where(g => g.Sexo == filters.Sexo);

        //        if (filters.Edad.HasValue)
        //            query = query.Where(g => g.Edad == filters.Edad.Value);

        //        if (!string.IsNullOrEmpty(filters.EstadoSalud))
        //            query = query.Where(g => g.EstadoSalud == filters.EstadoSalud);

        //        if (filters.FechaChequeo.HasValue)
        //            query = query.Where(g => g.FechaChequeo.Date == filters.FechaChequeo.Value.Date);

        //        if (!string.IsNullOrEmpty(filters.Productividad))
        //            query = query.Where(g => g.Productividad == filters.Productividad);

        //        if (!string.IsNullOrEmpty(filters.Tratamientos))
        //            query = query.Where(g => g.Tratamientos == filters.Tratamientos);

        //        if (filters.FechaNacimiento.HasValue)
        //            query = query.Where(g => g.FechaNacimiento.Date == filters.FechaNacimiento.Value.Date);

        //        // Execute the query and get the filtered list of Ganado
        //        var ganadoList = query.ToList();

        //        // If no results, set a "no results found" response
        //        if (ganadoList.Count == 0)
        //        {
        //            response.SetResponse(true, ExitCode.Success, "No se encontraron resultados.");
        //        }
        //        else
        //        {
        //            response.Data.AddRange(ganadoList);
        //            response.SetResponse(true, ExitCode.Success, "Resultados de búsqueda de ganado obtenidos correctamente.");
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        response.SetResponse(false, ExitCode.ErrorServer, "Error retrieving Ganado search results.", ex.Message);
        //        return StatusCode(500, response);
        //    }

        //    return Ok(response);
        //}

        // POST: api/Ganado/create
        [HttpPost("create")]
        public IActionResult Create([FromBody] Tbamdetganado ganado)
        {
            var response = new ApiResponse();

            try
            {
                _context.Tbamdetganados.Add(ganado);
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
        public IActionResult Update(decimal id, [FromBody] Tbamdetganado updatedGanado)
        {
            var response = new ApiResponse();

            try
            {
                var ganado = _context.Tbamdetganados.Find(id);
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
                ganado.FechaUltimoChequeo = updatedGanado.FechaUltimoChequeo;
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
                var ganado = _context.Tbamdetganados.Find(id);
                if (ganado == null)
                {
                    response.SetResponse(false, ExitCode.ErrorNotFound, "Ganado not found.");
                    return NotFound(response);
                }

                _context.Tbamdetganados.Remove(ganado);
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
                var razas = _context.Tbamcatrazas.Select(r => r.Descripcion).ToList();
                var sexos = _context.Tbamcatsexos.Select(r => r.Descripcion).ToList();
                var estadosSalud = _context.TbamcatestadoSaluds.Select(es => es.Descripcion).ToList();
                var productividades = _context.Tbamcatproductividads.Select(p => p.Descripcion).ToList();
                var tratamientos = _context.Tbamcattratamientos.Select(t => t.Descripcion).ToList();

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
